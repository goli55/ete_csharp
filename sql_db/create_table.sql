IF not EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_NAME = N'Customers')
BEGIN
  PRINT 'Craete customers table'
  
create table [dbo].[Customers](
	Id int not null,
	[FName] nvarchar(50) null,
	[LName] nvarchar(50) null,
	CONSTRAINT PK_Customers PRIMARY KEY (Id)
);

END
