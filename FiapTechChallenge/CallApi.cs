using System.Text;

namespace FiapTechChallenge
{
    public class CallApi
    {
        public async Task<string> GetKey(string key, HttpClient client, Uri uri)
        {
            string jsonBody2 = "{\"key\":\"" + key + "\"}";
            HttpContent content = new StringContent(jsonBody2, Encoding.UTF8, "application/json");
            var content1 = client.PostAsync(uri, content).Result;

            if ((int)content1.StatusCode >= 204) Console.Write(".");
            
            Console.WriteLine($"Chave encontrada: {key}");
            return await Task.FromResult($"Chave encontrada: {key}");
        }
    }
}
