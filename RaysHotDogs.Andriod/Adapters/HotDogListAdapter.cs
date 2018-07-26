using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Andriod.Utility;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.Andriod.Adapters
{
    //Master
    public class HotDogListAdapter: BaseAdapter<HotDog>
    {
        
        List<HotDog> items;

        public HotDogListAdapter(List<HotDog> items) : base()
        {
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override HotDog this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + item.ImagePath + ".jpg");
            if (convertView == null)
            {
                convertView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.hotdog_row_view, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.hotDogShortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.hotDogPriceTextView).Text = "$ -> "+item.Price;
            convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView).SetImageBitmap(imageBitmap);
                       
            return convertView;
        }

    }
}
