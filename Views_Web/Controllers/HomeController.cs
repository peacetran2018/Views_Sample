using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Views_Web.Models;

namespace Views_Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["Title"] =  "Hello World From ViewData";
            List<Person> _persons = new List<Person>()
            {
                new Person(){
                    name = "Peace",
                    gender = Gender.Male,
                    DOB = Convert.ToDateTime("1992-06-18")
                },
                new Person(){
                    name = "Giang",
                    gender = Gender.Female,
                    DOB = null//Convert.ToDateTime("1998-03-10")
                }
            };
            
            //ViewData["People"] = people;
            //ViewBag.People = people;
            //return new ViewResult() { ViewName = "" };
            return View(_persons);
        }

        [Route("persion-details/{name}")]
        public IActionResult Details(string? name){
            if(string.IsNullOrEmpty(name)){
                return Content("Person name cannot be null");
            }

            List<Person> _persons = new List<Person>()
            {
                new Person(){
                    name = "Peace",
                    gender = Gender.Male,
                    DOB = Convert.ToDateTime("1992-06-18")
                },
                new Person(){
                    name = "Giang",
                    gender = Gender.Female,
                    DOB = null//Convert.ToDateTime("1998-03-10")
                }
            };

            var person = _persons.FirstOrDefault(x => x.name == name);
            if(person == null){
                return Content("This person name is not existing");
            }
            return View(person);
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct(){
            Person person = new Person(){
                name = "Peace",
                gender = Gender.Male,
                DOB = Convert.ToDateTime("1992-06-18")
            };
            Product product = new Product(){
                ProductId = 1,
                ProductName = "iPhone 14 Pro"
            };

            PersonAndProductWrapperModel viewModel = new PersonAndProductWrapperModel();
            viewModel.PersonData = person;
            viewModel.ProductData = product;

            return View(viewModel);
        }

        [Route("home/all-products")]
        public IActionResult All()
        {
            return View();
            //if cannot file in views/home then will find in views/shared
        }
    }
}