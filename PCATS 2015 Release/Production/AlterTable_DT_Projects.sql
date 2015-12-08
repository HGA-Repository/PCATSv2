ALTER TABLE DT_Projects    
ADD Fixed_rate bit

ALTER TABLE DT_Employees 
 ADD CONSTRAINT Fixed_rate DEFAULT (0) FOR [Fixed_rate]
