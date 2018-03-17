using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using Surrogacy.Util;

namespace Surrogacy.Helper
{
    public class SecurityHelper
    {
        public static string getEncryptedText(string text, InputType inputType)
        {
            string encryptedText = text;
            bool UserNameSecurityEnable = false;
            bool PasswordSecurityEnable = false;
            bool NumberSecurityEnable = false;
            bool TextSecurityEnable = false;

            Boolean.TryParse(WebConfigurationManager.AppSettings["UserNameSecurityEnable"], out UserNameSecurityEnable);
            Boolean.TryParse(WebConfigurationManager.AppSettings["PasswordSecurityEnable"], out PasswordSecurityEnable);
            Boolean.TryParse(WebConfigurationManager.AppSettings["NumberSecurityEnable"], out NumberSecurityEnable);
            Boolean.TryParse(WebConfigurationManager.AppSettings["TextSecurityEnable"], out TextSecurityEnable);

            Crypto crypto = new Crypto();

            if ((inputType == InputType.UserName && UserNameSecurityEnable) ||
                (inputType == InputType.Password && PasswordSecurityEnable) ||
                (inputType == InputType.Text && TextSecurityEnable) ||
                (inputType == InputType.Number && NumberSecurityEnable))
            {
                try
                {
                    encryptedText = crypto.Encrypt(inputType == InputType.UserName ? text.ToLower() : text);
                }
                catch (Exception)
                {
                    encryptedText = text;
                }
            }

            return encryptedText;
        }

        public static string getDecryptedText(string text, InputType inputType)
        {
            string decryptedText = text;
            bool UserNameSecurityEnable = false;
            bool PasswordSecurityEnable = false;
            bool NumberSecurityEnable = false;
            bool TextSecurityEnable = false;

            Boolean.TryParse(WebConfigurationManager.AppSettings["UserNameSecurityEnable"], out UserNameSecurityEnable);
            Boolean.TryParse(WebConfigurationManager.AppSettings["PasswordSecurityEnable"], out PasswordSecurityEnable);
            Boolean.TryParse(WebConfigurationManager.AppSettings["NumberSecurityEnable"], out NumberSecurityEnable);
            Boolean.TryParse(WebConfigurationManager.AppSettings["TextSecurityEnable"], out TextSecurityEnable);

            Crypto crypto = new Crypto();

            if ((inputType == InputType.UserName && UserNameSecurityEnable) ||
                (inputType == InputType.Password && PasswordSecurityEnable) ||
                (inputType == InputType.Text && TextSecurityEnable) ||
                (inputType == InputType.Number && NumberSecurityEnable))
            {
                try
                {
                    decryptedText = crypto.Decrypt(text);
                }
                catch (Exception)
                {
                    decryptedText = text;
                }
            }

            return decryptedText;
        }
    }

    public class Crypto
    {
        public enum CryptoTypes
        {
            encTypeDES = 0,
            encTypeRC2,
            encTypeRijndael,
            encTypeTripleDES
        }

        public Crypto()
        {
            calculateNewKeyAndIV();
        }

        private const string CRYPT_DEFAULT_PASSWORD = "CB06cfE507a1";
        private const CryptoTypes CRYPT_DEFAULT_METHOD = CryptoTypes.encTypeRijndael;

        private byte[] mKey = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        private byte[] mIV = { 65, 110, 68, 26, 69, 178, 200, 219 };
        private byte[] SaltByteArray = { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        private CryptoTypes mCryptoType = CRYPT_DEFAULT_METHOD;
        private string mPassword = CRYPT_DEFAULT_PASSWORD;

        private void calculateNewKeyAndIV()
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(mPassword, SaltByteArray);
            SymmetricAlgorithm algo = selectAlgorithm();
            mKey = pdb.GetBytes(algo.KeySize / 8);
            mIV = pdb.GetBytes(algo.BlockSize / 8);
        }

        private SymmetricAlgorithm selectAlgorithm()
        {
            SymmetricAlgorithm SA;
            switch (mCryptoType)
            {
                case CryptoTypes.encTypeDES:
                    SA = DES.Create();
                    break;
                case CryptoTypes.encTypeRC2:
                    SA = RC2.Create();
                    break;
                case CryptoTypes.encTypeRijndael:
                    SA = Rijndael.Create();
                    break;
                case CryptoTypes.encTypeTripleDES:
                    SA = TripleDES.Create();
                    break;
                default:
                    SA = TripleDES.Create();
                    break;
            }
            return SA;
        }

        public string Encrypt(string inputText)
        {
            UTF8Encoding UTF8Encoder = new UTF8Encoding();
            byte[] inputBytes = UTF8Encoder.GetBytes(inputText);

            return Convert.ToBase64String(EncryptDecrypt(inputBytes, true));
        }

        private byte[] EncryptDecrypt(byte[] inputBytes, bool Encrpyt)
        {
            ICryptoTransform transform = getCryptoTransform(Encrpyt);

            MemoryStream memStream = new MemoryStream();

            try
            {
                CryptoStream cryptStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);

                cryptStream.Write(inputBytes, 0, inputBytes.Length);

                cryptStream.FlushFinalBlock();

                byte[] output = memStream.ToArray();

                cryptStream.Close();

                return output;
            }
            catch (Exception e)
            {
                throw new Exception("Error in symmetric engine. Error : " + e.Message, e);
            }
        }

        private ICryptoTransform getCryptoTransform(bool encrypt)
        {
            SymmetricAlgorithm SA = selectAlgorithm();
            SA.Key = mKey;
            SA.IV = mIV;
            if (encrypt)
            {
                return SA.CreateEncryptor();
            }
            else
            {
                return SA.CreateDecryptor();
            }
        }

        public string Decrypt(string inputText)
        {
            UTF8Encoding UTF8Encoder = new UTF8Encoding();
            byte[] inputBytes = Convert.FromBase64String(inputText);

            return UTF8Encoder.GetString(EncryptDecrypt(inputBytes, false));
        }

    }
}