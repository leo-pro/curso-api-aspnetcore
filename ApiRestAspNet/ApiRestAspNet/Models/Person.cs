using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestAspNet.Models
{
    public class Person
    {
        public long id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string gender { get; set; }

        public Person()
        {
        }

        public Person(long _id, string _firstName, string _lastName, string _address, string _gender)
        {
            id = _id;
            firstname = _firstName;
            lastname = _lastName;
            address = _address;
            gender = _gender;
        }
    }
}
