﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.DB
{
    public class dbHandler
    {
        public void addPersons(Person[] persons)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.person.AddRange(persons);
                db.SaveChanges();
            }

        }
        public void addPerson(Person person)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.person.Add(person);
                db.SaveChanges();
            }

        }
        public bool updatePerson(PersonUpdateDto person, int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Person this_person = null ;
                var Persons = db.person.ToList();
                foreach (Person u in Persons)
                {
                    if (u.id == id)
                    {
                        this_person = u;
                        break;
                    }
                }
                if (this_person != null)
                {
                    //this_person.id = person.id;
                    this_person.name = person.name;

                    db.person.Update(this_person);
                    db.SaveChanges();

                }
                return this_person != null;


            }

        }


        public bool removePerson(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var Persons = db.person.ToList();
                Person person = null;
                foreach (Person u in Persons)
                {
                    if (u.id == id)
                        person =  u;
                }

                bool cond = person != null;
                if (cond)
                {
                    db.person.Remove(person);
                    db.SaveChanges();
                }

                return cond;
            }

        }
        public Person[] getPersons()
        {
            // получение данных
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var Persons = db.person.ToList();
                //Console.WriteLine("Persons list:");
                List<Person> persons = new List<Person>();
                foreach (Person u in Persons)
                {
                    persons.Add(u);
                    
                }
                return persons.ToArray();
            }
        }
        public Person getPerson(int id)
        {
            // получение данных
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var Persons = db.person.ToList();
                //Console.WriteLine("Persons list:");
                List<Person> persons = new List<Person>();
                foreach (Person u in Persons)
                {
                    if (u.id == id)
                        return u;

                }
                return null;
            }
        }



    }
}

