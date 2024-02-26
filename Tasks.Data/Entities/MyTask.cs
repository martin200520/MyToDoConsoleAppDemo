using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Data.Entities
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        [DefaultValue(false)]
        public bool isCompleted { get; set; }
    }
}
