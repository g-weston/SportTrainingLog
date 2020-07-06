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
            SessionDatePicker.Date = DateTimeOffset.Now.Date;
            SessionTimePicker.Time = DateTimeOffset.Now.TimeOfDay;
        }

        private void ClearInput()
        {
            SessionDatePicker.Date = DateTimeOffset.Now.Date;
            SessionTimePicker.Time = DateTimeOffset.Now.TimeOfDay;
            EntrySessionName.Text = null;
            EditorSessionDetails.Text = null;
        }
        private void CancelClicked(object sender, EventArgs e)
        {
            ClearInput();
        }
        private async void AddClicked(object sender, EventArgs e)
        {
            DateTimeOffset sessionDateTimeOffset = SessionDatePicker.Date + SessionTimePicker.Time;
            string sessionDateTimeOffsetString = sessionDateTimeOffset.ToString("dd/MM/yyyy HH:mm");
            string sessionName = EntrySessionName.Text;
            string sessionDetails = EditorSessionDetails.Text;

            var session = new Session
            {
                SessionDateTimeOffset = sessionDateTimeOffset,
                SessionDateTimeOffsetString = sessionDateTimeOffsetString,
                SessionTitle = sessionName,
                SessionDetails = sessionDetails
            };
            await App.Database.SaveSessionAsync(session);
            await DisplayAlert("Your session has been added", null, "Ok");

            ClearInput();
        }

        
    }
}