// --------------------------------------------------------------------------------------
// <copyright file="DetailPage.xaml.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Xamarin Forms Demo App
// </summary>
// --------------------------------------------------------------------------------------
using System.Collections.Generic;
using SavedItXF.Models;
using Xamarin.Forms;

namespace SavedItXF
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(List<SavedItem> savedItems)
        {
            InitializeComponent();
            SavedItemsListView.ItemsSource = savedItems;
        }
    }
}
