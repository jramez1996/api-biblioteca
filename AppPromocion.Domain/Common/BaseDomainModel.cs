using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPromocion.Domain.Common
{
    public class BaseDomainModel
    {
        public int IdCreate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? LastCreate { get; set; }

        public int IdUpdate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? LastUpdate { get; set; }

        public int IdDelete { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string? LastDelete { get; set; }
    }
}
