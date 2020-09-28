using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _003_RazorPages_Basics.Pages.Sample001
{
    public class RazorReferencePageModel : PageModel
    {
        public string Username { get; set; }

        public Person[] People { get; set; }

        public int MyProperty { get; set; }

        public void OnGet()
        {
            Username = "Max Mustermann";
            People = new Person[] { new Person("Max", 21), new Person("Sandra", 23), new Person("Andre", 41) };
        }

        public string DieAntwortAufAlles()
        {
            
            return "42";
        }

        public bool AllesSupi()
        { 
            return true;
        }
    }


    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}