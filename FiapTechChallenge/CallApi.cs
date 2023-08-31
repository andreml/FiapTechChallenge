using System.Text;

namespace FiapTechChallenge
{
    public class CallApi
    {
        public async Task<bool> GetKey(string key, HttpClient client, Uri uri)
        {
            string jsonBody2 = "{\"key\":\"" + key + "\"}";
            HttpContent content = new StringContent(jsonBody2, Encoding.UTF8, "application/json");
            var content1 = client.PostAsync(uri, content).Result;

            if ((int)content1.StatusCode == 200)
            {
                Console.WriteLine($"Chave encontrada: {key}");
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public List<string> GetRandomKey(int init, int total, string[] letter)
        {
            Random r = new Random();
            List<string> list = new List<string>();
            string[] revertLetters = letter.Reverse().ToArray();         

            letter.AsParallel().ForAll(letter =>
            {
                revertLetters.AsParallel().ForAll(letterRevert =>
                {
                    var key = letter + r.Next(init, total) + letterRevert;
                    list.Add(key);
                });
            });

            letter.AsParallel().ForAll(letter =>
            {
                revertLetters.AsParallel().ForAll(letterRevert =>
                {
                    var key = letter.ToLower() + r.Next(init, total) + letterRevert;
                    list.Add(key);
                });
            });

            letter.AsParallel().ForAll(letter =>
            {
                revertLetters.AsParallel().ForAll(letterRevert =>
                {
                    var key = letter.ToLower() + r.Next(init, total) + letterRevert.ToLower();
                    list.Add(key);
                });
            });

            letter.AsParallel().ForAll(letter =>
            {
                revertLetters.AsParallel().ForAll(letterRevert =>
                {
                    var key = letter + r.Next(init, total) + letterRevert.ToLower();
                    list.Add(key);
                });
            });

            letter.AsParallel().ForAll(letter =>
            {
                revertLetters.AsParallel().ForAll(letterRevert =>
                {
                    var key = r.Next(init, total) + letterRevert.ToLower();
                    list.Add(key);
                });
            });

            letter.AsParallel().ForAll(letter =>
            {
                revertLetters.AsParallel().ForAll(letterRevert =>
                {
                    var key = r.Next(init, total) + letterRevert;
                    list.Add(key);
                });
            });

            letter.AsParallel().ForAll(letter =>
            {
                revertLetters.AsParallel().ForAll(letterRevert =>
                {
                    var key = letterRevert + r.Next(init, total);
                    list.Add(key);
                });
            });

            letter.AsParallel().ForAll(letter =>
            {
                revertLetters.AsParallel().ForAll(letterRevert =>
                {
                    var key = letterRevert.ToLower() + r.Next(init, total);
                    list.Add(key);
                });
            });

            return list;
        }
    }
}
