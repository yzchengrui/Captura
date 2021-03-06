﻿using System;
using System.Drawing;

namespace Captura.Models
{
    public class RegionItem : NotifyPropertyChanged, IVideoItem
    {
        readonly IRegionProvider _selector;
        readonly IPlatformServices _platformServices;

        public RegionItem(IRegionProvider RegionSelector, IPlatformServices PlatformServices)
        {
            _selector = RegionSelector;
            _platformServices = PlatformServices;
        }

        public IImageProvider GetImageProvider(bool IncludeCursor, out Func<Point, Point> Transform)
        {
            Transform = P =>
            {
                var region = _selector.SelectedRegion.Location;

                return new Point(P.X - region.X, P.Y - region.Y);
            };

            return _platformServices.GetRegionProvider(_selector.SelectedRegion,
                IncludeCursor,
                () => _selector.SelectedRegion.Location);
        }

        string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public override string ToString() => Name;
    }
}
