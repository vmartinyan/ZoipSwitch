using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZoipSwitch.Models
{
    [Table("agents", Schema = "public")]
    public class agents
    {
        [Key]
        public string name { get; set; }
        public string system { get; set; }
        public string uuid { get; set; }
        public string type { get; set; }
        public string contact { get; set; }
        public string status { get; set; }
        public string state { get; set; }
        public int max_no_answer { get; set; }
        public int wrap_up_time { get; set; }
        public int reject_delay_time { get; set; }
        public int busy_delay_time { get; set; }
        public int no_answer_delay_time { get; set; }
        public int last_bridge_start { get; set; }
        public int last_bridge_end { get; set; }
        public int last_offered_call { get; set; }
        public int last_status_change { get; set; }
        public int no_answer_count { get; set; }
        public int calls_answered { get; set; }
        public int talk_time { get; set; }
        public int ready_time { get; set; }

    }
}