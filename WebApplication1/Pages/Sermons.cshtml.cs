using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KLP.Pages
{
    public class SermonsModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public SermonsModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IReadOnlyList<SermonEntry> Sermons { get; private set; } = Array.Empty<SermonEntry>();

        public void OnGet()
        {
            var sermonsPath = Path.Combine(_environment.ContentRootPath, "Data", "sermons.json");

            if (!System.IO.File.Exists(sermonsPath))
            {
                Sermons = Array.Empty<SermonEntry>();
                return;
            }

            var json = System.IO.File.ReadAllText(sermonsPath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var sermons = JsonSerializer.Deserialize<List<SermonEntry>>(json, options) ?? new List<SermonEntry>();

            Sermons = sermons
                .Where(sermon => !string.IsNullOrWhiteSpace(sermon.Title))
                .OrderByDescending(sermon => sermon.Date)
                .ToList();
        }

        public sealed class SermonEntry
        {
            public DateTime Date { get; init; }
            public string Title { get; init; } = string.Empty;
            public string Series { get; init; } = string.Empty;
            public string Speaker { get; init; } = string.Empty;
            public string Scripture { get; init; } = string.Empty;
            public string Summary { get; init; } = string.Empty;
            public List<string> Tags { get; init; } = new();
        }
    }
}
