using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentForm.Models
{
    public class Viewmodel
    {
        [Key]
        public int StudentID { get; set; }

        
        
        [Required(ErrorMessage = "Enter Student Name")]
        [StringLength(50, ErrorMessage = "Only 10 character are allowed")]
        public string StudentName { get; set; }
        [Required]
        public string Addresslocation { get; set; }
        [Required]
        public int Pincode { get; set; }
       


    }
}
