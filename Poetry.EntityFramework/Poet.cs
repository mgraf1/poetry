using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.EntityFramework
{
    [Table("Poet")]
    public class Poet
    {
        [Key]
        int Id { get; set; }
    }
}
