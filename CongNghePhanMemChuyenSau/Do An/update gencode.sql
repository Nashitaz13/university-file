
/* 
DECLARE @p VARCHAR(15)
exec SYS_CodeMasters_Gen 'Asset', @p out
PRINT @p
*/
ALTER PROCEDURE [dbo].[SYS_CodeMasters_Gen]
	@p_Kind varchar(100),
	@p_KeyGen varchar(15)  OUT
AS
DECLARE @CurValue AS Numeric

DECLARE @p_Prefix AS varchar(10)


SELECT @p_Prefix = Prefix FROM SYS_PREFIX WHERE ID = @p_Kind

BEGIN TRANSACTION	
	IF NOT EXISTS(SELECT CurValue FROM SYS_CODEMASTERS WHERE Prefix=@p_Prefix)
		BEGIN
			INSERT SYS_CODEMASTERS (
				Prefix,

				CurValue,
				[Description],
				Active
			)VALUES(
				@p_Prefix,
				1,
				'',
				1	
			)
			IF @@ERROR <> 0 GOTO ABORT
			
			SET @CurValue = 1
		END
	ELSE
		BEGIN	
			IF EXISTS(SELECT CurValue FROM SYS_CODEMASTERS WHERE Prefix=@p_Prefix)
				UPDATE SYS_CODEMASTERS SET 	CurValue=CurValue + 1
				WHERE Prefix=@p_Prefix
			IF @@ERROR <> 0 GOTO ABORT
		
			SELECT @CurValue = CurValue FROM SYS_CODEMASTERS WHERE Prefix = @p_Prefix
		END
	
	SET @p_KeyGen = @p_Prefix + right('000000000000' + convert(varchar(20),@CurValue), 15 - len(@p_Prefix))
	IF @@ERROR <> 0 GOTO ABORT

COMMIT TRANSACTION
RETURN 0

ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @p_KeyGen = ''
	RETURN -1
END








