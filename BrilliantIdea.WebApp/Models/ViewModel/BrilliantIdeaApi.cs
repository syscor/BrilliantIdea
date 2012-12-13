using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using RestSharp;

namespace BrilliantIdea.WebApp.Models.ViewModel
{
    public class BrilliantIdeaApi
    {

        private readonly string _baseUrl = ConfigurationManager.AppSettings["apiUrl"];
        private readonly string _accountSid;
        private readonly string _secretKey;

        public BrilliantIdeaApi(string accountSid, string secretKey)
        {
            _accountSid = accountSid;
            _secretKey = secretKey;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient
                {
                    BaseUrl = _baseUrl,
                    Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey)
                };

            request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment); // used on every request
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return response.Data;
        }
    }
}