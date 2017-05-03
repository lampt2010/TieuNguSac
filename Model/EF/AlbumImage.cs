namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AlbumImage
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? Number { get; set; }
    }
}
