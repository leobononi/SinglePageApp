using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SpaExample.Controllers
{
	[Route("api/[controller]")]
	public class SampleDataController : Controller
	{
		[HttpGet("[action]")]
		public StandByCallsResponse WeatherForecasts()
		{
			var standByCallsResponse = Enumerable.Range(1, 10).Select(index => new CallResponseDetails
			{
				Duration = DateTime.Now,
				Source = "3399-0003"
			});

			return new StandByCallsResponse
			{
				Calls = standByCallsResponse
			};
		}

		public class StandByCallsResponse
		{
			public IEnumerable<CallResponseDetails> Calls { get; set; }
			public int Total => 12;
		}

		public class CallResponseDetails
		{
			public string Source { get; set; }
			public DateTime Duration { get; set; }
		}
	}
}
