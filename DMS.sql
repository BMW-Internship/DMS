Create Database Education_System;
use Education_System;
Create table Registration(
id int primary key ,
Firstname varchar(255),
Lastname varchar(255),
Username varchar(255),
Password varchar(255),
Role varchar(255))
;

 
 Create table Faculty(
 idfac int primary key,
 Name varchar(255),
 Course varchar(255),
 Assigments varchar(255)
 );
 
 Create table Students(
 idreg int primary key,
Stdname varchar(255),
StdSurname varchar(255),
Course varchar(255),
Marks int
 );
 