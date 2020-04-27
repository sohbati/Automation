/****** Object: Function [dbo].[fn_shamsi]   Script Date: 2013/09/26 11:44:49 ب.ظ ******/
USE [andicator];
GO
SET ANSI_NULLS OFF;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE FUNCTION [dbo].[fn_shamsi]
(@jdate datetime)
RETURNS varchar(10)
AS
BEGIN
DECLARE @a datetime
DECLARE @Y int,@M INT,@D INT,@YY int,@MM INT,@DD INT,@T varchar(10)


set @a=@jdate;
set @Y =(Year(@jdate))
set @M = (Month(@jdate))
set @D = (Day(@jdate))

If (@M = 1 And @D < 21 )
BEGIN
set @YY = @Y - 622
set @MM = @M + 9
set @DD = @D + 10
End 

If @M = 1 And @D > 20 
BEGIN
set @YY = @Y - 622
set @MM = @M + 10
set @DD = @D - 20
End 

If @M = 2 And @D < 20 
BEGIN
set @YY = @Y - 622
set @MM = @M + 9
set @DD = @D+ 11
End 

If @M = 2 And @D > 19 
BEGIN
set @YY = @Y - 622
set @MM = @M + 10
set @DD = @D - 19
End 

If @M = 3 And @D < 21 
BEGIN
set @YY = @Y - 622
set @MM = @M + 9 
set @DD = @D+ 9
End 

If @M = 3 And @D > 20 
BEGIN
set @YY = @Y- 621
set @MM = @M - 2
set @DD = @D- 20
End 

If @M = 4 And @D < 21 
BEGIN
set @YY = @Y- 621
set @MM = @M - 3
set @DD = @D+ 11
End


If @M = 4 And @D > 20 
BEGIN
set @YY = @Y - 621
set @MM = @M- 2
set @DD = @D - 20
End 
If @M = 5 And @D < 22 
BEGIN
set @YY = @Y - 621
set @MM = @M - 3
set @DD = @D + 10
End 
If @M = 5 And @D > 21 
BEGIN
set @YY = @Y - 621
set @MM = @M - 2
set @DD = @D - 21
End 
If @M = 6 And @D < 22 
BEGIN
set @YY = @Y - 621
set @MM = @M - 3
set @DD = @D + 10
End 

If @M = 6 And @D > 21 
BEGIN
set @YY = @Y - 621
set @MM = @M - 2
set @DD = @D - 21
End 
If @M = 7 And @D < 23 
BEGIN
set @YY = @Y - 621
set @MM = @M - 3
set @DD = @D + 9
End 
If @M = 7 And @D > 22 
BEGIN
set @YY = @Y - 621
set @MM = @M - 2
set @DD = @D - 22
End 
If @M = 8 And @D < 23 
BEGIN
set @YY = @Y- 621
set @MM = @M - 3
set @DD = @D + 9
End 
If @M = 8 And @D > 22 
BEGIN
set @YY = @Y - 621
set @MM = @M - 2
set @DD = @D- 22
End 

If @M = 9 And @D < 23 
BEGIN
set @YY = @Y- 621
set @MM = @M - 3
set @DD = @D + 9
End 
If @M = 9 And @D > 22 
BEGIN
set @YY = @Y - 621
set @MM = @M - 2
set @DD = @D- 22
End 
If @M = 10 And @D < 23 
BEGIN
set @YY = @Y - 621
set @MM = @M - 3
set @DD = @D + 8
End 
If @M = 10 And @D > 22 
BEGIN
set @YY = @Y - 621
set @MM = @M - 2
set @DD = @D - 22
End 
If @M = 11 And @D < 22 
BEGIN
set @YY = @Y - 621
set @MM = @M - 3
set @DD = @D+ 9
End 

If @M = 11 And @D > 21 
BEGIN
set @YY = @Y - 621
set @MM = @M - 2
set @DD = @D- 21
End 
If @M = 12 And @D < 22 
BEGIN
set @YY = @Y- 621
set @MM = @M - 3
set @DD = @D + 9
End 
If @M = 12 And @D > 21 
BEGIN
set @YY = @Y - 621
set @MM = @M - 2
set @DD = @D - 21
End 



If (Right(@Y, 2) % 4 = 0 And @M > 2)
BEGIN

set @DD = @DD+ 1
If @MM <= 6 
BEGIN
If @DD > 31
BEGIN
set @DD = 1
set @MM= @MM + 1
End 
else if @MM > 6 
BEGIN
If @DD > 30 
BEGIN 
set @DD = 1
set @MM= @MM + 1
End
End

If @MM = 12 And @DD= 30 
BEGIN 
set @MM=1
set @DD=1
set @YY=@YY+1
End
end
End 

If (Right(@Y, 2) - 1)%4 = 0 And @M <= 3
BEGIN
If Not ( @M = 3 And @D > 20) 
BEGIN
set @DD= @DD + 1
If @DD = 31 
BEGIN
set @DD = 1
set @MM = @MM + 1
End 
End 
End
IF @YY= 1311
RETURN '';

 IF @YY > 1311
BEGIN
	SET @T = Right(str(@YY), 4) + '/' +  Right('00'+(LTRIM(STR(@MM))), 2) + '/' + Right('00'+(LTRIM(STR(@DD))), 2) 
	return @T;
END 
RETURN '';
END
GO
