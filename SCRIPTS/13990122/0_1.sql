
GO

/****** Object:  UserDefinedFunction [dbo].[fn_getAllChainedsById]    Script Date: 4/13/2020 12:06:34 AM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_getLetterNumbersChainedById]
(@letterId int)
RETURNS varchar(2000)
AS
BEGIN

declare @id int;
declare @preId int;
declare @nextId int;
declare @str varchar(4000);
declare @letterNumber varchar(50)

set @id = @letterId;


while @id is not null
begin

  select @preId = PREVIOUSLETTERID from LETTER where ID = @id;
  if (@preId is null)
    break
  else
    set @id = @preId;
    
end;  

select @letterNumber= LETTERNUMBER from LETTER where ID= @id 
set @str = @letterNumber -- cast (@id as varchar)
while @id is not null
begin

  select @nextId =  NEXTLETTERID from LETTER where ID = @id;
  --print @nextId;
  if (@nextId is null)
    break
  else 
  begin
    set @id = @nextId;
	select @letterNumber= LETTERNUMBER from LETTER where ID= @id 
    set @str = @str + ',' + @letterNumber -- cast(@id as varchar)
  end;  
    
end;  
 return @str
END

GO

