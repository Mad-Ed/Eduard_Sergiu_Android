using Eduard_Sergiu_Android.Models;

namespace Eduard_Sergiu_Android;

public partial class BreakfastEntryPage : ContentPage
{
	public BreakfastEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        planView.ItemsSource = await App.Database.GetBreakfastsAsync();
    }
    async void OnBreakfastAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BreakfastPage
        {
            BindingContext = new Breakfast()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new BreakfastPage
            {
                BindingContext = e.SelectedItem as Breakfast
            });
        }
    }
}