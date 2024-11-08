using FluentAssertions;
using Lab1;
using Lab1.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace personTesting
{
    public class UnitTest1
    {

        private DbContextOptions<ApplicationContext> CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;

            return options;
        }
        int maxIndex = 0;
        public int findMaxIndex()
        {
            var option = CreateInMemoryContext();
            dbHandler handler = new dbHandler(option);
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
            var option = CreateInMemoryContext();
            dbHandler handler = new dbHandler(option);
            //
            int id = findMaxIndex()+2;
            string check_Name = "Joe";
            handler.addPerson(new Person(id, check_Name));
            //


            var person = handler.getPerson(id);
            person.name.Should().Be(check_Name);
            person.id.Should().Be(id);

            handler.removePerson(id);
        }

        [Fact]
        public void GetPersons()
        {
            var option = CreateInMemoryContext();
            dbHandler handler = new dbHandler(option);
            //
            int id = findMaxIndex() + 3;
            string check_Name = "Joe";
            handler.addPerson(new Person(id, check_Name));
            //
            //var person = new Person[] { new Person { id = 1, name = "John Doe" }, new Person { id = 2, name = "Joe Peach" } };
            var persons = handler.getPersons();

            persons.Length.Should().BeGreaterThanOrEqualTo(1);

            handler.removePerson(id);
        }
        [Fact]
        public void PostPerson()
        {
            var option = CreateInMemoryContext();
            dbHandler handler = new dbHandler(option);
            //
            int id = findMaxIndex() + 4;
            string check_Name = "Joe";
            handler.addPerson(new Person(id, check_Name));
            //


            var person = handler.getPerson(id);
            person.name.Should().Be(check_Name);
            person.id.Should().Be(id);

            handler.removePerson(id);
        }
        [Fact]
        public void DeletePerson()
        {
            var option = CreateInMemoryContext();
            dbHandler handler = new dbHandler(option);
            //
            int id = findMaxIndex() + 5;
            string check_Name = "Joe";
            handler.addPerson(new Person(id, check_Name));
            //
            handler.removePerson(id).Should().Be(true);
            handler.removePerson(id).Should().Be(false);

        }
        [Fact]
        public void PatchPerson()
        {

            var option = CreateInMemoryContext();
            dbHandler handler = new dbHandler(option);
            //
            int id = findMaxIndex() + 6;
            string check_Name = "Joe";
            Person old_person = new Person(id, check_Name);
            
            handler.addPerson(old_person);

            PersonUpdateDto person = new PersonUpdateDto("Jail");
            handler.updatePerson(person, id);
            Person check_person = handler.getPerson(id);

            check_person.id.Should().Be(id);
            check_person.name.Should().Be("Jail");

            handler.removePerson(id);
            handler.updatePerson(person, id).Should().Be(false);
        }
    }
}