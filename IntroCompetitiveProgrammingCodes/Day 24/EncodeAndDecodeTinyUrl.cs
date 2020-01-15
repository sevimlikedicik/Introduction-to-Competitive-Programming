namespace IntroCompetitiveProgrammingCodes.Day_24
{
    class EncodeAndDecodeTinyUrl
    {
        public class Codec
        {

            // Encodes a URL to a shortened URL
            public string encode(string longUrl)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(longUrl);
                return System.Convert.ToBase64String(plainTextBytes);
            }

            // Decodes a shortened URL to its original URL.
            public string decode(string shortUrl)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(shortUrl);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
        }
    }
}
