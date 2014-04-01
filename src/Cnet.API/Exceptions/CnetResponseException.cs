using Cnt.Web.API.Models;
using System;
using System.Collections.Generic;

namespace Cnt.API.Exceptions
{
	public class CntResponseException : Exception
	{
		public IEnumerable<ApiError> Errors { get; private set; }

		public CntResponseException(string message, IEnumerable<ApiError> errors)
			: base(message)
		{
			Errors = errors;
		}
	}
}