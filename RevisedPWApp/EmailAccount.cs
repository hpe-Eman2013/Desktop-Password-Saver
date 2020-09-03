namespace RevisedPWApp
{
    using System.ComponentModel.DataAnnotations;

    public partial class EmailAccount
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int UserId { get; set; }

        public string PhotoLocation { get; set; }
    }
}
