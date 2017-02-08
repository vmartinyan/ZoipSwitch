using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("case_statuses", Schema = "public")]
    public class case_statuses
    {
        [Key]
        public int case_status_id { get; set; }

        public string case_status_name { get; set; }
    }
}