use master;
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Supercharge')
BEGIN
    CREATE DATABASE Supercharge;
END;
go