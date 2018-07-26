
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
    [Activity(Label = "HotDogMenuActivity",MainLauncher =true)]
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

           



        }
    }
}
