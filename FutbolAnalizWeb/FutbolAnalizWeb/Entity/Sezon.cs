namespace FutbolAnalizWeb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sezon")]
    public partial class Sezon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sezon()
        {
            Mac = new HashSet<Mac>();
        }

        [Key]
        public int sezon_id { get; set; }

        public int sezon_yil { get; set; }

        public int lig_id { get; set; }

        public virtual Lig Lig { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mac> Mac { get; set; }
    }
}
