using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dashboard.Core.Models
{
    public class SpotifySettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrl { get; set; }
    }
}
