using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TycoonFactory.Db
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Worker(int id, string name) => (Id, Name) = (id, name);
    }
}
