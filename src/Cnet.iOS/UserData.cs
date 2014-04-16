using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using Cnt.Web.API.Models;

namespace Cnet.iOS
{
	public class UserData
	{
		public int UserId { get; set; }
		public bool AvailabilityLocked { get; set; }
		public string Notifications { get; set; }
		public DateRange CurrentPayPeriod { get; set; }
		public IEnumerable<UserOfficeInfo> Offices { get; set; }
	}
}

