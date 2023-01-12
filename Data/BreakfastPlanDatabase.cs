using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using Eduard_Sergiu_Android.Models;
//using static Android.Icu.Util.Calendar;


namespace Eduard_Sergiu_Android.Data
{
    public class BreakfastPlanDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public BreakfastPlanDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<BreakfastPlan>().Wait();
            _database.CreateTableAsync<WeekDay>().Wait();
            _database.CreateTableAsync<ListWeekday>().Wait();
            _database.CreateTableAsync<Breakfast>().Wait();
        }
        public Task<List<BreakfastPlan>> GetBreakfastPlanAsync()
        {
            return _database.Table<BreakfastPlan>().ToListAsync();
        }
        public Task<BreakfastPlan> GetBreakfastPlanAsync(int id)
        {
            return _database.Table<BreakfastPlan>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveBreakfastPlanAsync(BreakfastPlan bplan)
        {
            if (bplan.ID != 0)
            {
                return _database.UpdateAsync(bplan);
            }
            else
            {
                return _database.InsertAsync(bplan);
            }
        }
        public Task<int> DeleteBreakfastPlanAsync(BreakfastPlan bplan)
        {
            return _database.DeleteAsync(bplan);
        }
        public Task<int> SaveWeekDayAsync(WeekDay weekday)
        {
            if (weekday.ID != 0)
            {
                return _database.UpdateAsync(weekday);
            }
            else
            {
                return _database.InsertAsync(weekday);
            }
        }
        public Task<int> DeleteWeekDayAsync(WeekDay weekday)
        {
            return _database.DeleteAsync(weekday);
        }
        public Task<List<WeekDay>> GetWeekDayAsync()
        {
            return _database.Table<WeekDay>().ToListAsync();
        }
        public Task<int> SaveListWeekdayAsync(ListWeekday listw)
        {
            if (listw.ID != 0)
            {
                return _database.UpdateAsync(listw);
            }
            else
            {
                return _database.InsertAsync(listw);
            }
        }
        public Task<List<WeekDay>> GetListWeekdayAsync(int breakfastplanid)
        {
            return _database.QueryAsync<WeekDay>(
            "select P.ID, P.Description from WeekDay P"
            + " inner join ListWeekday BP"
            + " on P.ID = BP.WeekDayID where BP.BreakfastPlanID = ?",
            breakfastplanid);
        }
        public Task<int> DeleteListWeekdayAsync(ListWeekday listw)
        {
            return _database.DeleteAsync(listw);
        }
        public Task<List<ListWeekday>> GetListWeekday()
        {
            return _database.QueryAsync<ListWeekday>("select * from ListWeekday");
        }
        public Task<List<Breakfast>> GetBreakfastsAsync()
        {
            return _database.Table<Breakfast>().ToListAsync();
        }
        public Task<int> SaveBreakfastAsync(Breakfast breakfast)
        {
            if (breakfast.ID != 0)
            {
                return _database.UpdateAsync(breakfast);
            }
            else
            {
                return _database.InsertAsync(breakfast);
            }
        }
    }
}
    
