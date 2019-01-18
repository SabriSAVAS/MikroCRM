using MikroCrm.Data.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MikroCrm.Data.Domain.Context
{
    public  class MikroCrmContext:DbContext
    {
        public MikroCrmContext():base("DbServer")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserApp> UserApp { get; set; }

        public DbSet<RoleApp> RoleApp { get; set; }
        public DbSet<SettingData> SettingData { get; set; }
        public DbSet<GeneralSetting> GeneralSetting { get; set; }
        public DbSet<Cleander> Claander { get; set; }
    }
}
