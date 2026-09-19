using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KLP.Pages
{
    public class SoupKitchenModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public SoupKitchenModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public SoupKitchenContent PageContent { get; private set; } = SoupKitchenContent.Empty();

        public void OnGet()
        {
            var path = Path.Combine(_environment.ContentRootPath, "Data", "soup-kitchen.json");
            if (!System.IO.File.Exists(path))
            {
                return;
            }

            var json = System.IO.File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var loaded = JsonSerializer.Deserialize<SoupKitchenContent>(json, options);
            if (loaded is not null)
            {
                PageContent = loaded;
            }
        }

        public sealed class SoupKitchenContent
        {
            public string Title { get; init; } = "Soup Kitchen";
            public string Subtitle { get; init; } = string.Empty;
            public string HeroImage { get; init; } = "/Images/soup.png";
            public string Mission { get; init; } = string.Empty;
            public List<string> Schedule { get; init; } = new();
            public List<ImpactStat> ImpactStats { get; init; } = new();
            public List<GalleryItem> Gallery { get; init; } = new();
            public List<InvolvementItem> GetInvolved { get; init; } = new();
            public List<string> DonationMethods { get; init; } = new();
            public ContactDetails Contact { get; init; } = new();

            public static SoupKitchenContent Empty() => new();
        }

        public sealed class ImpactStat
        {
            public string Label { get; init; } = string.Empty;
            public string Value { get; init; } = string.Empty;
        }

        public sealed class GalleryItem
        {
            public string Image { get; init; } = string.Empty;
            public string Title { get; init; } = string.Empty;
            public string Description { get; init; } = string.Empty;
            public string Layout { get; init; } = "small";
        }

        public sealed class InvolvementItem
        {
            public string Title { get; init; } = string.Empty;
            public string Description { get; init; } = string.Empty;
        }

        public sealed class ContactDetails
        {
            public string Name { get; init; } = string.Empty;
            public string Phone { get; init; } = string.Empty;
            public string Email { get; init; } = string.Empty;
        }
    }
}
