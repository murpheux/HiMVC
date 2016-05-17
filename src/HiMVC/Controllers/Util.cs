using System;
using System.Text;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Net.Mail;

namespace BellagioService.Library
{
    /// <summary>
    /// Summary description for 
    /// </summary>
    public static class Util
    {
        static UnicodeEncoding ByteConverter = new UnicodeEncoding();

        public static void SendEmail(string[] recipients, string subject, string message)
        {
            var client = new SmtpClient();
            var mailMmessage = new MailMessage();

            mailMmessage.Subject = subject;
            mailMmessage.Body = message;
            mailMmessage.IsBodyHtml = true;

            foreach (var recipient in recipients)
                mailMmessage.To.Add(recipient);

            try
            {
                client.Send(mailMmessage);
            }
            catch (Exception)
            {
            }

        }


        public static bool IsNumeric(String input, NumberStyles numberStyle)
        {
            Double temp;
            bool result = Double.TryParse(input, numberStyle, CultureInfo.CurrentCulture, out temp);
            return result;
        }

        private static string Passphrase = "exodus";

        public static string EncryptString(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            //MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            //byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            //// Step 2. Create a new TripleDESCryptoServiceProvider object
            //TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            //// Step 3. Setup the encoder
            //TDESAlgorithm.Key = TDESKey;
            //TDESAlgorithm.Mode = CipherMode.ECB;
            //TDESAlgorithm.Padding = PaddingMode.PKCS7;

            //// Step 4. Convert the input string to a byte[]
            //byte[] DataToEncrypt = UTF8.GetBytes(Message);

            //// Step 5. Attempt to encrypt the string
            //try
            //{
            //    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            //    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            //}
            //finally
            //{
            //    // Clear the TripleDes and Hashprovider services of any sensitive information
            //    TDESAlgorithm.Clear();
            //    HashProvider.Clear();
            //}

            // Step 6. Return the encrypted string as a base64 encoded string
            return "";// Convert.ToBase64String(Results);
        }

        public static string DecryptString(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            //MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            //byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            //// Step 2. Create a new TripleDESCryptoServiceProvider object
            //TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            //// Step 3. Setup the decoder
            //TDESAlgorithm.Key = TDESKey;
            //TDESAlgorithm.Mode = CipherMode.ECB;
            //TDESAlgorithm.Padding = PaddingMode.PKCS7;

            //// Step 4. Convert the input string to a byte[]
            //byte[] DataToDecrypt = Convert.FromBase64String(Message);

            //// Step 5. Attempt to decrypt the string
            //try
            //{
            //    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
            //    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            //}
            //finally
            //{
            //    // Clear the TripleDes and Hashprovider services of any sensitive information
            //    TDESAlgorithm.Clear();
            //    HashProvider.Clear();
            //}

            // Step 6. Return the decrypted string in UTF8 format
            return "";// UTF8.GetString(Results);
        }

        /// <summary>
        /// Generate long string summary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="size">generated summary length</param>
        /// <returns></returns>
        public static string GetSynopsis(string source, int size = 50)
        {
            if (source.Length <= size)
                return source;
            else
                return source.Substring(0, size - 3) + "...";

        }

        public static int GenerateRandomNumber()
        {
            return new Random().Next(99);
        }

        public static string GenerateLuckyNumber()
        {
            string luckyNumber = string.Format("{0:00}-{1:00}-{2:00}-{3:00}-{4:00}-{5:00}", 
                    GenerateRandomNumber(), GenerateRandomNumber(), GenerateRandomNumber(), 
                    GenerateRandomNumber(), GenerateRandomNumber(), GenerateRandomNumber());

            return luckyNumber;
        }

        internal static object GetDependencyContainer()
        {
            //var container = HttpContext.Current.Application["UnityContainer"] as IUnityContainer;

            //if (container == null)
            //    throw new Exception("ERROR: Unity Container not populated in Global.asax");

            //else
                return null;// container;
        }

        public static object NigerianStates { get; set; }

        public static string GenerateNewAgentId()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(RandomString(2, false));
            builder.Append(RandomNumber(100, 999));

            return builder.ToString();
        }

        public static string GetTransactionNumber()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(RandomString(4, false));
            builder.Append(RandomNumber(10, 99));
            builder.Append(RandomString(2, false));

            return builder.ToString();
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            return random.Next(min, max);
        }

        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random((int)DateTime.Now.Ticks);
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public static string GenerateRandomPassword()
        {
            return string.Format("{0}{1}", RandomString(7, true), RandomNumber(0, 9));
        }

        public static string FormatLuckyNumber(string p1, string p2, string p3, string p4, string p5)
        {
            return string.Format("{0}-{1}-{2}-{3}-{4}", p1, p2, p3, p4, p5);
        }

        public static string FormatLuckyNumber(int p1, int p2, int p3, int p4, int p5)
        {
            return string.Format("{0}-{1}-{2}-{3}-{4}", p1, p2, p3, p4, p5);
        }

        public static bool IsNumeric(string input)
        {

            return Util.IsNumeric(input, NumberStyles.None);
        }

        

        public static bool ValidateLotteryNumber(string luckyNumber)
        {
            if (string.IsNullOrEmpty(luckyNumber))
                return false;

            try
            {
                var numbers = luckyNumber.Split(new char[] { '-' });

                bool status = true;

                foreach (var num in numbers)
                {
                    int res;
                    if (int.TryParse(num, out res))
                        status &= res >= 1 && res <= 90;
                    else
                        status = false;

                }

                return status;
            }
            catch// (Exception ex)
            {

                return false;
            }
        }

        /// <summary>
        /// Deserializes a Byte Array.
        /// </summary>
        /// <param name="serializedObject">The serialised byte stream to be deserialised.</param>
        /// <returns>Returns the deserialized object.</returns>
        public static Object Deserialize(Byte[] serializedObject)
        {
            //if (null != serializedObject)
            //{
            //    MemoryStream ms = new MemoryStream(serializedObject);
            //    IFormatter formatter = (IFormatter)new BinaryFormatter();

            //    return formatter.Deserialize(ms);
            //}
            //else
            //{
                return null;
            //}
        }

        /// <summary>
        /// Serializes an object into a byte array.
        /// </summary>
        /// <param name="objectToSerialize">the Object to be serialised.</param>
        /// <returns>Returns a byte array of the seriailsed object.</returns>
        public static Byte[] Serialize(Object objectToSerialize)
        {
            //if (null != objectToSerialize)
            //{
            //    MemoryStream ms = new MemoryStream();
            //    IFormatter formatter = (IFormatter)new BinaryFormatter();
            //    formatter.Serialize(ms, objectToSerialize);
            //    byte[] serializedObject = new byte[ms.Length];
            //    serializedObject = ms.GetBuffer();
            //    ms.Close();

            //    return serializedObject;
            //}
            //else
            //{
                return null;
            //}
        }

        internal static string GetRandomPin()
        {
            return string.Format("{0}{1}{2}{3}", RandomNumber(0, 9), RandomNumber(0, 9), RandomNumber(0, 9), RandomNumber(0, 9));
        }
    }


    public static class Constants
    {

        public const string SVC_STATUS_OK = "0";

        public const string SVC_INSUFFICIENT_CREDIT = "11";

        public const string SVC_OBJECT_NOT_EXIST = "13";

        public static string SVC_INVALID_DRAW = "15";

        public const string SVC_INVALID_ENTRY = "17"; //"Inavalid entry";

        public const string SVC_MISSING_PAYLOAD = "19";

        public static string SVC_DRAW_CLOSED = "21";

        public static string SVC_SEQUENCE_DUPLICATED = "23";

        public static string SVC_INVALID_CREDENTIAL = "25";

        public const string SVC_INVALID_REFILL = "27";

        public const string SVC_VENDOR_SUSPENDED = "29";

        public const string SVC_STATUS_ERROR = "99";



        // Web app response message

        public const string ENTRY_ACCEPTED_LONG = "Thank you. Your entry has been accepted!";

        public const string INVALID_ENTRY = "Invalid Lucky entry!";

        public const string INVALID_ENTRY_MESSAGE = "One or more Winning Number Invalid!";

        public const string NO_DRAW_EXIST = "No Draw in Play!";

        // email content

        public const string PASSWORD_RESET_MSG = "Your password has been resent to {0}";

        public const string BATCH_NUMBER_EXIST = "Batch Number already exist. Use another!";
        
        public const string INVALID_FILE = "No file or invalid file selected for upload!";

        public const string PAYLOAD_ERROR = "Payload missing or ";


        public static string DRAW_CACHE = "wavetek.bellagio.draw";
        public static string USER_CACHE_BASE = "wavetek.bellagio.user";
        public static string CONFIG_CACHE = "wavetek.bellagio.config";

        
    }

    public enum Alphabets
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
    }


    internal enum Title
    {
        Honourable,
        Alhaji,
        Senator,
        Otunba,
        Sir,
        Chief,
        Dr,
        Prof,
        Prince,
        Engr,
        Mr,
        Mrs,
        Miss,
        Messrs,
        Justice

    }



}