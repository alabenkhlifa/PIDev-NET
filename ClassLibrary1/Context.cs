namespace Data
{
    using System;
    using System.Data.Entity;
    using Domain;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Model1")
        {
            
        }

        public virtual DbSet<plainpassword> plainpassword { get; set; }
        public virtual DbSet<t_token> t_token { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<Candidate> candidate { get; set; }
        public virtual DbSet<CV> cv { get; set; }
        public virtual DbSet<Education> education { get; set; }
        public virtual DbSet<Experience> experience { get; set; }
        public virtual DbSet<Languages> languages { get; set; }
        public virtual DbSet<Collect> collect { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<plainpassword>()
                .Property(e => e.Password)
                ;

            modelBuilder.Entity<plainpassword>()
                .Property(e => e.Username)
                ;

            modelBuilder.Entity<t_token>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);
        }
    }
}
