Create PROCEDURE [dbo].[spLogin_GetCurrUserSecurityLevelForThisTab]

@ID		int,
@AcctGroup int

AS
select 
ul.UserID as [UserID], 
u.Description as [UserName], 
ul.DepartmentID, 
d.Name as[DeptName],
d.Description as [DepartmentDescription], 
d.AcctGroup as [AcctGroup], 
s.passlevel as [passlevel],
s.[Name] as [SecurityName]

from DT_UserLevels ul 
left join SY_SecurityLevels s on ul.SecurityLevelID = s.ID
left join DT_Departments d on ul.DepartmentID = d.ID
left join dt_Users u on ul.UserID = u.ID

where ul.DepartmentID in(7,8,9,10,12,13,15,17,19,20,21,22,23) and u.ID = @ID and d.AcctGroup = @AcctGroup


GO


