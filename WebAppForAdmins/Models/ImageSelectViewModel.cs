﻿using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class ImageSelectViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedImageId { get; set; }
        public IList<MainPageImageModel> Images { get; set; } = default!;
    }
}
