using System;

namespace Registration.Entities
{
    public class Register
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public Profession Profession { get; set; }
        public string Locality { get; set; }
        public int NoOfGuest { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }

    public enum Profession
    {
        Employed = 1,
        Student = 2
    }
}
