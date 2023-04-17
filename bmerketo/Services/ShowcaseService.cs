using bmerketo.Models;

namespace bmerketo.Services;

public class ShowcaseService
{
    private readonly List<ShowcaseModel> _showcases = new()
    {
        new ShowcaseModel()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair Gold Collection",
            ImageUrl = "images/placeholders/625x647.svg",
            Link = new LinkButtonModel()
            {
                Content = "SHOW NOW",
                Url = "/products"
            }
        }
    };

    public ShowcaseModel GetLatest()
    {
        return _showcases.LastOrDefault()!;
    }
}
