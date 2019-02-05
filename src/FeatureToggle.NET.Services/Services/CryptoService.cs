using System;
using System.Security.Cryptography;
using System.Text;
using FeatureToggle.NET.Core.Auth;

namespace FeatureToggle.NET.Services.Services
{
	public class CryptoService : ICryptoService
	{
		public const int SaltBytes = 24;

		public SaltedHash GenerateHash(string password)
		{
			var salt = GenerateSalt();

			var hash = GenerateHash(password, salt);

			return new SaltedHash
			{
				Hash = hash,
				Salt = Convert.ToBase64String(salt)
			};
		}

		private static byte[] GenerateSalt()
		{
			byte[] salt = new byte[SaltBytes];
			try
			{
				using (RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider())
				{
					cryptoServiceProvider.GetNonZeroBytes(salt);
				}
			}
			catch (CryptographicException ex)
			{
				throw new Exception("Random number generator not available.", ex);
			}
			catch (ArgumentNullException ex)
			{
				throw new Exception("Invalid argument given to random number generator.", ex);
			}

			return salt;
		}

		private string GenerateHash(string password, byte[] salt)
		{
			var inputBytes = Encoding.UTF8.GetBytes(password);
			var saltedInput = new byte[salt.Length + inputBytes.Length];
			salt.CopyTo(saltedInput, 0);
			inputBytes.CopyTo(saltedInput, salt.Length);

			using (HashAlgorithm pbkdf2 = new SHA512CryptoServiceProvider())
			{
				return Convert.ToBase64String(pbkdf2.ComputeHash(saltedInput));
			}
		}

		public bool VerifyPasswordWithHash(string password, SaltedHash saltedHash)
		{
			var generatedHash = GenerateHash(password, Convert.FromBase64String(saltedHash.Salt));
			return generatedHash == saltedHash.Hash;
		}
	}
}