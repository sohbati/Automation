SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop procedure UpdateArchiveInChainIds;
GO
CREATE  procedure UpdateArchiveInChainIds (@LetterId INT,@archive int, @confirm int, @fastAction int) 
AS
BEGIN
	declare @PreId int;
	declare @id int;
	
    select @PreId = l.PREVIOUSLETTERID from LETTER l where l.ID = @LetterId;
	 
	 while (@PreId > 0 )
	 begin
		 update LETTER  set ARCHIVE = @archive, FASTACTION = @fastAction,FINALCONFIRM=@confirm    where LETTER.ID = @PreId;
    	 select @PreId = l.PREVIOUSLETTERID from LETTER l where l.ID = @PreId;
	  end;
END
GO
