using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("residents", Schema = "public")]
    public class residents
    {
        [Key]
        public int resident_id { get; set; }

        [Display(Name = "Name")]
        public string resident_name { get; set; }

        [Display(Name = "Lastname")]
        public string resident_lastname { get; set; }

        [Display(Name = "Birth Date")]
        public DataType resident_birthdate { get; set; }

        [Display(Name = "Phone")]
        public string resident_phone { get; set; }

        [Display(Name = "Email")]
        public string resident_email { get; set; }
    }
}