using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Interview_Web_API.Database.Entity;
using Interview_Web_API.Helpers;
using Interview_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Interview_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ConnectionString _connectionString;
        
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration, ConnectionString connectionString)
        {
            _configuration = configuration;
            _connectionString = connectionString;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm(Name = "employeeFile")] IFormFile employeeFile)
        {
            string employeeDocumentFilePath = Environment.CurrentDirectory;

            try
            {
                if (employeeFile.Length > 0)
                {
                    employeeDocumentFilePath = Path.Combine(employeeDocumentFilePath, "employeeFile.txt");

                    using (var stream = System.IO.File.Create(employeeDocumentFilePath))
                    {
                        await employeeFile.CopyToAsync(stream);
                    }
                }
                else
                {
                    return BadRequest(new { message = "Unable to process file, the file submitted contained to data." });
                }
            }
            catch (Exception)
            {
                //delete file
                if (System.IO.File.Exists(employeeDocumentFilePath))
                {
                    System.IO.File.Delete(employeeDocumentFilePath);
                }

                return BadRequest(new { message = "Unable to process file, please try again." });
            }

            try
            {
                var employees = ConvertCSVToEmployee.ConvertCSVFileTOEmployees(employeeDocumentFilePath);

                foreach (Employee employee in employees)
                {
                    _connectionString.Add(employee);
                    
                }
                _connectionString.SaveChanges();

            }
            catch (Exception)
            {
                return BadRequest(new { message = "An error occured when processing employess file." });
            }


            return Ok();

        }
        
    }
}
