using Cnt.Web.API.Models;
using System.Collections.Generic;
using System.Net;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing placements for the current user.
	/// </summary>
	public class PlacementService
	{
		Client _Client;
		internal PlacementService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets all placements for the current user.
		/// </summary>
		/// <returns>All placements for the current user.</returns>
		public IEnumerable<Placement> GetPlacements()
		{
			return CntRestHelper.Request<IEnumerable<Placement>>(Constants.NTMOBILE_BASEURL + "/placements", _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Gets a placement.
		/// </summary>
		/// <param name="placementId">The placement identifier.</param>
		/// <returns>The placement.</returns>
		public Placement GetPlacement(int placementId)
		{
			return CntRestHelper.Request<Placement>(Constants.NTMOBILE_BASEURL + "/placement/" + placementId, _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Confirms a placement.
		/// </summary>
		/// <param name="placementId">The placement identifier.</param>
		/// <returns><c>true</c> if the notification was confirmed, <c>false</c> otherwise.</returns>
		public void ConfirmPlacement(int placementId)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/placement/" + placementId + "/confirm", _Client.UserName, _Client.Password, null, CntRestHelper.RequestMethod.PUT);
		}

		/// <summary>
		/// Declines a placement.
		/// </summary>
		/// <param name="placementId">The placement identifier.</param>
		/// <returns><c>true</c> if the notification was declined, <c>false</c> otherwise.</returns>
		public void DeclinePlacement(int placementId)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/placement/" + placementId + "/decline", _Client.UserName, _Client.Password, null, CntRestHelper.RequestMethod.PUT);
		}
	}
}
