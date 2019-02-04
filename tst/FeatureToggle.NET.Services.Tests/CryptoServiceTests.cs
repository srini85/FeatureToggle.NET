using FeatureToggle.NET.Services.Services;
using FluentAssertions;
using NUnit.Framework;

namespace FeatureToggle.NET.Services.Tests
{
	public class CryptoServiceTests
	{
		[Test]
		public void GenerateHash_ValidPassword_GeneratesValidHashAndSalt()
		{
			// Arrange
			var cryptoService = new CryptoService();

			// Act
			var result = cryptoService.GenerateHash("known_password");

			// Assert
			result.Hash.Should().NotBeNullOrEmpty();
			result.Salt.Should().NotBeNullOrEmpty();
		}

		[Test]
		public void GenerateHash_ValidPassword_GeneratesDifferentHashAndSaltEachTime()
		{
			// Arrange
			var cryptoService = new CryptoService();

			// Act
			var result = cryptoService.GenerateHash("known_password");
			var result2 = cryptoService.GenerateHash("known_password");

			// Assert
			result.Hash.Should().NotBe(result2.Hash);
			result.Salt.Should().NotBe(result2.Salt);
		}

		[Test]
		public void VerifyPasswordWithHash_ValidPasswordAndHash_ReturnsTrue()
		{
			// Arrange
			var cryptoService = new CryptoService();

			// Act
			var saltedHash = cryptoService.GenerateHash("known_password");
			var result = cryptoService.VerifyPasswordWithHash("known_password", saltedHash);

			// Assert
			result.Should().BeTrue();
		}
	}
}