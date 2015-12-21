// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SavedIt.iOS
{
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField ItemTextBox { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField PriceTextBox { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SaveButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SavedLabel { get; set; }

		[Action ("SaveButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SaveButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (ItemTextBox != null) {
				ItemTextBox.Dispose ();
				ItemTextBox = null;
			}
			if (PriceTextBox != null) {
				PriceTextBox.Dispose ();
				PriceTextBox = null;
			}
			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}
			if (SavedLabel != null) {
				SavedLabel.Dispose ();
				SavedLabel = null;
			}
		}
	}
}
