using System.Text.RegularExpressions;

namespace Practice;

public class WebTraversal
{
    public async Task Run(string root, int maxLinksNumber = 500)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(root);
        var content = await response.Content.ReadAsStringAsync();

        var regex = new Regex(@"(http|http(s)://)([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?");
        var matches = regex.Matches(content);
        
        Console.WriteLine(matches.Count);
        // Implement me
        
        void Traverse(string link)
        {
            // Implement me
        }
    }
}