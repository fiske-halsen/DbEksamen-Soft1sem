using ApiGateway.Models;
using Common.HttpUtils;
using IdentityModel.Client;
using Newtonsoft.Json;
using System.Text;

namespace ApiGateway.Service
{
    public class ApiService
    {
        private readonly TokenService _tokenService;
        public ApiService(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<T>> Get<T>(string url, ApplicationCredentials credentials)
        {
            var apiClient = ApiClientInitializer.GetClient();

            var token = await _tokenService.RequestTokenClientApplication(credentials.ClientId, credentials.ClientSecret, credentials.Scope);

            apiClient.SetBearerToken(token.Token.AccessToken);

            using (var response = await apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    IEnumerable<T> result = JsonConvert.DeserializeObject<IEnumerable<T>>(content);
                    return result;
                }
                else
                {
                    throw new Exception("Not working");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> GetSingle<T>(string url, ApplicationCredentials credentials)
        {
            var apiClient = ApiClientInitializer.GetClient();

            var token = await _tokenService.RequestTokenClientApplication(credentials.ClientId, credentials.ClientSecret, credentials.Scope);

            apiClient.SetBearerToken(token.Token.AccessToken);

            using (var response = await apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<T>(content);
                    return result;
                }
                else
                {
                    throw new Exception("Not working");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="contentJson"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<bool> Post(string url, string contentJson, ApplicationCredentials credentials)
        {
            var apiClient = ApiClientInitializer.GetClient();

            var token = await _tokenService.RequestTokenClientApplication(credentials.ClientId, credentials.ClientSecret, credentials.Scope);

            apiClient.SetBearerToken(token.Token.AccessToken);

            HttpContent httpContent = new StringContent(contentJson, Encoding.UTF8, "application/json");

            using (var response = await apiClient.PostAsync(url, httpContent))
            {
                return response.IsSuccessStatusCode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="contentJson"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<bool> Patch(string url, string contentJson, ApplicationCredentials credentials)
        {
            var apiClient = ApiClientInitializer.GetClient();

            var token = await _tokenService.RequestTokenClientApplication(credentials.ClientId, credentials.ClientSecret, credentials.Scope);

            apiClient.SetBearerToken(token.Token.AccessToken);

            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url);

            request.Content = new StringContent(contentJson, Encoding.UTF8, "application/json");

            using (var response = await apiClient.SendAsync(request))
            {

                return response.IsSuccessStatusCode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string url, ApplicationCredentials credentials)
        {
            var apiClient = ApiClientInitializer.GetClient();

            var token = await _tokenService.RequestTokenClientApplication(credentials.ClientId, credentials.ClientSecret, credentials.Scope);

            apiClient.SetBearerToken(token.Token.AccessToken);

            using (var response = await apiClient.DeleteAsync(url))
            {
                return response.IsSuccessStatusCode;
            }

        }
    }
}
