﻿using Resources.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Resources.Models
{
    public class MainPagePresetModel : BaseModel
    {
        [Required(ErrorMessage = "Имя пресета является обязательным")]
        [StringLength(40, ErrorMessage = "Длина имени пресета не должна превышать 40 символов")]
        public string PresetName { get; set; } = default!;
        public bool IsPublished { get; set; }

        public int? ActionId { get; set; }
        public int? ButtonId { get; set; }
        public int? ImageId { get; set; }
        public int? PhraseId { get; set; }
        public int? TextId { get; set; }
    }
}
