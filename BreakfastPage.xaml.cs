using Eduard_Sergiu_Android.Models;
using Plugin.LocalNotification;

namespace Eduard_Sergiu_Android;

public partial class BreakfastPage : ContentPage
{
	public BreakfastPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var breakfast = (Breakfast)BindingContext;
        await App.Database.SaveBreakfastAsync(breakfast);

        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var breakfast = (Breakfast)BindingContext;
        var address = breakfast.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "My favorite restaurant" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        var distance = myLocation.CalculateDistance(location,
DistanceUnits.Kilometers);
        if (distance < 50)
        {
            var request = new NotificationRequest
            {
                Title = "Ai putea manca la un restaurant in apropiere!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
        await Map.OpenAsync(location, options);
    }

}