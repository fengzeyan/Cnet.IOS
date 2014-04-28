using Cnt.Web.API.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Cnt.API.Services.NTMobile
{
	/// <summary>
	/// A class for managing availability for the current user.
	/// </summary>
	public class AvailabilityService
	{
		Client _Client;
		internal AvailabilityService(Client client)
		{
			_Client = client;
		}

		/// <summary>
		/// Gets all availability days for the current user for the given dates.
		/// </summary>
		/// <returns>All availability days for the current user for the given dates.</returns>
		public IEnumerable<UserAvailabilityDay> GetAvailability(DateTime startDate, DateTime endDate)
		{
			string query = String.Format("Date <= {0} AND Date >= {1}", startDate.ToString("s"), endDate.ToString("s"));
			return GetAvailability (query);
		}

		/// <summary>
		/// Gets all availability days for the current user.
		/// </summary>
		/// <returns>All availability days for the current user.</returns>
		public IEnumerable<UserAvailabilityDay> GetAvailability(string query)
		{
			return CntRestHelper.Request<IEnumerable<UserAvailability>>(Constants.NTMOBILE_BASEURL + "/availability?q=" + query, _Client.UserName, _Client.Password).Data.SelectMany(a => a.Availability);
		}

		/// <summary>
		/// Gets all availability blocks for the current user.
		/// </summary>
		/// <returns>All availability blocks for the current user.</returns>
		public IEnumerable<AvailabilityBlock> GetAvailabilityBlocks()
		{
			return CntRestHelper.Request<IEnumerable<AvailabilityBlock>>(Constants.NTMOBILE_BASEURL + "/availability-block", _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Gets an availability block.
		/// </summary>
		/// <param name="blockId">The block identifier.</param>
		/// <returns>AvailabilityBlock.</returns>
		public AvailabilityBlock GetAvailabilityBlock(int blockId)
		{
			return CntRestHelper.Request<AvailabilityBlock>(Constants.NTMOBILE_BASEURL + "/availability-block/" + blockId, _Client.UserName, _Client.Password).Data;
		}

		/// <summary>
		/// Adds an availability block.
		/// </summary>
		/// <param name="block">The availability block.</param>
		/// <returns>The identifier of the added availability block.</returns>
		public int AddAvailabilityBlock(AvailabilityBlock block)
		{
			var newBlock = CntRestHelper.JSONRequest<AvailabilityBlock>(Constants.NTMOBILE_BASEURL + "/availability-block/", _Client.UserName, _Client.Password, block, CntRestHelper.RequestMethod.POST).Data;
			block.Id = newBlock.Id;
			return block.Id;
		}

		/// <summary>
		/// Updates an availability block.
		/// </summary>
		/// <param name="block">The availability block.</param>
		/// <returns><c>true</c> if the availability block was updated, <c>false</c> otherwise.</returns>
		public void UpdateAvailabilityBlock(AvailabilityBlock block)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/availability-block/" + block.Id, _Client.UserName, _Client.Password, block, CntRestHelper.RequestMethod.PUT);
		}

		/// <summary>
		/// Deletes an availability block.
		/// </summary>
		/// <param name="blockId">The availability block identifier.</param>
		/// <returns><c>true</c> if the availability block was deleted, <c>false</c> otherwise.</returns>
		public void DeleteAvailabilityBlock(int blockId)
		{
			CntRestHelper.JSONRequest(Constants.NTMOBILE_BASEURL + "/availability-block/" + blockId, _Client.UserName, _Client.Password, null, CntRestHelper.RequestMethod.DELETE);
		}
	}
}
