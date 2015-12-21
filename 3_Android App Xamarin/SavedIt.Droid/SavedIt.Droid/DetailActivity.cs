// --------------------------------------------------------------------------------------
// <copyright file="DetailActivity.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Xamarin Android Demo App
// </summary>
// --------------------------------------------------------------------------------------
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
using Newtonsoft.Json;

namespace SavedIt.Droid
{
    [Activity(Label = "@string/Details")]
    public class DetailActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var json = Intent.GetStringExtra("SavedItems");
            List<SavedItem> savedItems = JsonConvert.DeserializeObject<List<SavedItem>>(json) ?? new List<SavedItem>();

            // Create your application here
            ListAdapter = new SavedItemAdapter(this, savedItems);
        }
    }

    internal class SavedItemAdapter : BaseAdapter<SavedItem>
    {
        private readonly DetailActivity _context;
        private readonly List<SavedItem> _savedItems;

        public SavedItemAdapter(DetailActivity context, List<SavedItem> savedItems)
        {
            this._context = context;
            this._savedItems = savedItems;
        }

        public override SavedItem this[int position]
        {
            get
            {
                return _savedItems[position];
            }
        }

        public override int Count
        {
            get
            {
                return _savedItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _savedItems[position];
            View view = convertView ??
                _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Description;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = $"{item.Price:C} ({item.Date:d})";
            return view;
        }
    }
}