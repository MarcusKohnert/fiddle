using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace ProxyAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = new Uri("http://www.google.de");
            var p = new Program();

            //p.WebClientWithoutCredentialsSet(address);
            //p.WebClientWithCredentialsSet(address);
            //p.WebRequest_(address);
            p.WebRequest_SetDefaultCredentials(address);
            //p.HttpClient(address);
            //p.HttpClientWhitchClientHandler(address);

            Console.ReadLine();
        }

        /// <summary>
        /// Will not work behind proxy, if app.config does not specify defaultProxy useDefaultCredentials
        /// </summary>
        /// <param name="address"></param>
        private void WebClientWithoutCredentialsSet(Uri address)
        {
            try
            {
                
                var client = new WebClient();
                var source = client.DownloadString(address).Substring(0, 500);
                Console.WriteLine(source);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Will work without app.config settings
        /// </summary>
        /// <param name="address"></param>
        private void WebClientWithCredentialsSet(Uri address)
        {
            var client = new WebClient();
            client.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            var s = client.DownloadString(address).Substring(0, 500);
            Console.WriteLine(s);
        }

        /// <summary>
        /// Will work without app.config settings
        /// </summary>
        /// <param name="address"></param>
        private void WebRequest_(Uri address)
        {
            var webRequest = WebRequest.CreateHttp(address);
            webRequest.Proxy = WebRequest.GetSystemWebProxy();
            webRequest.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            var response = webRequest.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var s = reader.ReadToEnd().Substring(0, 500);
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Will work without app.config settings and without specific instance of WebRequest
        /// </summary>
        /// <param name="address"></param>
        private void WebRequest_SetDefaultCredentials(Uri address)
        {
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            var webRequest = WebRequest.CreateHttp(address);
            var response = webRequest.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var s = reader.ReadToEnd().Substring(0, 500);
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Will work with app.config set.
        /// </summary>
        /// <param name="address"></param>
        private void HttpClient(Uri address)
        {
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(address).Result.Substring(0, 500);
            Console.WriteLine(html);
        }

        /// <summary>
        /// Will work without app.config set
        /// </summary>
        /// <param name="address"></param>
        private void HttpClientWhitchClientHandler(Uri address)
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.Proxy = WebRequest.GetSystemWebProxy();
            clientHandler.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            var httpClient = new HttpClient(clientHandler);
            var html = httpClient.GetStringAsync(address).Result.Substring(0, 500);
            Console.WriteLine(html);
        }
    }
}