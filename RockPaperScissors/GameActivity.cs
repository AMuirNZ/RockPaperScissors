using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RockPaperScissors
{
    [Activity(Label = "Rock Paper Scissors Game")]
    public class GameActivity : Activity
    {
        private TextView txtMessage;
        private string Name;
        private ImageView GamePic;
        private ImageView HumanPic;
        private ImageView ComputerPic;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
            SetContentView(Resource.Layout.Game);
            Name = Intent.GetStringExtra("Name");
            GamePic = FindViewById<ImageView>(Resource.Id.imageAnswer);
            HumanPic = FindViewById<ImageView>(Resource.Id.ivHuman);
            ComputerPic = FindViewById<ImageView>(Resource.Id.ivComputer);

            txtMessage = FindViewById<TextView>(Resource.Id.tvName);
            txtMessage.Text = "Welcome to the game " + Name;

            //Radiobutton binding
            RadioButton RPaper = FindViewById<RadioButton>(Resource.Id.radio_paper);
            RadioButton RScissors = FindViewById<RadioButton>(Resource.Id.radio_scissors);
            RadioButton RRock = FindViewById<RadioButton>(Resource.Id.radio_rock);

            //radiobuttons going to same click event
            RPaper.Click += RadioButtonClick;
            RScissors.Click += RadioButtonClick;
            RRock.Click += RadioButtonClick;

        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            string comp = ComputerChoice();
            string Hum = rb.Text;
            //Toast.MakeText(this, Name + " " + Hum + " vrs Comp = " + comp, ToastLength.Long).Show();

            if (Hum == "Paper")
            {
                HumanPic.SetImageResource(Resource.Drawable.Paper);
            }
            else if (Hum == "Scissors")
            {
                HumanPic.SetImageResource(Resource.Drawable.Scissors);
            }
            else
            {
                HumanPic.SetImageResource(Resource.Drawable.Rock);
            }

            if (comp == "Paper")
            {
                ComputerPic.SetImageResource(Resource.Drawable.Paper);
            }
            else if (comp == "Scissors")
            {
                ComputerPic.SetImageResource(Resource.Drawable.Scissors);
            }
            else
            {
                ComputerPic.SetImageResource(Resource.Drawable.Rock);
            }


            if (Hum == "Paper" && comp == "Rock"
                || Hum == "Scissors" && comp == "Paper"
                || Hum == "Rock" && comp == "Scissors")

            {
                Toast.MakeText(this, Hum + " beats " + comp + " you win.", ToastLength.Short).Show();
            }
            else if (Hum == comp)

            {

                
                Toast.MakeText(this, Hum + " = " + comp + " you draw.", ToastLength.Short).Show();
            }

            else
            {
               
                Toast.MakeText(this, comp + " beats " + Hum + " you lose.", ToastLength.Short).Show();

            }
        }

        public string ComputerChoice()
        {
            //create a new instance of the Random Class
            var CompGuess = new Random();
            //This code generates a random integer between 1 and 4, but 4 is not inclusive, meaning the only possibilities are 1, 2 and 3
            //1 represents paper, 2 represents scissors, 3 represents rock 
            string[] Guess = { "", "Paper", "Scissors", "Rock" };
            return Guess[CompGuess.Next(1, 4)];
        }

    }
    }
