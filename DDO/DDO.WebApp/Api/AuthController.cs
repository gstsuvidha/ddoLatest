using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Microsoft.Extensions.Configuration;
using DDO.Domain.Accounting;

namespace DDO.WebApp.Api
{
  
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IAccountingUnitRepository _userProfileRepository;
        private readonly IMapper _mapper;
        private readonly string _clientId;
        private readonly string _audience;


        private readonly HttpClient _httpClient;
        private string tokenUrl = "oauth/token";
        private string userProfileUrl = "userinfo";

        public AuthController(IAccountingUnitRepository userProfileRepository, IConfiguration iconfiguration, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;


            _clientId = iconfiguration.GetSection("Auth0Settings").GetSection("ClientId").Value;
            _audience = iconfiguration.GetSection("Auth0Settings").GetSection("Audience").Value;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(iconfiguration.GetSection("Auth0Settings").GetSection("Host").Value),
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();

        }


        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> GetAuthToken([FromBody] LoginDetail loginDetail)
        {
            var tokenResponse = await GetTokenAsyncFromAuth0(loginDetail.UserName, loginDetail.Password);

            if (String.IsNullOrEmpty(tokenResponse.AccessToken))
                return BadRequest();

            var userProfile = await GetUserInfoFromAuth0(tokenResponse.AccessToken);

            var accountingUnit = await _userProfileRepository.GetAsync(loginDetail.UserName);

            tokenResponse.UserProfile = new UserProfile(userProfile.UserId,
                                                        userProfile.Name,
                                                        userProfile.Email,
                                                        accountingUnit.Role
                                                       );

            return Ok(tokenResponse);
        }

        private async Task<TokenResponse> GetTokenAsyncFromAuth0(string userName, string password)
        {

            var rawResult = await _httpClient.PostAsync(tokenUrl, new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type","password"),
                new KeyValuePair<string, string>("client_id",_clientId),
                new KeyValuePair<string, string>("audience",_audience),
                new KeyValuePair<string, string>("username",userName),
                new KeyValuePair<string, string>("password",password),
                new KeyValuePair<string, string>("scope","openid"),
            }));

            //return await rawResult.Content.ReadAsAsync<TokenResponse>();

            var data = await rawResult.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TokenResponse>(data);
        }

        private async Task<UserProfile> GetUserInfoFromAuth0(string access_token)
        {

            _httpClient.DefaultRequestHeaders.Authorization =
                                new AuthenticationHeaderValue("Bearer", access_token);

            var rawResult = await _httpClient.GetAsync(userProfileUrl);

            var data = await rawResult.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserProfile>(data);
        }
    }

    internal class UserProfile
    {
        [JsonProperty("sub")]
        public string UserId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }


       public string Role { get; set; }

        public UserProfile(string userId, string name, string email , string role
        )
        {
            UserId = userId;
            Name = name;
            Email = email;
            Role = role;
            }


    }

    public class LoginDetail
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    internal class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }


        public UserProfile UserProfile { get; set; }
    }

}