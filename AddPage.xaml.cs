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
        private void AddClicked(object sender, EventArgs e)
        {
            DateTime sessionDate = SessionDatePicker.Date;
            string sessionName = EntrySessionName.Text;
            string sessionDetails = EditorSessionDetails.Text;
            DisplayActionSheet("Details", null, "ok", sessionDate.ToLongDateString() ,sessionName, sessionDetails);
            
            SessionLog.SessionsLogList.Add(new Session(sessionDate, sessionName, sessionDetails));

            ClearInput();
        }

        
    }
}