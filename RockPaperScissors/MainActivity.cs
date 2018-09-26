using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace RockPaperScissors
{
    [Activity(Label = "Rock Paper Scissors", MainLauncher = true, Icon =
        "@drawable/paper")]
    public class MainActivity : Activity
    {
        private Button btnNext;
        private TextView txtName;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            StartUp();

        }


        private void StartUp()
        {
            txtName = FindViewById<TextView>(Resource.Id.etEnterName);
            btnNext = FindViewById<Button>(Resource.Id.btnNext);

            btnNext.Click += onNext_Click;
        }

        private void onNext_Click(object sender, EventArgs e)
        {
            //Toast.MakeText(this, "Your name is " + txtName.Text,ToastLength.Long).Show();

            //Create an intent to move data to the other activity


            var gameActivity = new Intent(this, typeof(GameActivity));
            gameActivity.PutExtra("Name", txtName.Text);    

            //run the inent and start the other screen passing over the data
            StartActivity(gameActivity);

        }
    }
}

