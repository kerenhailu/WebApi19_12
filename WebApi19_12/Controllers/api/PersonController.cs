using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi19_12.Models;

namespace WebApi19_12.Controllers.api
{
    public class PersonController : Controller
    {

        //[EnableCors("*,*,*,*")]
        // GET: Person

            List<Person> people = new List<Person>();
        public void PopPeople()
        {
            Person person1 = new Person("keren", "hailu", 22, "keren@");
            Person person2 = new Person("eden", "genet", 25, "eden@");
            Person person3 = new Person("tikva", "yosef", 27, "tikva@");
            Person person4 = new Person("yafit", "smuel", 29, "yafit@");
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);  
        }
        public ActionResult Index()
        {
            PopPeople();
            return Json(people, JsonRequestBehavior.AllowGet);
        }
        
        //GET: Person/Details/5
        public ActionResult Details(int id)
        {
            //תשובה טובה
            //Person person =people.Find(x => x.Id == id);
            //return Json(person, JsonRequestBehavior.AllowGet);

            PopPeople();
            
            //return Json(people[id], JsonRequestBehavior.AllowGet);
            for(int i = 0; i < people.Count; i++)
            {
                if(people[i].Id == id)
                {
                    return Json(people[id], JsonRequestBehavior.AllowGet);
                }
            }
            return Json("not good id", JsonRequestBehavior.AllowGet);

        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //CreateNewPerson();
                //PopPeople();
                people.Add(
                    new Person(collection["Name"],
                    collection["Lname"],
                   int.Parse(collection["Age"]),
                    collection["Email"]));

                return Json("good", JsonRequestBehavior.AllowGet);
            }
            catch
            {

                return Json("not work", JsonRequestBehavior.AllowGet);

                //return View();
            }
        }

        // Put: Person/Edit/5
        [HttpPut]
        public ActionResult Edit(int id, Person personFromUser)
        {
            try
            {
                // TODO: Add update logic here

                //return RedirectToAction("Index");

                for (int i = 0;i < people.Count; i++)
                {
                    if(personFromUser.Id == id)
                    {
                        personFromUser.Name = people[i].Name;
                        personFromUser.Lname = people[i].Lname;
                        personFromUser.Age = people[i].Age;
                        personFromUser.Email = people[i].Email;
                        return Json("gooddddd", JsonRequestBehavior.AllowGet);
                    }
                }
                return Json("not gooddd", JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return Json("person not edited", JsonRequestBehavior.AllowGet);

            }
        }


        public void DeletePeople(int index)
        {
            PopPeople();
            people.RemoveAt(index);

        }

        // Delete: Person/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            //DeletePeople(2);


            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Id == id)
                {
                    people.RemoveAt(i);
                    return Json("work", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("notttt work", JsonRequestBehavior.AllowGet);

        }
    }
}
