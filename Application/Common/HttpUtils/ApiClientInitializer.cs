﻿using System.Net.Http.Headers;

namespace Common.HttpUtils
{
    public class ApiClientInitializer
    {
        public static HttpClient ApiClient { get; set; }
        public static HttpClient GetClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri(baseAddress);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return ApiClient;
        }
    }
}
