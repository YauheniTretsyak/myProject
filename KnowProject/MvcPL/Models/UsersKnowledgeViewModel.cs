using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UsersKnowledgeViewModel
    {
        public int UsersKnowledgeId { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public int Degree { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public int KnowledgeId { get; set; }

        

    }
}