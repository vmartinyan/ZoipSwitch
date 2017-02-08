using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("case_departments", Schema = "public")]
    public class case_departments
    {
        [Key]
        public int case_department_id { get; set; }

        public string case_department_name { get; set; }
    }
}