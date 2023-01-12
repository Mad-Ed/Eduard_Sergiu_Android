using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Eduard_Sergiu_Android.Models
{
    public class BreakfastPlan
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
