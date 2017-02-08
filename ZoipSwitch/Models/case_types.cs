using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("case_types", Schema = "public")]
    public class case_types
    {
        [Key]
        public int case_type_id { get; set; }

        public string case_type_name { get; set; }
    }
}