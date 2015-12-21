// --------------------------------------------------------------------------------------
// <copyright file="RootViewController.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Xamarin iOS Demo App
// </summary>
// --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace SavedIt
{
    public partial class RootViewController : UIViewController
    {
        private readonly List<SavedItem> _savedItems = new List<SavedItem>();

        public RootViewController(IntPtr handle) : base(handle)
        {
        }

        partial void SaveButton_TouchUpInside(UIButton sender)
        {
            var item = new SavedItem
            {
                Date = DateTime.Now,
                Description = ItemTextBox.Text
            };

            decimal price = 0;

            decimal.TryParse(PriceTextBox.Text, out price);
            item.Price = price;

            _savedItems.Add(item);

            ItemTextBox.Text = string.Empty;
            PriceTextBox.Text = "0";

            SavedLabel.Text = _savedItems.Sum(i => i.Price).ToString("C");
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var detailController = segue.DestinationViewController as DetailViewController;
            if (detailController != null)
            {
                detailController.SavedItems = _savedItems;
            }
        }
    }
}