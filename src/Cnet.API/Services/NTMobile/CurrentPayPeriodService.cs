using Cnt.Web.API.Models;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing the current pay period.
	/// </summary>
	public class CurrentPayPeriodService
	{
		Client _Client;
		internal CurrentPayPeriodService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets the current pay period.
		/// </summary>
		/// <returns>The current pay period.</returns>
		public DateRange GetCurrentPayPeriod()
		{
			return CntRestHelper.Request<DateRange>(Constants.NTMOBILE_BASEURL + "/current-pay-period", _Client.UserName, _Client.Password).Data;
		}
	}
}
