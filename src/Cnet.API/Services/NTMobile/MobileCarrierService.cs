using System.Collections.Generic;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing mobile carriers.
	/// </summary>
	public class MobileCarrierService
	{
		Client _Client;
		internal MobileCarrierService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets a list of all mobile carriers.
		/// </summary>
		/// <returns>A list of all mobile carriers.</returns>
		public IEnumerable<string> GetMobileCarriers()
		{
			return CntRestHelper.Request<IEnumerable<string>>(Constants.NTMOBILE_BASEURL + "/mobile-carriers", _Client.UserName, _Client.Password).Data;
		}
	}
}
