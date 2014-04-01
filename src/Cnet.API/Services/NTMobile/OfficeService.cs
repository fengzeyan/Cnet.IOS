using Cnt.Web.API.Models;
using System.Collections.Generic;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing offices for the current user.
	/// </summary>
	public class OfficeService
	{
		Client _Client;
		internal OfficeService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets all offices for the current user.
		/// </summary>
		/// <returns>All offices for the current user.</returns>
		public IEnumerable<Office> GetOffices()
		{
			return CntRestHelper.Request<IEnumerable<Office>>(Constants.NTMOBILE_BASEURL + "/offices", _Client.UserName, _Client.Password).Data;
		}
	}
}
