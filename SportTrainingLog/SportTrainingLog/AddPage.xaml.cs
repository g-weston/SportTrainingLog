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
            EntrySessionLength.Text = "0";
            BattingDetailsBallsFacedEntry.Text = "0";
            BowlingDetailsBallsBowledEntry.Text = "0";
            FieldingDetailsBallsFieldedEntry.Text = "0";
        }
        
        private void ClearInput()
        {
            SessionDatePicker.Date = DateTimeOffset.Now.Date;
            SessionTimePicker.Time = DateTimeOffset.Now.TimeOfDay;
            EntrySessionName.Text = null;
            EditorSessionDetails.Text = null;
            EntrySessionLength.Text = "0";
            BattingDetailsSkillsWorkedEditor.Text = null;
            BattingDetailsSkillsToWorkOnEditor.Text = null;
            BattingDetailsBallsFacedEntry.Text = "0";
            BowlingDetailsSkillsWorkedEditor.Text = null;
            BowlingDetailsSkillsToWorkOnEditor.Text = null;
            BowlingDetailsBallsBowledEntry.Text = "0";
            FieldingDetailsSkillsWorkedEditor.Text = null;
            FieldingDetailsSkillsToWorkOnEditor.Text = null;
            FieldingDetailsBallsFieldedEntry.Text = "0";
            FitnessSessionDetailsEditor.Text = null;
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
            int sessionLength = int.Parse(EntrySessionLength.Text);
            string battingSessionSkillsWorked = BattingDetailsSkillsWorkedEditor.Text;
            string battingSessionSkillsToWorkOn = BattingDetailsSkillsToWorkOnEditor.Text;
            // below implement checking for entries that arent numbers 
            int battingSessionBallsFaced = int.Parse(BattingDetailsBallsFacedEntry.Text);
            string bowlingSessionSkillsWorked = BowlingDetailsSkillsWorkedEditor.Text;
            string bowlingSessionSkillsToWorkOn = BowlingDetailsSkillsToWorkOnEditor.Text;
            int bowlingSessionBallsBowled = int.Parse(BowlingDetailsBallsBowledEntry.Text);
            string fieldingSessionSkillsWorked = FieldingDetailsSkillsWorkedEditor.Text;
            string fieldingSessionSkillsToWorkOn = FieldingDetailsSkillsToWorkOnEditor.Text;
            int fieldingSessionBallsFielded = int.Parse(FieldingDetailsBallsFieldedEntry.Text);
            string fitnessSessionDetails = FitnessSessionDetailsEditor.Text;
            bool isBattingSession = (battingSessionSkillsWorked != null) || (battingSessionSkillsToWorkOn != null) || (battingSessionBallsFaced != 0);
            bool isBowlingSession = (bowlingSessionSkillsWorked != null) || (bowlingSessionSkillsToWorkOn != null) || (bowlingSessionBallsBowled != 0);
            bool isFieldingSession = (fieldingSessionSkillsWorked != null) || (fieldingSessionSkillsToWorkOn != null) || (fieldingSessionBallsFielded != 0);
            bool isCricketSession = (isBattingSession || isBowlingSession || isFieldingSession);
            bool isFitnessSession = (fitnessSessionDetails != null);

            var session = new Session
            {
                SessionDateTimeOffset = sessionDateTimeOffset,
                SessionDateTimeOffsetString = sessionDateTimeOffsetString,
                SessionTitle = sessionName,
                SessionDetails = sessionDetails,
                SessionLength = sessionLength,
                BattingSessionSkillsWorked = battingSessionSkillsWorked,
                BattingSessionSkillsToWorkOn = battingSessionSkillsToWorkOn,
                BattingSessionBallsFaced = battingSessionBallsFaced,
                BowlingSessionSkillsWorked = bowlingSessionSkillsWorked,
                BowlingSessionSkillsToWorkOn = bowlingSessionSkillsToWorkOn,
                BowlingSessionBallsBowled = bowlingSessionBallsBowled,
                FieldingSessionSkillsWorked = fieldingSessionSkillsWorked,
                FieldingSessionSkillsToWorkOn = fieldingSessionSkillsToWorkOn,
                FieldingSessionBallsFielded = fieldingSessionBallsFielded,
                FitnessSessionDetails = fitnessSessionDetails,
                IsBattingSession = isBattingSession,
                IsBowlingSession = isBowlingSession,
                IsFieldingSession = isFieldingSession,
                IsCricketSession = isCricketSession,
                IsFitnessSession = isFitnessSession
            };
            await App.Database.SaveSessionAsync(session);
            await DisplayAlert("Your session has been added", null, "Ok");

            ClearInput();
        }

        private void CricketSessionClicked(object sender, EventArgs e)
        {
            CricketSessionDetails.IsVisible = true;
            FitnessSessionDetails.IsVisible = false;
            CricketSessionButton.BackgroundColor = Color.DodgerBlue;
            CricketSessionButton.TextColor = Color.White;
            FitnessSessionButton.BackgroundColor = Color.White;
            FitnessSessionButton.TextColor = Color.DodgerBlue;
        }

        private void FitnessSessionClicked(object sender, EventArgs e)
        {
            CricketSessionDetails.IsVisible = false;
            FitnessSessionDetails.IsVisible = true;
            CricketSessionButton.BackgroundColor = Color.White;
            CricketSessionButton.TextColor = Color.DodgerBlue;
            FitnessSessionButton.BackgroundColor = Color.DodgerBlue;
            FitnessSessionButton.TextColor = Color.White;
        }

        private void BattingClicked(object sender, EventArgs e)
        {
            BattingDetails.IsVisible = true;
            BowlingDetails.IsVisible = false;
            FieldingDetails.IsVisible = false;

            BattingCricketSessionButton.BackgroundColor = Color.DodgerBlue;
            BattingCricketSessionButton.TextColor = Color.White;
            BowlingCricketSessionButton.BackgroundColor = Color.White;
            BowlingCricketSessionButton.TextColor = Color.DodgerBlue;
            FieldingCricketSessionButton.BackgroundColor = Color.White;
            FieldingCricketSessionButton.TextColor = Color.DodgerBlue;
        }

        private void BowlingClicked(object sender, EventArgs e)
        {
            BattingDetails.IsVisible = false;
            BowlingDetails.IsVisible = true;
            FieldingDetails.IsVisible = false;

            BattingCricketSessionButton.BackgroundColor = Color.White;
            BattingCricketSessionButton.TextColor = Color.DodgerBlue;
            BowlingCricketSessionButton.BackgroundColor = Color.DodgerBlue;
            BowlingCricketSessionButton.TextColor = Color.White;
            FieldingCricketSessionButton.BackgroundColor = Color.White;
            FieldingCricketSessionButton.TextColor = Color.DodgerBlue;
        }

        private void FieldingClicked(object sender, EventArgs e)
        {
            BattingDetails.IsVisible = false;
            BowlingDetails.IsVisible = false;
            FieldingDetails.IsVisible = true;

            BattingCricketSessionButton.BackgroundColor = Color.White;
            BattingCricketSessionButton.TextColor = Color.DodgerBlue;
            BowlingCricketSessionButton.BackgroundColor = Color.White;
            BowlingCricketSessionButton.TextColor = Color.DodgerBlue;
            FieldingCricketSessionButton.BackgroundColor = Color.DodgerBlue;
            FieldingCricketSessionButton.TextColor = Color.White;
        }
        void BattingDetailsSkillsWorkedSwitch(object sender, ToggledEventArgs e)
        {
            if (e.Value) BattingDetailsSkillsWorkedEditor.IsVisible = true;
            if (!e.Value) BattingDetailsSkillsWorkedEditor.IsVisible = false;
        }

        void BattingDetailsSkillsToWorkOnSwitch(object sender, ToggledEventArgs e)
        {
            if (e.Value) BattingDetailsSkillsToWorkOnEditor.IsVisible = true;
            if (!e.Value) BattingDetailsSkillsToWorkOnEditor.IsVisible = false;
        }

        void BattingDetailsBallsFacedSwitch(object sender, ToggledEventArgs e)
        {
            if (e.Value) BattingDetailsBallsFacedEntry.IsVisible = true;
            if (!e.Value) BattingDetailsBallsFacedEntry.IsVisible = false;
        }
        void BowlingDetailsSkillsWorkedSwitch(object sender, ToggledEventArgs e)
        {
            if (e.Value) BowlingDetailsSkillsWorkedEditor.IsVisible = true;
            if (!e.Value) BowlingDetailsSkillsWorkedEditor.IsVisible = false;
        }

        void BowlingDetailsSkillsToWorkOnSwitch(object sender, ToggledEventArgs e)
        {
            if (e.Value) BowlingDetailsSkillsToWorkOnEditor.IsVisible = true;
            if (!e.Value) BowlingDetailsSkillsToWorkOnEditor.IsVisible = false;
        }

        void BowlingDetailsBallsBowledSwitch(object sender, ToggledEventArgs e)
        {
            if (e.Value) BowlingDetailsBallsBowledEntry.IsVisible = true;
            if (!e.Value) BowlingDetailsBallsBowledEntry.IsVisible = false;
        }
        void FieldingDetailsSkillsWorkedSwitch(object sender, ToggledEventArgs e)
        {
            if (e.Value) FieldingDetailsSkillsWorkedEditor.IsVisible = true;
            if (!e.Value) FieldingDetailsSkillsWorkedEditor.IsVisible = false;
        }

        void FieldingDetailsSkillsToWorkOnSwitch(object sender, ToggledEventArgs e)
        {
            if (e.Value) FieldingDetailsSkillsToWorkOnEditor.IsVisible = true;
            if (!e.Value) FieldingDetailsSkillsToWorkOnEditor.IsVisible = false;
        }

        void FieldingDetailsBallsFieldedSwitch(object sender, ToggledEventArgs e)
        {
            if (e.Value) FieldingDetailsBallsFieldedEntry.IsVisible = true;
            if (!e.Value) FieldingDetailsBallsFieldedEntry.IsVisible = false;
        }
    }
}