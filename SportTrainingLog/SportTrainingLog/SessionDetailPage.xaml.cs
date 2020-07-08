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
    public partial class SessionDetailPage : ContentPage
    {
        public SessionDetailPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            if ((BattingSessionSkillsWorkedLabel.Text == null) || (BattingSessionSkillsToWorkOnLabel.Text == null) || (BattingSessionBallsBowledLabel.Text =="0"))
            {
                BattingSessionDisplay.IsVisible = false;
            }
            if ((BowlingSessionSkillsWorkedLabel.Text == null) || (BowlingSessionSkillsToWorkOnLabel.Text == null) || (BowlingSessionBallsBowledLabel.Text == "0"))
            {
                BowlingSessionDisplay.IsVisible = false;
            }
            if ((FieldingSessionSkillsWorkedLabel.Text == null) || (FieldingSessionSkillsToWorkOnLabel.Text == null) || (FieldingSessionBallsFieldedLabel.Text == "0"))
            {
                FieldingSessionDisplay.IsVisible = false;
            }
            if (FitnessSessionSessionDetailsLabel.Text == null) FitnessSessionDetails.IsVisible = false;
        }
        
    }
}