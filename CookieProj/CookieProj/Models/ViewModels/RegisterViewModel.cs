﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieProj.Models.ViewModels
{
  public class RegisterViewModel
  {
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string ConfirmPassword { get; set; }
  }
}