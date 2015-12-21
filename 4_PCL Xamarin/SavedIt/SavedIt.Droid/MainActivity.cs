// --------------------------------------------------------------------------------------
// <copyright file="MainActivity.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Xamarin PCL Demo App
// </summary>
// --------------------------------------------------------------------------------------

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;
using Android.Views.InputMethods;
using Newtonsoft.Json;
using SavedIt.Portable.Models;
using SQLite.Net;
using SavedIt.Portable.Data;
using SQLite.Net.Platform.XamarinAndroid;

namespace SavedIt.Droid
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private SavedItemRepository _repository;
        List<SavedItem> _savedItems = new List<SavedItem>();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText descriptionText = FindViewById<EditText>(Resource.Id.descriptionText);
            EditText priceText = FindViewById<EditText>(Resource.Id.priceText);
            TextView totalText = FindViewById<TextView>(Resource.Id.totalSavedText);
            Button saveButton = FindViewById<Button>(Resource.Id.saveButton);

            var connection = GetSqliteConnection();
            _repository = new SavedItemRepository(connection);

            _savedItems = _repository.GetAll();
            UpdateTotalLabel(totalText);


            saveButton.Click += (sender, e) =>
            {
                decimal price = 0;
                if (decimal.TryParse(priceText.Text, out price))
                {
                    var savedItem = new SavedItem();
                    savedItem.Date = DateTime.Now;
                    savedItem.Description = descriptionText.Text;
                    savedItem.Price = price;
                    _savedItems.Add(savedItem);
                    _repository.Create(savedItem);
                    UpdateTotalLabel(totalText);
                    descriptionText.Text = string.Empty;
                    priceText.Text = string.Empty;
                    HideKeyBoard();
                }

            };

            Button detailsButton = FindViewById<Button>(Resource.Id.detailsButton);
            detailsButton.Click += DetailsButton_Click;        
        }

        private static SQLiteConnection GetSqliteConnection()
        {
            var path = System.IO.Path.Combine(System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal), "saveditems.sqlite");
            var connection = new SQLiteConnection(new SQLitePlatformAndroid(), path);
            return connection;
        }

        private void UpdateTotalLabel(TextView totalText)
        {
            totalText.Text = _savedItems.Sum(s => s.Price).ToString("C");
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(DetailActivity));
            var json = JsonConvert.SerializeObject(_savedItems);
            intent.PutExtra("SavedItems", json);
            StartActivity(intent);
        }

        private void HideKeyBoard()
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);

            if(imm.IsAcceptingText)
            {
                imm.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);
            }
        }

 
    }
}

