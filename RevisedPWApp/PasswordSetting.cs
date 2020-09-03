namespace RevisedPWApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PasswordSetting
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string KeyName { get; set; }

        [Required]
        [StringLength(100)]
        public string KeyValue { get; set; }
    }
}
