/****** Object:  StoredProcedure [dbo].[spProjectSummaryInfo_InsertCleanUp]    Script Date: 2/19/2015 10:11:05 AM Aegis Research Labs SME ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/* Back up the database before running any of thisas it comtains a TRUNCATE statement */



	SET NOCOUNT ON

	BEGIN TRY
		BEGIN TRANSACTION

		-- Create a copy of the current table. There is no drop statement here. This should not be run again so it doesn't overwrite the warehouse table and any existing data.


		SELECT CAST(ID AS int) ID, CAST(ProjSumID AS int) ProjSumID, CAST(ProjectID AS int)ProjectID, 
				CAST(Schedule AS text) Schedule, CAST(ActHigh AS text) ActHigh, 
				CAST(StaffNeeds AS text) StaffNeeds, CAST(Deleted AS bit) Deleted, 
				CAST(DateLastModified AS smalldatetime) DateLastModified, CAST(DateCreated AS smalldatetime) DateCreated, 
				CAST(CFeedBack AS text) CFeedBack, CAST(POAmt AS money) POAmt, 
				CAST(BilledToDate AS money) BilledToDate, CAST(PaidToDate AS money) PaidToDate, CAST(Outstanding AS money) Outstanding 
			INTO DT_ProjectSummaryInfos_Warehouse2  
			FROM DT_ProjectSummaryInfos;
	
		
		-- Put the last item added to each project into the temp table #DT_ProjectSummaryInfosFristRow. Note the schedule column is not in use.
		SELECT ID, ProjSumID, ProjectID, Schedule, ActHigh, StaffNeeds, Deleted, DateLastModified, DateCreated, CFeedBack, POAmt, BilledToDate, PaidToDate, Outstanding
		INTO #DT_ProjectSummaryInfosFristRow
		FROM
		(
			SELECT ROW_NUMBER ( )
				OVER ( PARTITION BY ProjectID ORDER BY DateLastModified DESC ) AS RowNumber,

				ID, ProjSumID, ProjectID, Schedule, ActHigh, StaffNeeds, Deleted, DateLastModified, DateCreated, CFeedBack, POAmt, BilledToDate, PaidToDate, Outstanding
			FROM DT_ProjectSummaryInfos
		) AS A
		WHERE A.RowNumber = 1

		-- Check again to see if insertion into the #DT_ProjectSummaryInfosFristRow was successful.
		IF OBJECT_ID('tempdb..#DT_ProjectSummaryInfosFristRow') IS NOT NULL
		BEGIN
			-- If #DT_ProjectSummaryInfosFristRow is not empty clear out DT_ProjectSummaryInfos and dump #DT_ProjectSummaryInfosFristRow into it.
/*You MUST UNCOMMENT THE TRUNCATE FOR THIS TO WORK*/
			TRUNCATE TABLE DT_ProjectSummaryInfos

			SET IDENTITY_INSERT DT_ProjectSummaryInfos ON;
			INSERT INTO DT_ProjectSummaryInfos (ID, ProjSumID, ProjectID, Schedule, ActHigh, StaffNeeds, Deleted, DateLastModified, DateCreated, CFeedBack, POAmt, BilledToDate, PaidToDate, Outstanding)
			SELECT ID, ProjSumID, ProjectID, Schedule, ActHigh, StaffNeeds, Deleted, DateLastModified, DateCreated, CFeedBack, POAmt, BilledToDate, PaidToDate, Outstanding 
			FROM #DT_ProjectSummaryInfosFristRow
		END

		-- Check to see if DT_ProjectSummaryInfos has data. If not, replce with the DT_ProjectSummaryInfos_Warehouse .
		IF OBJECT_ID('DT_ProjectSummaryInfos') IS NULL
		BEGIN
			SET IDENTITY_INSERT DT_ProjectSummaryInfos ON;
			INSERT INTO DT_ProjectSummaryInfos (ID, ProjSumID, ProjectID, Schedule, ActHigh, StaffNeeds, Deleted, DateLastModified, DateCreated, CFeedBack, POAmt, BilledToDate, PaidToDate, Outstanding)
			
			SELECT ID, ProjSumID, ProjectID, Schedule, ActHigh, StaffNeeds, Deleted, DateLastModified, DateCreated, CFeedBack, POAmt, BilledToDate, PaidToDate, Outstanding 
			FROM DT_ProjectSummaryInfos_Warehouse2 
			
		END

/* commits the transaction if no error has occurred up to this point. */
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
/* If an error has occurred in the try block, roll back the transaction, then return various error 
message information in table format. */
		ROLLBACK TRANSACTION

		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_SEVERITY() AS ErrorSeverity,
			ERROR_STATE() AS ErrorState,
			ERROR_PROCEDURE() AS ErrorProcedure,
			ERROR_LINE() AS ErrorLine,
			ERROR_MESSAGE() AS ErrorMessage;

/* Optionally throw the error to the calling function. */
		THROW
	END CATCH


GO