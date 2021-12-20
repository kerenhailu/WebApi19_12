using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi19_12.Models
{
        public class Person
        {
            //string name;
            //string lname;
            //int age;
            //string email;
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Lname { get; set; }
            public string Email { get; set; }
        int counter = 0;
      public Person() { }
            public Person(string name, string lname, int age, string email)
            {
                this.Id=counter++;
                this.Name = name;
                this.Lname = lname;
                this.Age = age;
                this.Email = email;
            }
        
        }
    }
