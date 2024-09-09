using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherModel
    {
        public string? CityUniqueCode { get; set; }
        public string? CityName { get; set; }
        public DateTime DateAndTime { get; set; }
        public int Temperature { get; set; }
    }
}