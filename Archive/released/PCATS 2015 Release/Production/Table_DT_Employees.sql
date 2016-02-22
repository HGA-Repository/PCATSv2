ALTER TABLE DT_Employees
ADD IsRelManager bit

ALTER TABLE DT_Employees 
ADD CONSTRAINT DF_Employees_IsRelManager DEFAULT (0) FOR [IsRelManager]

update DT_Employees set IsRelManager = Null
