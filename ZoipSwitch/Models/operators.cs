using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("operators", Schema = "public")]
    public class operators
    {
        [Key]
        public int operator_id { get; set; }

        [Display(Name = "Extension")]
        public string extension { get; set; }

        [NotMapped]
        [Display(Name = "Extension")]
        public string ext {
        get {
                string ex = extension.Substring(0, extension.IndexOf("@"));
                return ex;
            }
        set { extension = value; }
        }

        [NotMapped]
        [Display(Name = "Operator")]
        public string operatoe_name
        {
            get
            {
                string operator_nm = name + " " + lastname;
                return operator_nm;
            }
            set { operatoe_name = value; }
        }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Lastname")]
        public string lastname { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime birthdate { get; set; }

        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }
    }
}