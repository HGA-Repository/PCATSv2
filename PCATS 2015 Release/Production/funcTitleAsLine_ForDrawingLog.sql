Alter FUNCTION [dbo].[funcTitleAsLine_ForDrawingLog]
(
	@Title1		varchar(100),
	@Title2		varchar(100),
	@Title3		varchar(100),
	@Title4		varchar(100),
	@Title5		varchar(100),
	@Title6		varchar(100)
)
RETURNS varchar(600)
AS
BEGIN
	DECLARE @Title	varchar(600)

	SET @Title = ''

	IF (LEN(@Title1) > 0)
	BEGIN
		--SET @Title = @Title + @Title1 + CHAR(13)
		SET @Title = @Title + @Title1 + ' '
	END

	IF (LEN(@Title2) > 0)
	BEGIN
		--SET @Title = @Title + @Title2 + CHAR(13)
		SET @Title = @Title + @Title2 + ' '
	END

	IF (LEN(@Title3) > 0)
	BEGIN
		--SET @Title = @Title + @Title3 + CHAR(13)
		SET @Title = @Title + @Title3 + ' '
	END

	IF (LEN(@Title4) > 0)
	BEGIN
		--SET @Title = @Title + @Title4 + CHAR(13)
		SET @Title = @Title + @Title4 + ' '
	END

	IF (LEN(@Title5) > 0)
	BEGIN
		--SET @Title = @Title + @Title5 + CHAR(13)
		SET @Title = @Title + @Title5 + ' '
	END

	IF (LEN(@Title6) > 0)
	BEGIN
		--SET @Title = @Title + @Title6 + CHAR(13)
		SET @Title = @Title + @Title6 + ' '
	END

	--RETURN LTRIM(RTRIM(@Title))
	RETURN @Title
END

GO


