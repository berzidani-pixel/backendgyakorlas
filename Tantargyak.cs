using System;
using System.Collections.Generic;

namespace osztalynaplo.Models
{
    public partial class Tantargyak
    {
        public Tantargyak()
        {
            Jegyeks = new HashSet<Jegyek>();
        }

        public int Id { get; set; }
        public string? TantargyNev { get; set; }
        public string? TantargyLeiras { get; set; }

        public virtual ICollection<Jegyek> Jegyeks { get; set; }
    }
}
