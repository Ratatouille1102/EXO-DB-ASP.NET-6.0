CREATE DATABASE DBUserASP
GO

USE DBUserASP
GO

CREATE TABLE [User](
    User_Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Email NVARCHAR(320) NOT NULL UNIQUE,
    Password VARBINARY(32) NOT NULL,
    Salt UNIQUEIDENTIFIER NOT NULL,
    First_name NVARCHAR(50) NOT NULL,
    Last_name NVARCHAR(50) NOT NULL
)
GO

CREATE FUNCTION SF_HashAndSalt_Password 
    (
        @password NVARCHAR(64),
        @salt UNIQUEIDENTIFIER
    )
RETURNS VARBINARY(32)
AS
BEGIN
    RETURN HASHBYTES('SHA2_256',CONCAT(REPLACE(RIGHT(@salt,18),'-',''),@password,REPLACE(LEFT(@salt,18),'-','')));
END
GO

CREATE PROCEDURE SP_User_Insert 
    @email NVARCHAR(320),
    @password NVARCHAR(64),
    @first_name NVARCHAR(50),
    @last_name NVARCHAR(50)
AS
BEGIN
    DECLARE @salt UNIQUEIDENTIFIER = NEWID()
    INSERT INTO [User] (Email, Password, Salt, First_name, Last_name)
        OUTPUT inserted.User_Id
        VALUES(@email,dbo.SF_HashAndSalt_Password(@password,@salt),@salt,@first_name,@last_name)
END
GO

CREATE PROCEDURE SP_User_CheckPassword
    @email NVARCHAR(320),
    @password NVARCHAR(64)
AS
BEGIN
    SELECT [User_Id]
        FROM [User]
        WHERE   [Email] LIKE @email
            AND [Password] = dbo.SF_HashAndSalt_Password(@password, Salt)
END
GO

/* Test
SP_User_insert @email = 'samuel.legrain@bstorm.be', @password = 'Test1234=', @first_name = 'Samuel', @last_name = 'Legrain'
SP_User_CheckPassword @email = 'samuel.legrain@bstorm.be', @password = 'Test1234='
*/