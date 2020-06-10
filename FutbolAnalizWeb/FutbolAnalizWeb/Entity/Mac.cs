namespace FutbolAnalizWeb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mac")]
    public partial class Mac
    {
        [Key]
        public int mac_id { get; set; }

        public int evTk_id { get; set; }

        public int depTk_id { get; set; }

        public int eviy_Sk { get; set; }

        public int depiy_Sk { get; set; }

        public int evms_Sk { get; set; }

        public int depms_Sk { get; set; }

        [Column(TypeName = "date")]
        public DateTime mac_tarih { get; set; }

        public int sezon_id { get; set; }

        public virtual Sezon Sezon { get; set; }

        public virtual Takim Takim { get; set; }

        public virtual Takim Takim1 { get; set; }
    }
}
