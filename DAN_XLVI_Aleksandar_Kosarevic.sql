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
FirstName varchar(100), 
LastName varchar(100),
DateOfBirth varchar(100),
JMBG char(13),
Account int,
Email varchar(100),
Salary int,
Position varchar(100),
Username varchar(100),
Password varchar(100),
Sector varchar(100),
AccessLevel varchar(100)
);

CREATE TABLE tblEmploye (
EmployeID int PRIMARY KEY IDENTITY(1,1),
FirstName varchar(100), 
LastName varchar(100),
DateOfBirth varchar(100),
JMBG char(13),
Account int,
Email varchar(100),
Salary int,
Position varchar(100),
Username varchar(100),
Password varchar(100),
);

insert into tblManager values ('name', 'lastname', '11-11-1111', '1111111111111', 1, 'a', 1, 'a', 'a', 'a', 'a', 'Modify');
insert into tblManager values ('name', 'lastname', '11-11-1111', '1111111111111', 1, 'a', 1, 'a', 'b', 'b', 'a', 'Read-Only');

insert into tblEmploye values ('name', 'lastname', '11-11-1111', '1111111111111', 1, 'a', 1, 'a', 'a', 'a');
insert into tblEmploye values ('name', 'lastname', '11-11-1111', '1111111111111', 1, 'a', 1, 'a', 'a', 'a');
insert into tblEmploye values ('name', 'lastname', '11-11-1111', '1111111111111', 1, 'a', 1, 'a', 'a', 'a');

select * from tblManager;