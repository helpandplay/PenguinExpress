using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PenguinExpress.config
{
  public static class SHA256Hash
  {
    private const int minSaltLen = 12;
    private const int maxSaltLen = 36;
    private static byte[] salting(string pwd, string salt)
    {
      byte[] src = Encoding.ASCII.GetBytes(pwd);
      byte[] msg = Encoding.ASCII.GetBytes(salt);
      byte[] combined = msg.Concat(src).ToArray();

      return combined;
    }
    private static string byteToString(byte[] data)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (byte b in data)
      {
        stringBuilder.AppendFormat("{0:x2}", b); //16진수로 변환
      }
      return stringBuilder.ToString();
    }
    public static string getSalt()
    {
      RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
      Random random = new Random();
      int randomNum = random.Next(minSaltLen, maxSaltLen);

      byte[] bytes = new byte[randomNum];
      rng.GetNonZeroBytes(bytes);

      return byteToString(bytes);
    }
    public static string hashing(string pwd, string salt)
    {
      SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

      byte[] combined = salting(pwd, salt);
      byte[] hash = sha256.ComputeHash(combined);

      return byteToString(hash);
    }
    public static bool isEqualPwd(string input, string dbPwd, string salt)
    {
      string hash = hashing(input, salt);
      if (hash == dbPwd) return true;
      return false;
    }
  }
}
