Create Database Education_System;
use Education_System;
Create table Registration(
id int primary key auto_increment,
Firstname varchar(255),
Lastname varchar(255),
Username varchar(255),
Password varchar(255),
Role varchar(255))
;

drop table Registration;
 Create table StdReg(
 idreg int primary key,
Stdname varchar(255),

Course varchar(255)
 );
 
 Create table StdReport(
 idrep int primary key,
Studname varchar(255),

CourseName varchar(255),
Marks float
 );
 
 Create table Faculty(
 idfac int primary key,
 Name varchar(255),
 Course varchar(255),
 Assigments varchar(255)
 )