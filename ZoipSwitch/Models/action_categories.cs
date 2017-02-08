using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("action_categories", Schema = "public")]
    public class action_categories
    {
        [Key]
        public int action_category_id { get; set; }

        public string action_category_name { get; set; }
    }
}