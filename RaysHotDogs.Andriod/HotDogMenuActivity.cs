﻿
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
using RaysHotDogs.Andriod.Adapters;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;

namespace RaysHotDogs.Andriod
{

    //Master    
    [Activity(Label = "HotDogMenuActivity")]
    public class HotDogMenuActivity : Activity
    {

        private ListView hotDogListView;
        private List<HotDog> allHotDogs;
        private HotDogDataService hotDogDataService;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.HotDogMenuView);
            hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView);

            hotDogDataService = new HotDogDataService();
            allHotDogs = hotDogDataService.GetAllHotDogs();

            hotDogListView.Adapter = new HotDogListAdapter(allHotDogs);

            hotDogListView.FastScrollEnabled = true;

            hotDogListView.ItemClick += HotDogListView_ItemClick;

           



        }

        private void HotDogListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var hotDog = allHotDogs[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(HotDogDetailActivity));
            intent.PutExtra("selectedHotDogId", hotDog.HotDogId);

            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if(resultCode == Result.Ok && requestCode == 100){
                var selectedHotDog = hotDogDataService.GetHotDogById(data.GetIntExtra("selectedHotDogId",0));

                var dialog = new AlertDialog.Builder(this);

                dialog.SetTitle("Confirmation");
                dialog.SetMessage(string.Format($"You have added {data.GetIntExtra("amount",0)} time(s) the {selectedHotDog.Name}"));
                dialog.Show();

            }
        }
    }
}
