using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("vwAction", Schema = "public")]
    public class vwAction
    {
        [Key]
        public int action_id { get; set; }

        public int case_id { get; set; }

        [Display(Name = "Operator")]
        public int operator_id { get; set; }
        [Display(Name = "Operator Name")]
        public string name { get; set; }
        [Display(Name = "Operator Lastname")]
        public string lastname { get; set; }
        [Display(Name = "Operator Ext")]
        public string extension { get; set; }
        

        [Display(Name = "Category")]
        public int action_category_id { get; set; }
        [Display(Name = "Category")]
        public string action_category_name { get; set; }


        [Display(Name = "Type")]
        public int action_type_id { get; set; }
        [Display(Name = "Type")]
        public string action_type_name { get; set; }


        [Display(Name = "Status")]
        public int action_status_id { get; set; }
        [Display(Name = "Status")]
        public string action_status_name { get; set; }


        [Display(Name = "Resident")]
        public int resident_id { get; set; }
        [Display(Name = "Resident Name")]
        public string resident_name { get; set; }
        [Display(Name = "Resident Lastname")]
        public string resident_lastname { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [Display(Name = "File")]
        public string file { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }
    }
}