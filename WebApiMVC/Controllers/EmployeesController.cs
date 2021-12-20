using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiMVC.Models;

namespace WebApiMVC.Controllers
{
    public class EmployeesController : Controller
    {


        // GET: Employees
        public ActionResult Index()
        {
            
            GetAllDepartments();
            var emp = new List<Employee>();
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:9090/api/employees").Result;
            if (result.IsSuccessStatusCode)
            {
                emp= result.Content.ReadAsAsync<List<Employee>>().Result;
            }
            return View(emp);
        }

        private void GetAllDepartments()
        {
            var dept = new List<Department>();

            HttpClient clientt = new HttpClient();
            var resultt = clientt.GetAsync("http://localhost:9090/api/Departments").Result;
            if (resultt.IsSuccessStatusCode)
            {
                dept = resultt.Content.ReadAsAsync<List<Department>>().Result;
            }
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {

            var emp = new Employee();

            HttpClient client = new HttpClient();
            var result = client.GetAsync($"http://localhost:9090/api/employees/{id}").Result;
            if (result.IsSuccessStatusCode)
            {
                emp=result.Content.ReadAsAsync<Employee>().Result;
            }


            return View(emp);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var dept = new List<Department>();

            HttpClient clientt = new HttpClient();
            var resultt = clientt.GetAsync("http://localhost:9090/api/Departments").Result;
            if (resultt.IsSuccessStatusCode)
            {
                dept = resultt.Content.ReadAsAsync<List<Department>>().Result;
            }
            ViewBag.dept = dept;
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee collection)
        {
            try
            {
                

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9090");
                var result = client.PostAsJsonAsync("api/employees", collection).Result;

                if (result.IsSuccessStatusCode)
                {
                    var emps = new List<Employee>();
                    HttpClient clientt = new HttpClient();
                    var resultt = client.GetAsync("http://localhost:9090/api/employees").Result;
                    if (result.IsSuccessStatusCode)
                    {
                        emps = resultt.Content.ReadAsAsync<List<Employee>>().Result;
                    }
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            GetAllDepartments();

            var emp = new Employee();

            HttpClient client = new HttpClient();
            var result = client.GetAsync($"http://localhost:9090/api/employees/{id}").Result;
            if (result.IsSuccessStatusCode)
            {
                emp = result.Content.ReadAsAsync<Employee>().Result;
            }
            return View(emp);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9090");
                var result = client.PutAsJsonAsync($"api/employees/{id}/",collection).Result;
                if (result.IsSuccessStatusCode)
                {
                    var emp = new List<Employee>();
                    HttpClient clientt = new HttpClient();
                    var resultt = client.GetAsync("http://localhost:9090/api/employees").Result;
                    if (result.IsSuccessStatusCode)
                    {
                        emp = resultt.Content.ReadAsAsync<List<Employee>>().Result;
                    }
                }


                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {

            GetAllDepartments();
            var emp = new Employee();

            HttpClient client = new HttpClient();
            var result = client.GetAsync($"http://localhost:9090/api/employees/{id}").Result;
            if (result.IsSuccessStatusCode)
            {
                emp = result.Content.ReadAsAsync<Employee>().Result;
            }
            return View(emp);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9090");
                var result = client.DeleteAsync($"api/employees/{id}/").Result;
                if (result.IsSuccessStatusCode)
                {
                    var emp = new List<Employee>();
                    HttpClient clientt = new HttpClient();
                    var resultt = client.GetAsync("http://localhost:9090/api/employees").Result;
                    if (result.IsSuccessStatusCode)
                    {
                        emp = resultt.Content.ReadAsAsync<List<Employee>>().Result;
                    }
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
