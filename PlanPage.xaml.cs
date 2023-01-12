using Eduard_Sergiu_Android.Models;

namespace Eduard_Sergiu_Android;

public partial class PlanPage : ContentPage
{
    
	public PlanPage()
	{
		InitializeComponent();
        
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var bplan = (BreakfastPlan)BindingContext;
        bplan.Date = DateTime.UtcNow;
        await App.Database.SaveBreakfastPlanAsync(bplan);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var bplan = (BreakfastPlan)BindingContext;
        await App.Database.DeleteBreakfastPlanAsync(bplan);
        await Navigation.PopAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var breakfastp = (BreakfastPlan)BindingContext;

        planView.ItemsSource = await App.Database.GetListWeekdayAsync(breakfastp.ID);
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WeekDayPage((BreakfastPlan)
       this.BindingContext)
        {
            BindingContext = new WeekDay()
        });

    }
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        WeekDay weekday;
        var breakfastPlan = (BreakfastPlan)BindingContext;
        if (planView.SelectedItem != null)
        {
            weekday = planView.SelectedItem as WeekDay;

            var listWeekdayAll = await App.Database.GetListWeekday();
            var listWeekday = listWeekdayAll.FindAll(x => x.WeekDayID == weekday.ID & x.BreakfastPlanID == breakfastPlan.ID);

            await App.Database.DeleteListWeekdayAsync(listWeekday.FirstOrDefault());
            await Navigation.PopAsync();

        }
    }

}