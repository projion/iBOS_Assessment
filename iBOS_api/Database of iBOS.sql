use master

create database iBOSdb
use iBOSdb

CREATE TABLE tblEmployee (
  employeeId INT PRIMARY KEY,
  employeeName VARCHAR(50) NOT NULL,
  employeeCode VARCHAR(10) NOT NULL,
  employeeSalary INT NOT NULL
);
INSERT INTO tblEmployee (employeeId, employeeName, employeeCode, employeeSalary)
VALUES 
  (502030, 'Mehedi Hasan', 'EMP319', 50000),
  (502031, 'Ashikur Rahman', 'EMP321', 45000),
  (502032, 'Rakibul Islam', 'EMP322', 52000);

CREATE TABLE tblEmployeeAttendance (
  attendanceId INT PRIMARY KEY IDENTITY,
  employeeId INT,
  attendanceDate DATE,
  isPresent BIT,
  isAbsent BIT,
  isOffday BIT
);

INSERT INTO tblEmployeeAttendance (employeeId, attendanceDate, isPresent, isAbsent, isOffday)
VALUES
  (502030, '2023-06-24', 1, 0, 0),
  (502030, '2023-06-25', 0, 1, 0),
  (502031, '2023-06-25', 1, 0, 0);



Select * from tblEmployee
Select * from tblEmployeeAttendance


DELETE FROM tblEmployee;
 