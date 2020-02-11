using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace EmailVerifier
{
    public class Connection
    {
        private static string key;
        private static RestClient client;
        private static RestRequest request;
        private static Task<IRestResponse<EmailData>> responseTask;
        private static IRestResponse<EmailData> response;
        private static ErrorContent error;
        private static EmailData email;

        public Connection()
        {
            client = new RestClient("http://apilayer.net/api/check");
        }
        public static void LoadApiKey()
        {
            try
            {
                key = File.ReadAllText("api_key");
                key = key.Substring(0, key.Length - 1);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine();
                Console.WriteLine("File containing access key for an API request not found.");
                Console.WriteLine("Error message: " + e.Message);
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
        
        public void MakeRequest(string address)
        {
            request = new RestRequest($"?access_key={key}&email={address}");
            try
            {
                responseTask = Task.Factory.StartNew(() => client.Get<EmailData>(request));
                Console.WriteLine();
                while(!responseTask.IsCompleted)
                {
                    Display.ProcessingLoop();
                }
                response = responseTask.Result;
                if (!response.IsSuccessful) throw response.ErrorException;
            }
            catch (System.Net.WebException e)
            {
                Console.WriteLine("Resource unavailable. Check your Internet connection.");
                Console.WriteLine("Error message: " + e.Message.Substring(0, 32));
                return;
            }
            Display.ClearLine();
            if (response.Content.StartsWith("{\"success\""))
            {
                error = JsonConvert.DeserializeObject<ErrorContent>(response.Content);
                Display.ShowErrorInfo(error);
            }
            else
            {
                email = response.Data;
                Display.ShowEmailInfo(email);
            }
        }
    }
}