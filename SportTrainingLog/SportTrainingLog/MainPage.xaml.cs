using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SportTrainingLog
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            SessionLogView.RefreshCommand = new Command(RefreshMethod);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            SessionLogView.ItemsSource = await App.Database.GetSessionsAsync();
        }

        public async void RefreshMethod()
        {
            SessionLogView.ItemsSource = await App.Database.GetSessionsAsync();
            SessionLogView.IsRefreshing = false;
        }
        
        private async void SessionListItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new SessionDetailPage { BindingContext = e.Item as Session });
        }
        
        public async void DetailsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SessionDetailPage { BindingContext = (sender as MenuItem).BindingContext as Session });
        }

        private async void DeleteClicked(object sender, EventArgs e)
        {
            Session sessionToDelete = (sender as MenuItem).BindingContext as Session;
            await App.Database.DeleteSessionAsync(sessionToDelete);
            SessionLogView.ItemsSource = await App.Database.GetSessionsAsync();
        }
    }
}
