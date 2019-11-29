using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentForm.Models
{
    public class Student
    {
       [Key]
        public int StudentID { get; set; }

        public string StudentName { get; set; }
        public List<Address> Address { get; set; }
    }
}
