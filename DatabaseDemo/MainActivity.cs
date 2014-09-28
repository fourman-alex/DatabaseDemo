using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Linq;

namespace DatabaseDemo
{
	[Activity (Label = "DatabaseDemo", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			var textView = FindViewById<TextView> (Resource.Id.textView1);

			var theConn = Data.Connection;
			theConn.CreateTable<Stock> ();
			theConn.Insert (new Stock{ Symbol = "MSB" });
			theConn.Insert (new Stock{ Symbol = "GSG" });
			theConn.Insert (new Stock{ Symbol = "HWEG" });
			var table = theConn.Table<Stock> ().ToList ();
			foreach (var item in table) {
				textView.Text += item.ToString () + System.Environment.NewLine;
				Console.WriteLine (item);
			}
		}
	}
}


