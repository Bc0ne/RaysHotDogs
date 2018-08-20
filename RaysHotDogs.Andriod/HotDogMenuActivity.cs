
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
using RaysHotDogs.Andriod.Fragments;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;

namespace RaysHotDogs.Andriod
{

    //Master    
    [Activity(Label = "Hot Dogs Menu",Icon ="@drawable/smallicon")]
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

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            AddTab("Favourites", Resource.Drawable.FavoritesIcon, new FavouriteHotDogFragment());
            AddTab("Meat Lovers", Resource.Drawable.MeatLoversIcon, new MeatLoversFragment());
            AddTab("Veggie Lovers", Resource.Drawable.VeggieLoversIcon, new VeggieLoversFragment());
            
            
            //hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView);

            //hotDogDataService = new HotDogDataService();
            //allHotDogs = hotDogDataService.GetAllHotDogs();

            //hotDogListView.Adapter = new HotDogListAdapter(allHotDogs);

            //hotDogListView.FastScrollEnabled = true;

            //hotDogListView.ItemClick += HotDogListView_ItemClick;

        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += (Object sender, ActionBar.TabEventArgs e) =>
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                //if (fragment != null)
                //{
                //    e.FragmentTransaction.Remove(fragment);
                //}
                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, view);
            };

            //tab.TabUnselected += (Object sender, ActionBar.TabEventArgs e) =>
            //{
            //    e.FragmentTransaction.Remove(view);
            //};
            this.ActionBar.AddTab(tab);

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
