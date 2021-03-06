 
 declare @idstr varchar(500)
 declare @letterNumberstr varchar(500)

 declare @counter int
 declare @ids cursor
 declare @group_pk TABLE (id int)
 declare @group_pk_id int

 declare @update_sql nvarchar(1000)
 set @ids = cursor for 
	select distinct dbo.fn_getAllChainedsById(ID) as idstr,
	 dbo.fn_getLetterNumbersChainedById(ID) as letterNumberstr
	  from LETTER where 
			dbo.fn_getAllChainedsById(ID) like '%,%'

open @ids
fetch next
from @ids into @idstr, @letterNumberstr
set @counter = 0
WHILE @@FETCH_STATUS = 0
BEGIN
     -- select @idstr 
	    set @counter = @counter + 1
		
		insert into dbo.LETTERGROUP(GROUPTITLE, LETTERNUMBERS)
			OUTPUT INSERTED.ID INTO @group_pk
		  values(
		   cast('گروه ' as varchar) + cast(@counter as varchar),@letterNumberstr)
		 
		 select @group_pk_id= id from @group_pk;
		 -- add letter numbers to letter group
		  
		 -- update LETTERGROUP set LETTERNUMBERS= fn_getLetterNumbersChainedById( 
			-- where ID=@group_pk_id
		 -- update letter
		 set @update_sql = 
		 
		    cast('update  LETTER set GROUPID=' as  varchar) + 
			cast(@group_pk_id as varchar) + 
			cast(' where ID in(' as varchar) +  
			cast(@idstr as varchar) +
			cast(')' as varchar);
		 
		 --CONCAT('update  LETTER set GROUPID=',
		 --	@group_pk_id, ' where ID in(',@idstr,')');
			 
		  execute sp_executesql  @update_sql
		  

		 delete from @group_pk

		--SELECT * FROM dbo.splitstring(@idstr)
		
		 -- seperate idstr by comma
		 -- create group 
		 -- update letter groupid column

	 fetch next
	 from @ids  into @idstr, @letterNumberstr
	 
END

CLOSE @ids
DEALLOCATE @ids