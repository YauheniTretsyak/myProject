using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeAccounting.Web.Models
{
    public class UsersKnowledgeViewModel
    {
        public int UsersKnowledgeId { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Range(1, 5, ErrorMessage = "Must be from 1 to 5")]
        public int Degree { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public int KnowledgeId { get; set; }



    }
}