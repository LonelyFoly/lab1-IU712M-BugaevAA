using FluentAssertions;
using Lab1;
using Lab1.DB;
using Microsoft.AspNetCore.Mvc;

namespace personTesting
{
    public class UnitTest1
    {
        int maxIndex = 0;
        public int findMaxIndex()
        {
            dbHandler handler = new dbHandler();
            var Persons = handler.getPersons();
            foreach (Person u in Persons)
            {
                if (u.id > maxIndex)
                {
                    maxIndex = u.id;
                }
            }
            return maxIndex;
        }

        [Fact]
        public void GetPerson()
        {
            dbHandler handler = new dbHandler();
            //
            int id = findMaxIndex()+2;
            string check_Name = "Joe";
            string check_Address = "C";
            string check_Work = "Company1";
            int check_Age = 33;
            handler.addPerson(new Person(id, check_Name, check_Address, check_Work,
                check_Age));
            //


            var person = handler.getPerson(id);
            person.name.Should().Be(check_Name);
            person.id.Should().Be(id);

            handler.removePerson(id);
        }

        [Fact]
        public void GetPersons()
        {
            dbHandler handler = new dbHandler();
            //
            int id = findMaxIndex() + 3;
            string check_Name = "Joe";
            string check_Address = "C";
            string check_Work = "Company1";
            int check_Age = 33;
            handler.addPerson(new Person(id, check_Name, check_Address, check_Work,
                check_Age));
            //
            //var person = new Person[] { new Person { id = 1, name = "John Doe" }, new Person { id = 2, name = "Joe Peach" } };
            var persons = handler.getPersons();

            persons.Length.Should().BeGreaterThanOrEqualTo(1);

            handler.removePerson(id);
        }
        [Fact]
        public void PostPerson()
        {
            dbHandler handler = new dbHandler();
            //
            int id = findMaxIndex() + 4;
            string check_Name = "Joe";
            string check_Address = "C";
            string check_Work = "Company1";
            int check_Age = 33;
            handler.addPerson(new Person(id, check_Name, check_Address, check_Work,
                check_Age));
            //


            var person = handler.getPerson(id);
            person.name.Should().Be(check_Name);
            person.id.Should().Be(id);

            handler.removePerson(id);
        }
        [Fact]
        public void DeletePerson()
        {
            dbHandler handler = new dbHandler();
            //
            int id = findMaxIndex() + 5;
            string check_Name = "Joe";
            string check_Address = "C";
            string check_Work = "Company1";
            int check_Age = 33;
            handler.addPerson(new Person(id, check_Name, check_Address, check_Work,
                check_Age));
            //
            handler.removePerson(id).Should().Be(true);
            handler.removePerson(id).Should().Be(false);

        }
        [Fact]
        public void PatchPerson()
        {
            
            dbHandler handler = new dbHandler();
            //
            int id = findMaxIndex() + 6;
            string check_Name = "Joe";
            string check_Address = "C";
            string check_Work = "Company1";
            int check_Age = 33;
            Person old_person = new Person(id, check_Name, check_Address, check_Work,
                check_Age);
            
            handler.addPerson(old_person);

            PersonUpdateDto person = new PersonUpdateDto("Jail", "a","w",3);
            handler.updatePerson(person, id);
            Person check_person = handler.getPerson(id);

            check_person.id.Should().Be(id);
            check_person.name.Should().Be("Jail");
            check_person.age.Should().Be(3);

            handler.removePerson(id);
        }
    }
}