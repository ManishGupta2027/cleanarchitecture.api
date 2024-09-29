using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Responses
{
	public class BoolResponse
	{
		public bool Success { get; set; }
		public string Message { get; set; }

		public BoolResponse(bool success, string message)
		{
			Success = success;
			Message = message;
		}
	}
}
