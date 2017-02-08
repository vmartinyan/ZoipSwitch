using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("case_urgencies", Schema = "public")]
    public class case_urgencies
    {
        [Key]
        public int case_urgency_id { get; set; }

        public string case_urgency_name { get; set; }
    }
}