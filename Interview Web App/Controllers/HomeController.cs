using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Interview_Web_App.Models;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System.Net;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Interview_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFile(IFormFile file)
        {

            string employeeDocumentFilePath = Environment.CurrentDirectory;

            try
            {
                if (file != null)
                {
                    employeeDocumentFilePath = Path.Combine(employeeDocumentFilePath, "employeeFile.txt");

                    using (var stream = System.IO.File.Create(employeeDocumentFilePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                else
                {
                    TempData["SuccessIndicator"] = "No file found, please select file and try again.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                //Delete file if exists
                if (System.IO.File.Exists(employeeDocumentFilePath))
                {
                    System.IO.File.Delete(employeeDocumentFilePath);
                }

                return BadRequest(new { message = "Unable to process file, please try again." });
            }

            //Pass file to API
            var client = new RestClient(_configuration.GetValue<string>("ApiUrl"));

            var addEmployeesRequest = new RestRequest("", Method.POST);
            addEmployeesRequest.AddFile("employeeFile", employeeDocumentFilePath);
            addEmployeesRequest.AlwaysMultipartFormData = true;

            IRestResponse response = client.Execute(addEmployeesRequest);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                TempData["SuccessIndicator"] = "Employees added Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["SuccessIndicator"] = "Failed to add new employees, please try again.";
                return RedirectToAction("Index");
            }
        }
    }
}
