namespace RevisedPWApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PasswordTracker")]
    public partial class PasswordTracker
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string ApplicationPath { get; set; }

        [StringLength(255)]
        public string SpecialNotes { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateCreated { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateModified { get; set; }

        public int? UserId { get; set; }
    }
}
