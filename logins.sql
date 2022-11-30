use master
go
if exists (select name from sysdatabases where name = N'testLogin')
	drop database testLogin
go
CREATE DATABASE testLogin
go
USE testLogin
GO

CREATE TABLE [dbo].[UserLogins](  
[id] [int] IDENTITY(1,1) NOT NULL,  
[UserName] [varchar](100) NULL,  
[Password] [varchar](50) NULL,  
CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED  
(  
   [id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY] 

select * from UserLogins