using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Cnt.Web.API.Models;

namespace Cnet.iOS
{
	public static class Utility
	{
		public static UIImage UIImageFromUrl(string uri)
		{
			if (String.IsNullOrEmpty (uri))
				return new UIImage ();

			using (var url = new NSUrl (uri))
			using (var data = NSData.FromUrl (url))
				return UIImage.LoadFromData (data);
		}

		public static string ToFormattedString(this TimeBlock timeBlock)
		{
			DateTime start = new DateTime (timeBlock.Start * TimeSpan.TicksPerSecond);
			DateTime end = start.AddSeconds (timeBlock.Duration);
			return start.ToString ("h:mmtt").ToLower() + " - " + end.ToString ("h:mmtt").ToLower();
		}
	}
}

