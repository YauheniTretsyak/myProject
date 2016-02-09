using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeAccounting.Web.Models
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public string Name { get; set; }
    }
}