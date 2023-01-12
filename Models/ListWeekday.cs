using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Eduard_Sergiu_Android.Models
{
    public class ListWeekday
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(BreakfastPlan))]
        public int BreakfastPlanID { get; set; }
        public int WeekDayID { get; set; }
    }
}
