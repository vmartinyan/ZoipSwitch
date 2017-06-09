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
        public string resident { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$", ErrorMessage = "Not a valid Phone number")]
        public string phone { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [Display(Name = "File")]
        public string file { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }
    }
}