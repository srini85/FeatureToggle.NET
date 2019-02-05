using System;

namespace FeatureToggle.NET.Services.Checkers
{
	public class TimePeriod
	{
		public DateTimeOffset StarTimeOffset { get; set; }

		public DateTimeOffset EndTimeOffset { get; set; }
	}
}