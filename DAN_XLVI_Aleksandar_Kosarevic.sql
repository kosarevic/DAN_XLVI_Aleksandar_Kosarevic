--If database doesnt exist it is automatically created.
IF DB_ID('Zadatak_1') IS NULL
CREATE DATABASE Zadatak_1
GO
--Newly created database is set to be in use.
USE Zadatak_1
--All tables are reseted clean.
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmploye')
drop table tblEmploye
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblManager')
drop table tblManager
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblRecord')
drop table tblRecord

CREATE TABLE tblManager (
ManagerID int PRIMARY KEY IDENTITY(1,1),
FirstName varchar(50), 
LastName varchar(50),
DateOfBirth varchar(50),
JMBG char(13),
Account int,
Email varchar(30),
Salary int,
Position varchar(30),
Username varchar(20),
Password varchar(30),
Sector varchar(20),
AccessLevel varchar(20)
);

CREATE TABLE tblEmploye (
EmployeID int PRIMARY KEY IDENTITY(1,1),
FirstName varchar(50), 
LastName varchar(50),
DateOfBirth varchar(50),
JMBG char(13),
Account int,
Email varchar(30),
Salary int,
Position varchar(30),
Username varchar(20),
Password varchar(30),
);

CREATE TABLE tblRecord(
RecordID int PRIMARY KEY IDENTITY(1,1),
FirstName varchar(50),
LastName varchar(50),
Date datetime,
Project varchar(30),
Position varchar(30),
Hours int
);

select * from tblManager;