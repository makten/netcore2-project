using System;

namespace dashboard.Core.Models {
    internal class Accesstoken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }

        public AuthenticationToken ToPOCO()
        {
            AuthenticationToken token = new AuthenticationToken();
            token.Access_Token = this.access_token;
            token.ExpiresOn = DateTime.Now.AddSeconds(this.expires_in);
            token.Refresh_Token = this.refresh_token;
            token.Token_Type = this.token_type;

            return token;
        }
    }
}