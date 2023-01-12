using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduard_Sergiu_Android.Models
{
    public class Breakfast
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string BreakfastName { get; set; }
        public string Adress { get; set; }
        public string BreakfastDetails
        {
            get
            {
                return BreakfastName + ""+Adress;} }
        [OneToMany]
 public List<BreakfastPlan> BreakfastPlans { get; set; }
    }
}
