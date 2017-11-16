using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using dashboard.Core;
using dashboard.Core.Models;
using dashboard.Helpers;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.Extensions.Options;

namespace dashboard.Controllers
{
    [Route("/api/player/")]
    public class PlaylistsController : Controller
    {
        public readonly IMapper Mapper;
        private readonly ISpotifyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SpotifySettings _spotifySettings;

        public PlaylistsController(IMapper mapper, ISpotifyRepository repository, IUnitOfWork unitOfWork,
            IOptionsSnapshot<SpotifySettings> spotifySettings)
        {
            Mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _spotifySettings = spotifySettings.Value;
        }


        [HttpGet("auth/GetSpotifyAuthCode/{accessCode}")]
        public async Task<IActionResult> GetSpotifyAuthCode(FromBodyAttribute authCode, string accessCode)
        {
            var authToken = GetAuthToken(accessCode);

            var userResponse = await SpotifyUser.GetCurrentUserProfile(authToken);

            return Ok(userResponse);
        }

        [HttpGet("auth/{code}/spotifyuser")]
        public async Task<IActionResult> GetSpotifyUser(FromBodyAttribute authCode, string code)
        {
            var authToken = GetAuthToken(code);

            var userResponse = await SpotifyUser.GetCurrentUserProfile(authToken);

            return Ok(userResponse);
        }


        [HttpGet("auth/{code}/currentlyplaying")]
        public async Task<IActionResult> GetCurrentlyPlaying(string code)
        {
            var authToken = GetAuthToken(code);

            var userResponse = await SpotifyUser.GetCurrentUserProfile(authToken);
            var playingNow = await userResponse.GetCurrentlyPlaying(authToken);

            return Ok(authToken);
        }

        [HttpGet("auth/{code}/player")]
        public async Task<IActionResult> GetPlayer(string code)
        {
            var authToken = GetAuthToken(code);

            var userResponse = await SpotifyUser.GetCurrentUserProfile(authToken);
            var playingNow = await userResponse.GetPlayer(authToken);

            return Ok(playingNow);
        }


        private AuthenticationToken GetAuthToken(string code)
        {
            Authentication.ClientId = _spotifySettings.ClientId;
            Authentication.ClientSecret = _spotifySettings.ClientSecret;
            Authentication.RedirectUri = _spotifySettings.RedirectUrl;

            return Authentication.GetAccessToken(code);
        }
    }
}