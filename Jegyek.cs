using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace osztalynaplo.Models
{
    public partial class Jegyek
    {
        public int Id { get; set; }
        public int? JegySzammal { get; set; }
        public string? JegySzoveggel { get; set; }
        public DateTime? BeirasDatuma { get; set; }
        public DateTime? ModositasDatuma { get; set; }

        public int? IdTanarok { get; set; }
        public int? IdTantargyak { get; set; }

        [JsonIgnore]
        public virtual Tanarok? IdTanarokNavigation { get; set; }
        [JsonIgnore]
        public virtual Tantargyak? IdTantargyakNavigation { get; set; }
    }
}
