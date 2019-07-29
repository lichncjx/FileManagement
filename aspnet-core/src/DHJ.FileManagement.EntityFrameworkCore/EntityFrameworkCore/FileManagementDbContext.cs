using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using DHJ.FileManagement.Applications;
using DHJ.FileManagement.Authorization.Roles;
using DHJ.FileManagement.Authorization.Users;
using DHJ.FileManagement.Chat;
using DHJ.FileManagement.Editions;
using DHJ.FileManagement.Files.FileEntities;
using DHJ.FileManagement.Files.FileEntities.Bills.ChangeBills;
using DHJ.FileManagement.Files.FileEntities.Drawings;
using DHJ.FileManagement.Files.FileEntities.Technologies;
using DHJ.FileManagement.FileStore;
using DHJ.FileManagement.Friendships;
using DHJ.FileManagement.Models;
using DHJ.FileManagement.MultiTenancy;
using DHJ.FileManagement.MultiTenancy.Accounting;
using DHJ.FileManagement.MultiTenancy.Payments;
using DHJ.FileManagement.Storage;
using Microsoft.EntityFrameworkCore;

namespace DHJ.FileManagement.EntityFrameworkCore
{
    public class FileManagementDbContext : AbpZeroDbContext<Tenant, Role, User, FileManagementDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define an IDbSet for each entity of the application */

        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual DbSet<Friendship> Friendships { get; set; }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }

        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        /*--------------自定义 开始---------------*/

        //型号基础信息管理
        public virtual DbSet<ModelInfo> ModelInfos { get; set; }

        //文件管理

        public virtual DbSet<FileBase> ArchiveBases { get; set; }
        public virtual DbSet<Drawing> Drawings { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<ChangeBill> ChangeBills { get; set; }

        //库房管理
        public virtual DbSet<StoreContainer> StoreContainers { get; set; }
        public virtual DbSet<FileStoreInfo> FileStoreInfos { get; set; }

        //申请单
        public virtual DbSet<FileBorrowing> FileBorrowings { get; set; }

        /*--------------自定义 结束---------------*/

        public FileManagementDbContext(DbContextOptions<FileManagementDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BinaryObject>(b =>
            {
                b.HasIndex(e => new { e.TenantId });
            });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { e.PaymentId, e.Gateway });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
