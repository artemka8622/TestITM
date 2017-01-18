DECLARE @switchId varchar(56)
SET @switchId =  newID();
USE SwitchDb

DECLARE @i int = 0
DECLARE @j int = 0
DECLARE @Status int = 1
DECLARE @CountStatus int = 100
DECLARE @PrevStatus int = 0
DECLARE @date DATETIME = CAST('2016.12.01 15:00:00' AS DATETIME)

WHILE @i < 100
BEGIN
    SET @i = @i + 1
    SET @switchId =  newID();
    INSERT INTO Switch(Id, Name) VALUES (@switchId, 'Switch' + CAST( @i AS VARCHAR));
    SET @CountStatus = RAND()*500;
    WHILE @j < @CountStatus
    BEGIN
      SET @Status = 1
      IF @PrevStatus = 1 BEGIN  
      	SET @Status = -1
      END
      SET @PrevStatus = @Status
      SET @date = DATEADD(MILLISECOND, RAND()*1450, @date);
    	INSERT INTO Status(SwitchId,DateTime, ActionSwitch) VALUES (@switchId, @date,  @Status);
      SET @j = @j + 1
    END
    SET @j = 0
END

