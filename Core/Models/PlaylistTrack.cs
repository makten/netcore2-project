using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace dashboard.Core.Models
{
[JsonObject]
internal class playlisttrack
{
    public string AddedAt { get; set; }
    public SpotifyUser AddedBy { get; set; }
    public Track Track { get; set; }
    
}
}
