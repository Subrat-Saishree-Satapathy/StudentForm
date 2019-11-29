using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentForm.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Addresslocation { get; set; }
        public int Pincode { get; set; }
        public int StudentID { get; set; }
        //[ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}

