using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Views_Web.Models
{
    public class Person
    {
        public string? name { get; set; }
        public DateTime? DOB { get; set; }
        public Gender gender { get; set; }
    }

    public enum Gender{
        Male, Female, Other
    }
}