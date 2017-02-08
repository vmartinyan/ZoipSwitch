using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("action_statuses", Schema = "public")]
    public class action_statuses
    {
        [Key]
        public int action_status_id { get; set; }

        public string action_status_name { get; set; }
    }
}