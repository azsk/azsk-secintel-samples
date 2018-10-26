using System;
using System.Security.Cryptography;

namespace SecIntelSample
{
    public class CryptoSample
    {
        public static void RandomData()
        {
            // Insecure Random data generator
            var random = new Random();

            // Secure
            var rng = new RNGCryptoServiceProvider();

            // Insecure hashing algo
            var md5 = new MD5CryptoServiceProvider();

            // Insecure hashing algo
            var sha1 = new SHA1CryptoServiceProvider();

            // Secure
            var sha256 = new SHA256CryptoServiceProvider();

            //Insecure Encryption
            var rijndael = new RijndaelManaged();

            // Secure
            var aes = new AesCryptoServiceProvider();

            // crypto_enc_padding_ansix923
            aes.Padding = PaddingMode.ANSIX923;

            // crypto_enc_padding_iso10126
            aes.Padding = PaddingMode.ISO10126;

            // crypto_enc_padding_none
            aes.Padding = PaddingMode.None;

            // crypto_enc_padding_zeros
            aes.Padding = PaddingMode.Zeros;

            // safe

            aes.Padding = PaddingMode.PKCS7;

            // Insecure AES config
            aes.KeySize = 128;

            // Secure
            aes.KeySize = 256; // or
            aes.KeySize = 512;

            // crypto_enc_ciphermode_ecb
            aes.Mode = CipherMode.ECB;
        }
    }
}