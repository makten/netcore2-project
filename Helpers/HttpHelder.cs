using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using dashboard.Core.Models;
using Newtonsoft.Json;

namespace dashboard.Helpers
{
   
    internal class HttpHelper
    {
        
        public static async Task<string> Get(string url)
        {
            HttpClient client = new HttpClient();
            var httpResponse = await client.GetAsync(url);
            return await httpResponse.Content.ReadAsStringAsync();
        }

        
        public static async Task<string> Get(string url, AuthenticationToken token, bool includeBearer = true)
        {
            var httpClient = new HttpClient();


            if (includeBearer)
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Access_Token);
            else
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Access_Token);

            var httpResponse = await httpClient.GetAsync(url);

            return await httpResponse.Content.ReadAsStringAsync();
        }

        
        public static AuthenticationToken Post(string url, NameValueCollection postparams)
        {
            // var clientId = "1b577309cb494275ada4fe2f3ebce5dc";
            // var clientSecret = "b62724e0ad554e97b69ccbbb79de59aa";
            // var redirect_url = "http://localhost:8080/callback";

            var webClient = new WebClient();

            var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes($"{postparams["client_id"]}:{postparams["client_secret"]}"));
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

            var tokenResponse = webClient.UploadValues(url, postparams);

            var textResponse = Encoding.UTF8.GetString(tokenResponse);
            var authToken = JsonConvert.DeserializeObject<AuthenticationToken>(textResponse);
            authToken.ExpiresOn = DateTime.Now.AddSeconds(authToken.Expires_In);

            return authToken;
        }
        
        public static AuthenticationToken Post(string url, string code)
        {
            var clientId = "1b577309cb494275ada4fe2f3ebce5dc";
            var clientSecret = "b62724e0ad554e97b69ccbbb79de59aa";
            var redirect_url = "http://localhost:8080/callback";

            var webClient = new WebClient();

            var postparams = new NameValueCollection();


            postparams.Add("grant_type", "authorization_code");
            postparams.Add("code", code);
            postparams.Add("redirect_uri", redirect_url);

            var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes($"{clientId}:{clientSecret}"));
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

            var tokenResponse = webClient.UploadValues(url, postparams);

            var textResponse = Encoding.UTF8.GetString(tokenResponse);
            var authToken = JsonConvert.DeserializeObject<AuthenticationToken>(textResponse);
            authToken.ExpiresOn = DateTime.Now.AddSeconds(authToken.Expires_In);

            return authToken;
        }

        public static async Task<string> Post(string url, AuthenticationToken token,
            Dictionary<string, string> postData = null, bool includeBearer = true)
        {
            HttpContent content = null;
            if (postData != null)
                content = new FormUrlEncodedContent(postData.ToArray<KeyValuePair<string, string>>());
            else
                content = null;

            HttpClient client = new HttpClient();
            if (includeBearer)
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Access_Token);
            else
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Access_Token);

            var httpResponse = await client.PostAsync(url, content);
            return await httpResponse.Content.ReadAsStringAsync();
        }

       
        public static async Task<string> Post(string url, AuthenticationToken token, string jsonString,
            bool includeBearer = true)
        {
            HttpContent content = new StringContent(jsonString);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (includeBearer)
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Access_Token);
            else
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Access_Token);

            var httpResponse = await client.PostAsync(url, content);
            return await httpResponse.Content.ReadAsStringAsync();
        }

        
        public static async Task<string> Put(string url, AuthenticationToken token,
            Dictionary<string, string> postData = null, bool includeBearer = true)
        {
            HttpContent content = null;

            if (postData != null)
                content = new FormUrlEncodedContent(postData.ToArray<KeyValuePair<string, string>>());
            else
                content = null;

            HttpClient client = new HttpClient();
            if (includeBearer)
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Access_Token);
            else
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Access_Token);

            var httpResponse = await client.PutAsync(url, content);
            return await httpResponse.Content.ReadAsStringAsync();
        }

       
        public static async Task<string> Put(string url, AuthenticationToken token, string jsonString,
            bool includeBearer = true)
        {
            HttpContent content = new StringContent(jsonString);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (includeBearer)
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Access_Token);
            else
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Access_Token);

            var httpResponse = await client.PutAsync(url, content);
            return await httpResponse.Content.ReadAsStringAsync();
        }

       
        public static async Task<string> Delete(string url, AuthenticationToken token, bool includeBearer = true)
        {
            HttpClient client = new HttpClient();
            if (includeBearer)
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Access_Token);
            else
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Access_Token);

            var httpResponse = await client.DeleteAsync(url);
            return await httpResponse.Content.ReadAsStringAsync();
        }

        private string GetUri()
        {
            var clientId = "1b577309cb494275ada4fe2f3ebce5dc";
            var clientSecret = "b62724e0ad554e97b69ccbbb79de59aa";
            var redirect_url = "http://localhost:8080/callback";
            var scope = "user-read-private user-read-email";
            var response_type = "code";

            StringBuilder builder = new StringBuilder("https://accounts.spotify.com/authorize/?");
            builder.Append("client_id=" + clientId);
            builder.Append("&response_type=token");
            builder.Append("&redirect_uri=" + redirect_url);
            builder.Append("&scope=" + scope);
            return builder.ToString();
        }
    }
}