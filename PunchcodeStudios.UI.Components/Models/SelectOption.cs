﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.UI.Components.Models
{
    public class SelectOption
    {
        public string Text { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool Selected { get; set; } = false;
    }
}
