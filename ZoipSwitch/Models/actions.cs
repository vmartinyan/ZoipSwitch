using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("actions", Schema = "public")]
    public class actions
    {
        [Key]
        public int action_id { get; set; }

        [ForeignKey("cases")]
        [Display(Name = "Case")]
        public int case_id { get; set; }
        public cases cases { get; set; }

        [Display(Name = "Operator")]
        public int operator_id { get; set; }

        [Display(Name = "Category")]
        public int action_category_id { get; set; }

        [Display(Name = "Type")]
        public int action_type_id { get; set; }

        [Display(Name = "Status")]
        public int action_status_id { get; set; }

        [Display(Name = "Resident")]
        public int resident_id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [Display(Name = "File")]
        public string file { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }
    }
}