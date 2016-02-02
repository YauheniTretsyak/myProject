using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class KnowledgeViewModel
    {
        public int KnowledgeId { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public string Name { get; set; }  
    }
}