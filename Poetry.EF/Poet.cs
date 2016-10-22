using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.EF
{
    [Table("Poet", Schema ="Poetry")]
    public class Poet
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
