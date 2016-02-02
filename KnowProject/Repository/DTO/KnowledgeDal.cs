using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class KnowledgeDal : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
