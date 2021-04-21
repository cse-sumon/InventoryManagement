﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(50)")]
        public string FullName { get; set; }

    }
}

   