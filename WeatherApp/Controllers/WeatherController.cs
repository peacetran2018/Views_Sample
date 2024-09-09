using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            List<WeatherModel> weatherList = new List<WeatherModel>()
            {
                new WeatherModel(){
                    CityUniqueCode = "VN",
                    CityName = "Vietnam",
                    DateAndTime = DateTime.Now,
                    Temperature = 33
                },
                new WeatherModel(){
                    CityUniqueCode = "SG",
                    CityName = "Singapore",
                    DateAndTime = DateTime.Now,
                    Temperature = 45
                },
                new WeatherModel(){
                    CityUniqueCode = "AU",
                    CityName = "Australia",
                    DateAndTime = DateTime.Now,
                    Temperature = 80
                }
            };

            return View(weatherList);
        }

        [Route("details/{id}")]
        public IActionResult Details(string id){
            if(string.IsNullOrEmpty(id)){
                return Content("City Unique Code cannot be empty");
            }
            List<WeatherModel> weatherList = new List<WeatherModel>()
            {
                new WeatherModel(){
                    CityUniqueCode = "VN",
                    CityName = "Vietnam",
                    DateAndTime = DateTime.Now,
                    Temperature = 33
                },
                new WeatherModel(){
                    CityUniqueCode = "SG",
                    CityName = "Singapore",
                    DateAndTime = DateTime.Now,
                    Temperature = 45
                },
                new WeatherModel(){
                    CityUniqueCode = "AU",
                    CityName = "Australia",
                    DateAndTime = DateTime.Now,
                    Temperature = 80
                }
            };

            var city = weatherList.FirstOrDefault(x => x.CityUniqueCode == id);
            if(city == null){
                return Content("This city is not existing");
            }

            return View(city);
        }
    }
}