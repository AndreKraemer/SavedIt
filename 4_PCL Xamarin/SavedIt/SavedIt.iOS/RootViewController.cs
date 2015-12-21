// --------------------------------------------------------------------------------------
// <copyright file="RootViewController.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Xamarin PCL Demo App
// </summary>
// --------------------------------------------------------------------------------------

using System;


using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using SavedIt.Portable.Models;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using SavedIt.Portable.Data;
using System.IO;

namespace SavedIt.iOS
{
    public partial class RootViewController : UIViewController
    {
        private List<SavedItem> _savedItems = new List<SavedItem>();
        private SavedItemRepository _repository;

        public RootViewController(IntPtr handle) : base(handle)
        {
        }



        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


			var connection = GeSqlitetConnection();
            _repository = new SavedItemRepository(connection);


            _savedItems = _repository.GetAll();
            UpdateTotalLabel();
          

			// Hide Keyboard when the user taps outside of a control
            var g = new UITapGestureRecognizer(() => View.EndEditing(true)) {CancelsTouchesInView = false};
            //for iOS5
            View.AddGestureRecognizer(g);

			ItemTextBox.ShouldReturn = (txt) => {
				PriceTextBox.BecomeFirstResponder();
				return true;
			};

			PriceTextBox.ShouldReturn = (txt) => {
				txt.ResignFirstResponder();
				return true;
			};
        }

        private static SQLiteConnection GeSqlitetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, "savedItems.sqlite");
            var connection = new SQLiteConnection(new SQLitePlatformIOS(), path);
            return connection;
        }

        #endregion

        partial void SaveButton_TouchUpInside(UIButton sender)
        {
            var item = new SavedItem();
            item.Date = DateTime.Now;
            item.Description = ItemTextBox.Text;
            decimal price = 0;

            decimal.TryParse(PriceTextBox.Text, out price);
            item.Price = price;

            _savedItems.Add(item);
            _repository.Create(item);
            UpdateTotalLabel();
			ItemTextBox.Text = "";
			PriceTextBox.Text = "";
        }

        private void UpdateTotalLabel()
        {
            SavedLabel.Text = _savedItems.Sum(i => i.Price).ToString("C");
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var detailController = segue.DestinationViewController as DetailViewController;
            if(detailController != null)
            {
                detailController.SavedItems = _savedItems;
            }
        }
    }
}