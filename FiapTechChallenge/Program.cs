using FiapTechChallenge;

//string[] acentosMinusculas = { "á", "à", "â", "ã", "é", "ê", "í", "ó", "ô", "õ", "ú", "ü" };
//string[] acentosMaiusculas = { "Á", "À", "Â", "Ã", "É", "Ê", "Í", "Ó", "Ô", "Õ", "Ú", "Ü" };

//string[] minusculas = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
//string[] maiusculas = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

string[] alfabetoCompleto = { "á", "à", "â", "ã", "é", "ê", "í", "ó", "ô", "õ", "ú", "ü", "Á", "À", "Â", "Ã", "É", "Ê", "Í", "Ó", "Ô", "Õ", "Ú", "Ü", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

var _ = new CallApi();
var client = new HttpClient();
var uri = new Uri("https://fiap-inaugural.azurewebsites.net/fiap");
client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

var tasks = new List<Task>();
var options = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };

//Parallel.For(1, 10001, options, index =>
//{
//    Parallel.ForEach(alfabetoCompleto, letra =>
//    {
//        string key = string.Concat(letra, index.ToString());
//        tasks.Add(new Task(() => CallApi.GetKey(key, client, uri)));
//    });
//});

Parallel.For(1, 11, options, index =>
{
    foreach (var letra in alfabetoCompleto)
    {
        string key = string.Concat(letra, index.ToString());
        tasks.Add(new Task(async () => await _.GetKey(key, client, uri)));
    };
});

await Task.WhenAll(tasks);
