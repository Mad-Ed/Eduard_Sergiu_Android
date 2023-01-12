using Eduard_Sergiu_Android.Models;

namespace Eduard_Sergiu_Android;

public partial class WeekDayPage : ContentPage
{
    BreakfastPlan bp;
    public WeekDayPage(BreakfastPlan bplan)
	{
		InitializeComponent();
        bp = bplan;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var weekday = (WeekDay)BindingContext;
        await App.Database.SaveWeekDayAsync(weekday);

        planView.ItemsSource = await App.Database.GetWeekDayAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var weekday = (WeekDay)BindingContext;
        await App.Database.DeleteWeekDayAsync(weekday);
        planView.ItemsSource = await App.Database.GetWeekDayAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        planView.ItemsSource = await App.Database.GetWeekDayAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        WeekDay p;
        if (planView.SelectedItem != null)
        {
            p = planView.SelectedItem as WeekDay;
            var lp = new ListWeekday()
            {
                BreakfastPlanID = bp.ID,
                WeekDayID = p.ID
            };
            await App.Database.SaveListWeekdayAsync(lp);
            p.ListWeekdays = new List<ListWeekday> { lp };
            await Navigation.PopAsync();
        }


    }
   
}