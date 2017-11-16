using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dashboard.Helpers;
using Newtonsoft.Json;

namespace dashboard.Core.Models
{
    public class Authentication : BaseModel
    {
        public static string ClientId { get; set; }

        public static string ClientSecret { get; set; }

        public static string RedirectUri { get; set; }


        public static AuthenticationToken GetAccessToken(string code)
        {
            var webClient = new WebClient();

            var postparams = new NameValueCollection();

            postparams.Add("client_id", ClientId);
            postparams.Add("client_secret", ClientSecret);
            postparams.Add("grant_type", "authorization_code");
            postparams.Add("code", code);
            postparams.Add("redirect_uri", RedirectUri);

            return HttpHelper.Post("https://accounts.spotify.com/api/token", postparams);

        }
    }
}