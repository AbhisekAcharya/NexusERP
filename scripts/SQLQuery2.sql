select * from Users
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' ORDER BY ORDINAL_POSITION;
delete from Users where Id = 'DBE2AF6D-D67F-48EF-BE30-831F3F694B76'
SELECT * FROM Employees where IsDeleted = 0 ORDER BY EmployeeCode DESC;
INSERT INTO Employees (Id, EmployeeCode, FirstName, LastName, Email, Department, Status, CreatedOnUtc, IsDeleted)
VALUES ( NEWID(), 'EMP009', 'Abhisek', 'Acharya', 'erabhisekacharya@gmail.com', 'Admin', 1, GETUTCDATE(), 0 );
select * from PasswordResetTokens
