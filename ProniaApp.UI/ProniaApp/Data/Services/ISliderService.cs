using Pronia.Core.Entities;

namespace ProniaApp.Data.Services;

public interface ISliderService
{
    Task<IEnumerable<Slider>> GetSliders();
}
