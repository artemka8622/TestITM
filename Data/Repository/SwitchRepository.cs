﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store;
using Store.Model;

namespace Data.Repository
{
    /// <summary>
    /// Класс репозитория для комутатора
    /// todo вытащить функциональность отчетов из этого класса
    /// todo смена статуса тоже здесь не место, но нет времени
    /// </summary>
    public class SwitchRepository : IRepository<SwitchModel>
    {
        /// <summary>
        /// Частая смена статуса таймоут в секундах
        /// </summary>
        private int ConstTimeOutFlickering { get; set; } = 10;
        /// <summary>
        /// Частая смена статус количество смен статуса
        /// </summary>
        private int ConstCountSwitchStatusFlickering { get; set; } = 20;
        public AutoConnector connector { get; set; } = ConnectionFactory.GetConnector();
        public List<SwitchModel> GetAllItems()
        {
            var result = new List<SwitchModel>();
            var reader = connector.ExecuteReader("select * from Switch");
            while (reader.Read())
            {
                var item = new SwitchModel()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                };
                result.Add(item);
            }
            return result;
        }

        public SwitchModel GetItemById(Guid id)
        {
            var result = new List<SwitchModel>();
            var reader = connector.ExecuteReader($"select * from Switch where Id = '%{id}%'");
            while (reader.Read())
            {
                var item = new SwitchModel()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                };
                result.Add(item);
            }
            return result.First();
        }

        public void Update(SwitchModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<SwitchModel> GetItemByName(string name)
        {
            var result = new List<SwitchModel>();
            var reader = connector.ExecuteReader($"select * from Switch where Name like '%{name}%'");
            while (reader.Read())
            {
                var item = new SwitchModel()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                };
                result.Add(item);
            }
            return result;
        }

        public List<StatusModel> GetReport1(DateTime @from, DateTime to)
        {
            var result = new List<StatusModel>();
            var sql = "SELECT SwitchId, Action, s.Name, DateTime FROM (SELECT " +
                      "FIRST_VALUE(ActionSwitch) OVER(PARTITION BY SwitchId ORDER BY DateTime DESC) AS Action, " +
                      "FIRST_VALUE(SwitchId) OVER(PARTITION BY SwitchId ORDER BY DateTime DESC) AS SwitchId, " +
                      "FIRST_VALUE(DateTime) OVER (PARTITION BY SwitchId ORDER BY DateTime DESC) AS DateTime " +
                      $"from Status WHERE DateTime BETWEEN @from AND @to) AS t, Switch s " +
                      "WHERE s.Id = t.SwitchId " +
                      "GROUP BY SwitchId, Action, s.Name,DateTime " +
                      "ORDER BY s.Name, DateTime";
            var reader = connector.ExecuteReader(sql, new Dictionary<string, object>() { { "@from", @from}, { "@to", to } });
            while (reader.Read())
            {
                var item = new StatusModel()
                {
                    Id = reader.GetGuid(0),
                    Switch = new SwitchModel() { Id = reader.GetGuid(0) , Name = reader.GetString(2) },
                    ActionSwitch = (ActionSwitch)reader.GetInt32(1),
                    DateTime = reader.GetDateTime(3)
                };
                result.Add(item);
            }
            return result;
        }

        /// <summary>
        /// Важно понимать что данный отчет работает только в случаи если статусы расположены в верном порядке
        /// т.е. после включение идет выключение. Если есть несколько подряд идущих статусов 
        /// выключение или включения, то отчет будет не верный!
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<StatusModel> GetReport2(DateTime @from, DateTime to)
        {
            var result = new List<StatusModel>();
            var sql = "SELECT SUM(SUM_TIME),t.SwitchId, s.Name FROM (SELECT " +
                      "LAG(s.DateTime) OVER(PARTITION BY s.SwitchId ORDER BY s.DateTime) AS PREV_TIME, " +
                      "s.DateTime, " +
                      "s.ActionSwitch  , " +
                      "s.SwitchId, " +
                      "Lead(s.DateTime) OVER(PARTITION BY s.SwitchId ORDER BY s.DateTime) AS NEXT_TIME, " +
                      "DateDIFF(SECOND, s.DateTime, Lead(s.DateTime)OVER(PARTITION BY s.SwitchId ORDER BY s.DateTime)) AS SUM_TIME " +
                      "FROM Status s  WHERE s.DateTime BETWEEN @from AND @to) as t, Switch s " +
                      "WHERE t.ActionSwitch = -1  AND s.Id = t.SwitchId " +
                      "GROUP BY t.SwitchId, s.Name " +
                      "ORDER BY s.Name";
            var reader = connector.ExecuteReader(sql, new Dictionary<string, object>() { { "@from", @from }, { "@to", to } });
            while (reader.Read())
            {
                var item = new StatusModel()
                {
                    Id = reader.GetGuid(1),
                    Switch = new SwitchModel() { Id = reader.GetGuid(1), Name = reader.GetString(2) },
                    SwitchId = reader.GetGuid(1),
                    //ActionSwitch = (ActionSwitch)reader.GetInt32(1),
                    WorkTime = TimeSpan.FromSeconds(reader.GetInt32(0))
                };
                result.Add(item);
            }
            return result;
        }

        /// <summary>
        /// Важно понимать что данный отчет работает только в случаи если статусы расположены в верном порядке
        /// т.е. после включение идет выключение. Если есть несколько подряд идущих статусов 
        /// выключение или включения, то отчет будет не верный!
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<StatusModel> GetReport3(DateTime @from, DateTime to)
        {

            var result = new List<StatusModel>();
            var sql = "";
            sql = "WITH T AS " +
                  "(SELECT  s.DateTime,row_number() OVER(ORDER BY DateTime) AS RN,s.SwitchId FROM Status s )" +
                  "SELECT T.SwitchId,ss.Name, MIN(DATEDIFF(SECOND, T.DateTime, k.DateTime)) " +
                  "FROM T " +
                  $"LEFT JOIN T k on T.RN +  {ConstCountSwitchStatusFlickering} = k.RN AND T.SwitchId = k.SwitchId " +
                  "LEFT JOIN Switch ss ON ss.Id = T.SwitchId " +
                  "WHERE T.DateTime BETWEEN @from AND @to " +
                  "GROUP BY T.SwitchId,ss.Name " +
                  $"--HAVING MIN(DATEDIFF(SECOND, T.DateTime, k.DateTime)) < {ConstTimeOutFlickering}" ;
            var reader = connector.ExecuteReader(sql, new Dictionary<string, object>() { { "@from", @from }, { "@to", to } });
            while (reader.Read())
            {
                var item = new StatusModel()
                {
                    Id = reader.GetGuid(0),
                    Switch = new SwitchModel() { Id = reader.GetGuid(0), Name = reader.GetString(1) },
                    WorkTime = reader.GetValue(2) is DBNull ? TimeSpan.Zero  : TimeSpan.FromSeconds(reader.GetInt32(2))
                };
                result.Add(item);
            }
            
            return result;
        }

        public ActionSwitch Switch(Guid id)
        {
            if(id == Guid.Empty)
                return ActionSwitch.Unknowun;
            var sql = $"Select ActionSwitch FROM Status where SwitchId='{id}' order by DateTime Desc";
            var ac = (ActionSwitch) connector.ExecuteScalar(sql);
            var setAction = ActionSwitch.Down == ac ? ActionSwitch.Up : ActionSwitch.Down;
            sql = $"INSERT INTO Status(SwitchId,DateTime, ActionSwitch) VALUES ('{id}', GetDate(), {(int)setAction})";
            connector.ExecuteNonQuery(sql);
            return setAction;
        }
    }
}
