using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("action_types", Schema = "public")]
    public class action_types
    {
        [Key]
        public int action_type_id { get; set; }

        public string action_type_name { get; set; }
    }
}