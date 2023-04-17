using bmerketo.Models;

namespace bmerketo.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Home";
    public GridCollectionViewModel BestCollection { get; set; } = null!;
}
