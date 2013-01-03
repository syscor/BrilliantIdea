using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
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

            return response.Data;
        }
        /// <summary>
        /// Execute para eventos POST, PUT ...
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Execute(RestRequest request)
        {
            var client = new RestClient
                {
                    BaseUrl = _baseUrl,
                    Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey)
                };
            request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment);
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);
            if (response.StatusCode!=HttpStatusCode.BadRequest)
            {
                response.Content = "success";
            }
            return response.Content;
        }
    }
}