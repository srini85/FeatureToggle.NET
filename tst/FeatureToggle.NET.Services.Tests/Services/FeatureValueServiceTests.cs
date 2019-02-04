using System.Linq;
using FeatureToggle.NET.Core.Types;
using FeatureToggle.NET.Services.Data;
using FeatureToggle.NET.Services.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FeatureToggle.NET.Services.Tests.Services
{
	public class FeatureValueServiceTests
	{
		[Test]
		public void AddFeatureValue_ValidValues_AddedToStore()
		{
			// Arrange
			var options = PrepareInMemoryDb();

			// Act
			using (var context = new FeatureToggleDbContext(options))
			{
				var service = new FeatureValueService(context);
				service.AddFeatureValue(new FeatureValue<bool> {Value = true});
			}

			// Assert
			using (var context = new FeatureToggleDbContext(options))
			{
				context.FeatureValues.Count().Should().Be(1);
			}
		}

		private DbContextOptions<FeatureToggleDbContext> PrepareInMemoryDb()
		{
			return new DbContextOptionsBuilder<FeatureToggleDbContext>()
				.UseInMemoryDatabase("featureToggleInMemory")
				.Options;
		}
	}
}
