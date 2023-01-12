using System;
using Eduard_Sergiu_Android.Data;
using System.IO;


namespace Eduard_Sergiu_Android;

public partial class App : Application
{
    static BreakfastPlanDatabase database;
    public static BreakfastPlanDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               BreakfastPlanDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ShoppingList.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
