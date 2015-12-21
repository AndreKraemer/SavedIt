// --------------------------------------------------------------------------------------
// <copyright file="SavedItem.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Xamarin iOS Demo App
// </summary>
// --------------------------------------------------------------------------------------

using System;

namespace SavedIt
{
    public class SavedItem
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
