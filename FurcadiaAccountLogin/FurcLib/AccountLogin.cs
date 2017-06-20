using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Furcadia

{
    public class AccountLogin
    {
        #region Private Fields

        private static CookieCollection oCookies;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Retriev Account information from the Furcadia Log-On server
        /// </summary>
        /// <param name="u">
        /// Account E-mail address
        /// </param>
        /// <param name="p">
        /// Account Password
        /// </param>
        /// <param name="k">
        /// API Key
        /// </param>
        /// <param name="LoginUrl">
        /// Login Server URL
        /// </param>
        /// <returns>
        /// Furcadia Account information including Characters and thier costumes
        /// </returns>
        public static string getFurcadiaCharacters(string u, string p, string k, string LoginUrl)
        {
            var message = new StringBuilder();
            var LoginWebRequest = (HttpWebRequest)WebRequest.Create(LoginUrl);
            var postData = new StringBuilder();
            var PostDataEncoding = Encoding.GetEncoding(1252);

            string SilverMonkeyUserAgent = "Silver Monkey Bot Client";

            postData.AppendFormat("{0}={1}", HttpUtility.UrlEncode("u"), HttpUtility.UrlEncode(u));
            postData.AppendFormat("&{0}={1}", HttpUtility.UrlEncode("p"), HttpUtility.UrlEncode(p));
            postData.AppendFormat("&{0}={1}", HttpUtility.UrlEncode("k"), HttpUtility.UrlEncode(k));
            postData.AppendFormat("&{0}={1}", HttpUtility.UrlEncode("v"), HttpUtility.UrlEncode("31_0_aft"));

            message.AppendLine("postData:");
            message.AppendLine(postData.ToString());

            byte[] PostArray = PostDataEncoding.GetBytes(postData.ToString());

            // *** Set any header related and operational properties
            LoginWebRequest.Method = "POST";
            LoginWebRequest.UserAgent = SilverMonkeyUserAgent;
            LoginWebRequest.ContentType = "application/x-www-form-urlencoded";

            // Is this how we handle PostData KeyValues?
            Stream PostDataStream = LoginWebRequest.GetRequestStream();
            PostDataStream.Write(PostArray, 0, PostArray.Length);
            PostDataStream.Close();

            // *** reuse cookies if available
            LoginWebRequest.CookieContainer = new CookieContainer();

            if (oCookies != null && oCookies.Count > 0)
            {
                LoginWebRequest.CookieContainer.Add(oCookies);
            }
            try //If we did things right, we'll see XML data
            {
                using (HttpWebResponse response = LoginWebRequest.GetResponse() as HttpWebResponse)

                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    message.Append(reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                message.AppendLine("Logon Failed");
                message.AppendLine("Exception Message :" + ex.Message);
                if (ex.Response != null)
                    for (int i = 0; i < ex.Response.Headers.Count; ++i)
                        message.AppendLine(string.Format("Header Name:{0}, Header value :{1}", ex.Response.Headers.Keys[i], ex.Response.Headers[i]));

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    message.AppendLine(string.Format("Status Code : {0}", ((HttpWebResponse)ex.Response).StatusCode));
                    message.AppendLine(string.Format("Status Description : {0}", ((HttpWebResponse)ex.Response).StatusDescription));
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        message.Append(reader.ReadToEnd().Replace("\n", "\r\n"));
                    }
                }
            }
            return message.ToString();
        }

        #endregion Public Methods
    }
}