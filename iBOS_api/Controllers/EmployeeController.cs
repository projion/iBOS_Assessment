using iBOS_api.DAL;
using iBOS_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iBOS_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        public EmployeeController(MyAppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        // READ all employees
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _context.tblEmployee.ToList();
                if (employees.Count == 0)
                {
                    return NotFound("No employees found.");
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        // READ employee by ID
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _context.tblEmployee.Find(id);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        // CREATE new employee
        public IActionResult CreateEmployee(Employee employee)
        {
            try
            {
                _context.tblEmployee.Add(employee);
                _context.SaveChanges();
                return Ok("Employee Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        // UPDATE employee by ID
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.employeeId)
                {
                    return BadRequest("Invalid employee ID.");
                }
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok("Employee details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        // DELETE employee by ID
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.tblEmployee.Find(id);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }
                _context.tblEmployee.Remove(employee);
                _context.SaveChanges();
                return Ok("Employee details deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        // READ employee attendance by employee ID
        public IActionResult GetEmployeeAttendance(int id)
        {
            try
            {
                var attendance = _context.tblEmployeeAttendance.Where(a => a.employeeId == id).ToList();
                if (attendance.Count == 0)
                {
                    return NotFound($"No attendance records found for employee with ID {id}.");
                }
                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        // CREATE employee attendance record
        public IActionResult CreateEmployeeAttendance(EmployeeAttendance attendance)
        {
            try
            {
                _context.tblEmployeeAttendance.Add(attendance);
                _context.SaveChanges();
                return Ok("Employee attendance record created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        // UPDATE employee attendance record by ID
        public IActionResult UpdateEmployeeAttendance(int id, EmployeeAttendance attendance)
        {
            try
            {
                if (id != attendance.employeeId)
                {
                    return BadRequest("Invalid attendance ID.");
                }
                _context.Entry(attendance).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok("Employee attendance record updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        // DELETE employee attendance record by ID
        public IActionResult DeleteEmployeeAttendance(int id)
        {
            try
            {
                var attendance = _context.tblEmployeeAttendance.Find(id);
                if (attendance == null)
                {
                    return NotFound($"Attendance record with ID {id} not found.");
                }
                _context.tblEmployeeAttendance.Remove(attendance);
                _context.SaveChanges();
                return Ok("Employee attendance record deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}