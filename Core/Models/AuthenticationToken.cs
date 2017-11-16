using System;

namespace dashboard.Core.Models
{
    public class AuthenticationToken
    {
        private string access_Token;
        public string Access_Token
        {
            get
            {
                if (HasExpired)
                    Refresh();
                return access_Token;
            }
            set
            {
                access_Token = value;
            }
        }
        public string Token_Type { get; set; }
        public double Expires_In { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Refresh_Token { get; set; }

        public bool HasExpired => DateTime.Now > ExpiresOn;

        public void Refresh()
        {
            var token = Authentication.GetAccessToken(this.Refresh_Token);
            this.Access_Token = token.access_Token;
            this.ExpiresOn = token.ExpiresOn;
            this.Refresh_Token = token.access_Token;
            this.Token_Type = this.Token_Type;
        }
       
    }

}