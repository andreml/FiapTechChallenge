using FiapTechChallenge;

string alfabetoCompleto = "A,E,I,O,U,Á,É,Í,Ó,Ú,À,È,Ì,Ò,Ù,Â,Ê,Î,Ô,Û,Ã,Õ,Ä,Ë,Ï,Ö,Ü";
int init = 1;
int total = 10;

var _ = new CallApi();
var client = new HttpClient();
var uri = new Uri("https://fiap-inaugural.azurewebsites.net/fiap");
client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

var tasks = new List<Task>();
var options = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };

var keys = _.GetRandomKey(init, total, alfabetoCompleto.Split(","));

Parallel.ForEach(keys, options, async key =>
{
    if (await _.GetKey(key, client, uri))
    {
        Console.WriteLine("Fim");
    };
});