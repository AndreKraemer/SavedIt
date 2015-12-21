// --------------------------------------------------------------------------------------
// <copyright file="SavedIt.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Xamarin PCL Demo App
// </summary>
// --------------------------------------------------------------------------------------

using System;
using SQLite.Net.Attributes;

namespace SavedIt.Portable.Models
{
    public class SavedItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
