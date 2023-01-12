using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Eduard_Sergiu_Android.Models
{
    public class BreakfastPlan
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(typeof(Breakfast))]
        public int BreakfastID { get; set; }
    }
}
