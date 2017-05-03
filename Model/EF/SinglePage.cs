namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinglePage")]
    public partial class SinglePage
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public bool Status { get; set; }

        [StringLength(50)]
        public string Lang { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public int? ViewCount { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
