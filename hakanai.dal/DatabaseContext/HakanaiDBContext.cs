using hakanai.domain.models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace hakanai.dal
{
    public class HakanaiDBContext : DbContext
    {
        public DbSet<Photograph> Photographs { get; set; }
        public DbSet<Project> Projects { get; set; }


        public HakanaiDBContext() : base("Server=localhost;Database=hakanai;Trusted_Connection=true;")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(HakanaiDBContext)));

            modelBuilder.Entity<Photograph>().HasKey(m => m.PhotographId).Property(m => m.PhotographId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Photograph>().Property(m => m.Title).IsRequired();
            modelBuilder.Entity<Photograph>().Property(m => m.Location).IsRequired();
            modelBuilder.Entity<Project>()
                .HasMany<Photograph>(m => m.Photographs)
                .WithMany(p => p.Projects)
                .Map(cs =>
                         {
                             cs.MapLeftKey("ProjectRefId");
                             cs.MapRightKey("PhotographRefId");                             
                             cs.ToTable("ProjectPhotograph");

                         });



            modelBuilder.Entity<Project>().HasKey(p=>p.ProjectId).Property(p => p.ProjectId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Project>().Property(p => p.Title).IsRequired();
            modelBuilder.Entity<Project>().Property(p => p.Description);



        }

    }
}
