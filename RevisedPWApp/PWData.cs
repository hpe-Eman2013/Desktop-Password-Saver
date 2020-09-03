namespace RevisedPWApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class PWData : DbContext
    {
        public PWData()
            : base("name=PWData")
        {
        }

        public virtual DbSet<EmailAccount> EmailAccounts { get; set; }
        public virtual DbSet<PasswordSetting> PasswordSettings { get; set; }
        public virtual DbSet<PasswordTracker> PasswordTrackers { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<EmailAccount>().HasKey(x => x.Id);
            modelBuilder.Entity<PasswordTracker>().HasKey(x => x.ID);
            modelBuilder.Entity<UserAccount>().HasKey(x => x.UserId);
            modelBuilder.Entity<PasswordSetting>().HasKey(x => x.Id);
        }
    }
}
