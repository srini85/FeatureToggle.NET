using FeatureToggle.NET.Core.Checkers;
using FeatureToggle.NET.Core.Types;
using FeatureToggle.NET.Services.Checkers;
using FluentAssertions;
using NUnit.Framework;

namespace FeatureToggle.NET.Services.Tests.Checkers
{
	public class EnvironmentCheckerTests
	{
		[Test]
		public void IsValid_ValidEnvironmentInContext_ReturnsTrue()
		{
			// Arrange
			var context = new Context();
			context.Add(new EnvironmentContextData { Data = "prodEnv"});
			var environmentChecker = new EnvironmentChecker(context);
			
			// Act
			var isValid = environmentChecker.IsValid(new Feature {Name = "some funky feature"}, "prodEnv");

			// Assert
			isValid.Should().BeTrue();
		}

		[Test]
		public void IsValid_EnvironmentInContextNotMatchingChecks_ReturnsFalse()
		{
			// Arrange
			var context = new Context();
			context.Add(new EnvironmentContextData { Data = "prodEnv" });
			var environmentChecker = new EnvironmentChecker(context);

			// Act
			var isValid = environmentChecker.IsValid(new Feature { Name = "some funky feature" }, "test");

			// Assert
			isValid.Should().BeFalse();
		}
	}
}
