﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
