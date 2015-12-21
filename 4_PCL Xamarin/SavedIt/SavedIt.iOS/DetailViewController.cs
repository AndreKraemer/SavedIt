// --------------------------------------------------------------------------------------
// <copyright file="DetailViewController.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Xamarin PCL Demo App
// </summary>
// --------------------------------------------------------------------------------------
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using SavedIt.Portable.Models;

namespace SavedIt.iOS
{
	partial class DetailViewController : UITableViewController
	{
        public List<SavedItem> SavedItems { get; set; }
		public DetailViewController (IntPtr handle) : base (handle)
		{

            TableView.Source = new DetailDataSource(this);
            SavedItems = new List<SavedItem>();
		}
	}

    internal class DetailDataSource : UITableViewSource
    {
        private readonly DetailViewController _detailViewController;

        public DetailDataSource(DetailViewController detailViewController)
        {
            _detailViewController = detailViewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(new NSString("DetailCell"));
            var item = _detailViewController.SavedItems[indexPath.Row];
            cell.TextLabel.Text = item.Description;
            cell.DetailTextLabel.Text = $"{item.Price:C}, ({item.Date:d})";
            return cell;

        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _detailViewController.SavedItems.Count;
        }
    }
}
