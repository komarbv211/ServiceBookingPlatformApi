﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.DtoAuthorization
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}