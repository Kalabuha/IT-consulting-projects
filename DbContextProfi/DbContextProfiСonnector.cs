using Microsoft.EntityFrameworkCore;
using DbContextProfi.TableConfigurations;
using Entities;

namespace DbContextProfi
{
    public class DbContextProfiСonnector : DbContext
    {
        #region DbSets
        public DbSet<HeaderMenuEntity> HeaderMenus => Set<HeaderMenuEntity>();
        public DbSet<HeaderSloganEntity> HeaderSlogans => Set<HeaderSloganEntity>();

        public DbSet<MainPagePresetEntity> MainPagePresets => Set<MainPagePresetEntity>();

        public DbSet<MainPageTextEntity> MainPageTexts => Set<MainPageTextEntity>();
        public DbSet<MainPageImageEntity> MainPageImages => Set<MainPageImageEntity>();
        public DbSet<MainPageActionEntity> MainPageActions => Set<MainPageActionEntity>();
        public DbSet<MainPagePhraseEntity> MainPagePhrases => Set<MainPagePhraseEntity>();
        public DbSet<MainPageButtonEntity> MainPageButtons => Set<MainPageButtonEntity>();

        public DbSet<ApplicationEntity> Applications => Set<ApplicationEntity>();

        public DbSet<ProjectEntity> Projects => Set<ProjectEntity>();
        public DbSet<ServiceEntity> Services => Set<ServiceEntity>();
        public DbSet<BlogEntity> Blogs => Set<BlogEntity>();
        public DbSet<ContactEntity> Contacts => Set<ContactEntity>();

        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<UserRoleEntity> Roles => Set<UserRoleEntity>();
        #endregion

        public DbContextProfiСonnector(DbContextOptions<DbContextProfiСonnector> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Автогенерация номеров заявок
            builder.HasSequence<int>("ApplicationNumbers");
            builder.Entity<ApplicationEntity>()
                .Property(a => a.Number)
                .HasDefaultValueSql("NEXT VALUE FOR ApplicationNumbers");

            builder.ApplyConfiguration(new UserTableConfig());
            builder.ApplyConfiguration(new MainPagePresetTableConfig());
        }
    }
}