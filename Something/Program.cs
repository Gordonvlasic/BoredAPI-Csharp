using System.Net.Http;
using Newtonsoft.Json;

class Program
{
    HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        Program program = new Program();
        await program.GetTodoItems();
    }

    private async Task GetTodoItems()
    {
        string response = await client.GetStringAsync(
            "https://www.boredapi.com/api/activity");

        Todo todo = JsonConvert.DeserializeObject<Todo>(response);

        Console.WriteLine(todo);
    }

    public class Todo
    {
        public string activity { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public int participants { get; set; }
        public double price { get; set; }
        public string link { get; set; } = string.Empty;
        public string key { get; set; } = string.Empty;
        public double accessibility { get; set; }

        public override string ToString()
        {
            return $"The activity that you should consider doing: {activity}.\nIt requires {participants} person(s)." +
                $"\nThe type of activity: {type}.";
        }
    }
}