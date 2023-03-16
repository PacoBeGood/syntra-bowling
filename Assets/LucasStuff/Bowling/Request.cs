using System.Collections;
using System;
using UnityEngine.Networking;
using UnityEngine;

namespace CodeCoaching
{
    public static class Request
    {
        public static string baseUrl { get; set; }

        static string ProcessUrl(string url)
        {
            if (string.IsNullOrEmpty(baseUrl) && url.StartsWith("/"))
            {
                throw new Exception("Provide a full url, e.g. 'https://example.com/api/some-end-point or provide a baseUrl and pass in the end point as the parameter,\ne.g. Request.baseUrl = 'https://example.com/api' and url parameter: '/some-end-point'");
            }

            if (url.StartsWith("/")) url = baseUrl + url;
            return url;
        }

        public static IEnumerator getImage(string url, Action<Texture2D> handleResponse)
        {
            url = ProcessUrl(url);

            using (UnityWebRequest request = new UnityWebRequest(url, "GET"))
            {
                request.downloadHandler = new DownloadHandlerTexture();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("Accept", "application/json");

                yield return request.SendWebRequest();

                Texture2D apiReponse = DownloadHandlerTexture.GetContent(request);
                handleResponse(apiReponse);
            }
        }
    }
}