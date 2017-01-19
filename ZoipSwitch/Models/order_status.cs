using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("order_status", Schema = "public")]
    public class order_status
    {
        [Key]
        public int order_status_flags { get; set; }

        public string order_status_text { get; set; }
    }
}