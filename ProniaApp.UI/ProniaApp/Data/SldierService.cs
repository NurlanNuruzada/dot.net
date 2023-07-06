using Pronia.Core.Interfaces;
using Pronia.DataAcces.DBContext;

namespace ProniaApp.Data;

public class SldierService
{
    private readonly AppDbContext _context;
    private readonly IViewService _viewService;
    public SldierService(IViewService viewService)
    {
        _viewService = viewService;
    }

    public void SendDataToView(string data)
    {
        _viewService.DisplayData(data);
    }

}
