﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityFrame.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}