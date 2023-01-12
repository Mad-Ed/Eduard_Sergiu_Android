using Eduard_Sergiu_Android.Models;

namespace Eduard_Sergiu_Android;

public partial class PlanEntryPage : ContentPage
{
    public PlanEntryPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        planView.ItemsSource = await App.Database.GetBreakfastPlanAsync();
    }
    async void OnBreakfastPlanAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PlanPage
        {
            BindingContext = new BreakfastPlan()
        });
    }
    async void OnPlanViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new PlanPage
            {
                BindingContext = e.SelectedItem as BreakfastPlan
            });
        }
    }
    
    
}