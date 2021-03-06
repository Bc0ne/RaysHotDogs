﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RaysHotDogs.Andriod
{
    [Activity(Label = "About Ray",Icon ="@drawable/smallicon")]
    public class AboutActivity : Activity
    {
        private TextView phoneNumberTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutView);

            // Create your application here

            FindViews();
            HandleEvents();
        }


        private void FindViews()
        {
            phoneNumberTextView = FindViewById<TextView>(Resource.Id.phoneNumberTextView);
        }

        private void HandleEvents()
        {
            phoneNumberTextView.Click += PhoneNumberTextView_Click;
        }

        private void PhoneNumberTextView_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionDial);

            intent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumberTextView.Text));
            StartActivity(intent);
        }
    }
}
