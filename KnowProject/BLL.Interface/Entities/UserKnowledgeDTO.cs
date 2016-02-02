using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class UserKnowledgeDTO
    {
        public int UsersKnowledgeId { get; set; }
        public int Degree { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }

        public int KnowledgeId { get; set; }

    }
}
