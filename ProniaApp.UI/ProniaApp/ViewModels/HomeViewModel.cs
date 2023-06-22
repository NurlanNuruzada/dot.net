﻿
using Pronia.Core.Entities;

namespace ProniaApp.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider>? Sliders { get; set; }
        public IEnumerable<Shipping>? Shippings { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Banner>? Banners { get; set; }


    }

}
