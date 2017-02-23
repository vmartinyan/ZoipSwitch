using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("vwCases", Schema = "public")]
    public class vwCases
    {
        [Key]
        public int case_id { get; set; }

        [Display(Name = "Action")]
        public int action_id { get; set; }

        [Display(Name = "Status")]
        public int case_status_id { get; set; }
        [Display(Name = "Status")]
        public string case_status_name { get; set; }

        [Display(Name = "Type")]
        public int case_type_id { get; set; }
        [Display(Name = "Type")]
        public string case_type_name { get; set; }

        [Display(Name = "Urgency")]
        public int case_urgency_id { get; set; }
        [Display(Name = "Urgency")]
        public string case_urgency_name { get; set; }

        [Display(Name = "Department")]
        public int case_department_id { get; set; }
        [Display(Name = "Department")]
        public string case_department_name { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime start_date { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime end_date { get; set; }

        [Display(Name = "Creator Operator")]
        public string creator_operator_name { get; set; }

        [Display(Name = "Completing Operator")]
        public string completing_operator_name { get; set; }
    }
}