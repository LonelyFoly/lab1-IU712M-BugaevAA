namespace Lab1
{
    public class Person
    {
        

        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string work { get; set; }
        public int age { get; set; }

        public Person(int id = 0, string name = "",
            string address = "", string work = "", int age = 0)
        {
            this.name = name;
            this.id = id;
            this.address = address;
            this.work = work;
            this.age = age;
        }
    }
    public class PersonUpdateDto
    {
        public string name { get; set; }
        public string address { get; set; }
        public string work { get; set; }
        public int age { get; set; }
        public PersonUpdateDto(string name ="",
            string address = "", string work = "", int age = 0)
        {
            this.name = name;
            this.address = address;
            this.work = work;
            this.age = age;
        }
    }
}
