namespace FutbolAnalizWeb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lig")]
    public partial class Lig
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lig()
        {
            Sezon = new HashSet<Sezon>();
            Takim = new HashSet<Takim>();
        }

        [Key]
        public int lig_id { get; set; }

        [Required]
        public string lig_ad { get; set; }

        [Required]
        public string lig_ulke { get; set; }

        [Column(TypeName = "image")]
        public byte[] lig_logo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sezon> Sezon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Takim> Takim { get; set; }
    }
}
