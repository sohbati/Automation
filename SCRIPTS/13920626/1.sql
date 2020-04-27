/****** Object: Function [dbo].[fn_getAllChainedsById]   Script Date: 2013/09/19 01:38:37 ق.ظ ******/
USE [andicator];
GO
SET ANSI_NULLS OFF;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE FUNCTION [dbo].[fn_getAllChainedsById]
(@letterId int)
RETURNS varchar(2000)
AS
BEGIN

declare @id int;
declare @preId int;
declare @nextId int;
declare @str varchar(4000);
set @id = @letterId;
while @id is not null
begin

  select @preId = PREVIOUSLETTERID from LETTER where ID = @id;
  if (@preId is null)
    break
  else
    set @id = @preId;
    
end;  
 
set @str = cast (@id as varchar)
while @id is not null
begin

  select @nextId =  NEXTLETTERID from LETTER where ID = @id;
  --print @nextId;
  if (@nextId is null)
    break
  else 
  begin
    set @id = @nextId;
    set @str = @str + ',' +  cast(@id as varchar)
  end;  
    
end;  
 return @str
END
GO
