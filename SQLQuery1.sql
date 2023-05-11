CREATE TABLE Pengunjung (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255) NOT NULL,
    Email varchar(255) NOT NULL
);

CREATE TABLE Ayo (
   Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    Name varchar(255) NOT NULL,
    Email varchar(255) NOT NULL
);
DELETE FROM Ayo WHERE Id = (SELECT CONVERT(uniqueidentifier,'4aefff0d-7b0d-48d6-8fd3-f6d3b60482f6'))
SELECT CONVERT(uniqueidentifier,'')