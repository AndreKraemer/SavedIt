// --------------------------------------------------------------------------------------
// <copyright file="SavedItem.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Xamarin Forms Demo App
// </summary>
// --------------------------------------------------------------------------------------
using System;

namespace SavedItXF.Models
{
    public class SavedItem
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
