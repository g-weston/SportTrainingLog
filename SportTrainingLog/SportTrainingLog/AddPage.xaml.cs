using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportTrainingLog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void ClearInput()
        {
            SessionDatePicker.Date = DateTime.Now;
            EntrySessionName.Text = null;
            EditorSessionDetails.Text = null;
        }
        private void CancelClicked(object sender, EventArgs e)
        {
            ClearInput();
        }
        private async void AddClicked(object sender, EventArgs e)
        {
            DateTime sessionDate = SessionDatePicker.Date;
            string sessionName = EntrySessionName.Text;
            string sessionDetails = EditorSessionDetails.Text;

            var session = new Session
            {
                SessionDate = sessionDate,
                SessionTitle = sessionName,
                SessionDetails = sessionDetails
            };
            await App.Database.SaveSessionAsync(session);
            //await Navigation.PopAsync();
            await DisplayAlert("Your session has been added", null, "Ok");

            ClearInput();
        }

        
    }
}