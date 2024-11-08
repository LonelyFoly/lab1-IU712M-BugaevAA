namespace Lab1
{
    public class Person
    {
        public string name { get; set; }

        public int id { get; set; }

        public Person(int id, string name)
        {
            this.name = name;
            this.id = id;
        }
    }
    public class PersonUpdateDto
    {
        public string name { get; set; }
        public PersonUpdateDto(string name)
        {
            this.name = name;
        }
    }
}
