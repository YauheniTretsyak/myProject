﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeAccounting.Web.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "The field can not be empty!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "wrong email")]
        public string Email { get; set; }

        [Display(Name = "Remember you?")]
        public bool RememberMe { get; set; }
    }
}