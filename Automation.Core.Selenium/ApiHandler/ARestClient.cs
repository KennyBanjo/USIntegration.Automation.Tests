using System;
using System.Collections.Generic;
using Automation.Core.Selenium.APIHandler.Token;
using Automation.Core.Selenium.ComponentHelper;
using Automation.Core.Selenium.Config;
using Newtonsoft.Json;
using RestSharp;

namespace Automation.Core.Selenium.APIHandler
{
    public abstract class ARestClient {
        // Includes most connection logic
        public string bearer_token { get; set; }
        public TokenResponse token;
        private string postUrl = "https://test.salesforce.com/services/oauth2/token?";
        
        public void GetToken(string userName, string password, string clientId, string clientSecret)
        {

            var client = new RestClient(postUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddQueryParameter("grant_type", "password");
            request.AddQueryParameter("username", userName);
            request.AddQueryParameter("password", password);
            request.AddQueryParameter("client_id", clientId);
            request.AddQueryParameter("client_secret", clientSecret);
            
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                LogHelper.Info(response.ContentType);
                LogHelper.Info(response.StatusCode);
                LogHelper.Info(response.Content);
            
                // token = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
                bearer_token = "Bearer" + " " + JsonConvert.DeserializeObject<TokenResponse>(response.Content).access_token;
            }
        }
        
        public virtual IRestClient GetRestClient()
        {
            IRestClient restClient = new RestClient();
            return restClient;
        }
        
        public virtual IRestRequest GetRestRequest(string url, Dictionary<string, string> headers, Method method, object body,
            DataFormat dataformat, string param)
        {
            IRestRequest restRequest = new RestRequest()
            {
                Method = method,
                Resource = url
            };

            if (headers != null)
            {
                foreach (var key in headers.Keys)
                {
                    restRequest.AddHeader(key, headers[key]);
                    restRequest.AddHeader("Authorization", bearer_token);
                }
            }
            else
            {
                restRequest.AddHeader("Authorization", bearer_token);
            }

            if (method == Method.POST || method == Method.PATCH || method == Method.DELETE)
            {
                restRequest.AddParameter("application/json", $"{param}", ParameterType.RequestBody);
            }

            if (body != null)
            {
                restRequest.AddJsonBody(dataformat);
                restRequest.AddJsonBody(body);
            }

            return restRequest;
        }

        protected virtual IRestResponse SendRequest(IRestRequest restRequest)
        {
            IRestClient restClient = new RestClient();
            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        protected  virtual IRestResponse<T> SendRequest<T>(IRestRequest restRequest) where T : new()
        {
            IRestClient restClient = new RestClient();
            IRestResponse<T> restResponse = restClient.Execute<T>(restRequest);
            return restResponse;
        }

        public IRestResponse PerformGetRequest(string url, Dictionary<string, string> headers)
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.GET, null, DataFormat.None, null);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }

        public IRestResponse<T> PerformGetRequest<T>(string url, Dictionary<string, string> headers) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.GET, null, DataFormat.None, null);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }

        public IRestResponse PerformPostRequest(string url, Dictionary<string, string> headers, object body, DataFormat dataFormat, string param)
        {
            IRestRequest restRequest =  GetRestRequest(url, headers, Method.POST, body, dataFormat, param);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }

        public IRestResponse<T> PerformPostRequest<T>(string url, Dictionary<string, string> headers, object body,
            DataFormat dataFormat, string param) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.POST, body, dataFormat, param);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }
        
        public IRestResponse PerformPatchRequest(string url, Dictionary<string, string> headers, object body,
            DataFormat dataFormat, string param)
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.PATCH, body, dataFormat, param);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }
        
        public IRestResponse<T> PerformPatchRequest<T>(string url, Dictionary<string, string> headers, object body,
            DataFormat dataFormat, string param) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.PATCH, body, dataFormat, param);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }
        
        public IRestResponse<T> PerformPutRequest<T>(string url, Dictionary<string, string> headers, object body,
            DataFormat dataFormat, string param) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.PUT, body, dataFormat, param);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }
        
        public IRestResponse PerformDeleteRequest(string url, string param)
        {
            IRestRequest restRequest = GetRestRequest(url, null, Method.DELETE, null, DataFormat.None, param);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }
        
       
    }
}