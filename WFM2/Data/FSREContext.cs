using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WFM2.Models.WFM;

namespace WFM2.Data
{
    public partial class FSREContext : DbContext
    {
        public FSREContext(DbContextOptions<FSREContext> options) : base(options){}

        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Lob> Lob { get; set; }
        public virtual DbSet<EmpGrp> EmpGrp { get; set; }
        public virtual DbSet<EmpGrpLob> EmpGrpLob { get; set; }
        public virtual DbSet<ForGrp> ForGrp { get; set; }
        public virtual DbSet<ForGrpLob> ForGrpLob { get; set; }
        public virtual DbSet<HSplit> HSplit { get; set; }
        public virtual DbSet<IdpDet> IdpDet { get; set; }
        public virtual DbSet<IdpFgDet> IdpFgDet { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<Split> Split { get; set; }
        public virtual DbSet<StfGrp> StfGrp { get; set; }
        public virtual DbSet<StfGrpLob> StfGrpLob { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept>(entity =>
            {
                entity.ToTable("DEPT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Abbrev).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<Lob>(entity =>
            {
                entity.ToTable("LOB");

                entity.HasIndex(e => e.Lob1)
                    .HasName("IX_LOB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DeptId).HasColumnName("deptID");

                entity.Property(e => e.FteDefinition).HasColumnName("FTE Definition");

                entity.Property(e => e.Lob1)
                    .IsRequired()
                    .HasColumnName("LOB")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Lob)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LOB_DEPT");
            });

            modelBuilder.Entity<EmpGrp>(entity =>
            {
                entity.HasKey(e => e.EmpGrpNodeSk)
                    .HasName("PK_Emp_Grp_1");

                entity.ToTable("Emp_Grp");

                entity.Property(e => e.EmpGrpNodeSk)
                    .HasColumnName("EMP_GRP_NODE_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.EmpGrpClassSk)
                    .HasColumnName("EMP_GRP_CLASS_SK")
                    .HasColumnType("numeric");
            });

            modelBuilder.Entity<EmpGrpLob>(entity =>
            {
                entity.ToTable("Emp_Grp_LOB");

                entity.HasIndex(e => new { e.EmpGrpNodeSk, e.LobId, e.VendorId, e.SiteId })
                    .HasName("IX_Emp_Grp_LOB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmpGrpNodeSk)
                    .HasColumnName("EMP_GRP_NODE_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.LobId)
                    .IsRequired()
                    .HasColumnName("lobID");

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteID");

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasColumnName("vendorID");

                entity.HasOne(d => d.EmpGrpNodeSkNavigation)
                    .WithMany(p => p.EmpGrpLob)
                    .HasForeignKey(d => d.EmpGrpNodeSk)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Emp_Grp_LOB_Emp_Grp");

                entity.HasOne(d => d.Lob)
                    .WithMany(p => p.EmpGrpLob)
                    .HasForeignKey(d => d.LobId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Emp_Grp_LOB_LOB");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.EmpGrpLob)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Emp_Grp_LOB_Site");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.EmpGrpLob)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Emp_Grp_LOB_Vendor");
            });

            modelBuilder.Entity<ForGrp>(entity =>
            {
                entity.HasKey(e => e.ForGrpSk)
                    .HasName("PK_For_Grp");

                entity.ToTable("For_Grp");

                entity.Property(e => e.ForGrpSk)
                    .HasColumnName("FOR_GRP_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.TimeZoneSk)
                    .HasColumnName("TIME_ZONE_SK")
                    .HasColumnType("numeric");
            });

            modelBuilder.Entity<ForGrpLob>(entity =>
            {
                entity.ToTable("For_Grp_LOB");

                entity.HasIndex(e => new { e.ForGrpSk, e.LobId, e.VendorId, e.SiteId })
                    .HasName("IX_For_Grp_LOB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ForGrpSk)
                    .HasColumnName("FOR_GRP_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.LobId)
                    .IsRequired()
                    .HasColumnName("lobID");

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasColumnName("siteID");

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasColumnName("vendorID");

                entity.HasOne(d => d.ForGrpSkNavigation)
                    .WithMany(p => p.ForGrpLob)
                    .HasForeignKey(d => d.ForGrpSk)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_For_Grp_LOB_For_Grp");

                entity.HasOne(d => d.Lob)
                    .WithMany(p => p.ForGrpLob)
                    .HasForeignKey(d => d.LobId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_For_Grp_LOB_LOB");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.ForGrpLob)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_For_Grp_LOB_Site");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.ForGrpLob)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_For_Grp_LOB_Vendor");
            });

            modelBuilder.Entity<HSplit>(entity =>
            {
                entity.HasKey(e => new { e.RowDate, e.Interval, e.VendorId, e.Acd, e.Split })
                    .HasName("PK_hSplit");

                entity.ToTable("hSplit");

                entity.Property(e => e.RowDate)
                    .HasColumnName("row_date")
                    .HasColumnType("date");

                entity.Property(e => e.Interval)
                    .HasColumnName("interval")
                    .HasColumnType("time(0)");

                entity.Property(e => e.VendorId).HasColumnName("vendorID");

                entity.Property(e => e.Acd).HasColumnName("acd");

                entity.Property(e => e.Split).HasColumnName("split");

                entity.Property(e => e.Abncalls).HasColumnName("abncalls");

                entity.Property(e => e.Abntime).HasColumnName("abntime");

                entity.Property(e => e.Acceptable).HasColumnName("acceptable");

                entity.Property(e => e.Acdcalls).HasColumnName("acdcalls");

                entity.Property(e => e.Acdtime).HasColumnName("acdtime");

                entity.Property(e => e.Acwincalls).HasColumnName("acwincalls");

                entity.Property(e => e.Acwintime).HasColumnName("acwintime");

                entity.Property(e => e.Acwoutcalls).HasColumnName("acwoutcalls");

                entity.Property(e => e.Acwouttime).HasColumnName("acwouttime");

                entity.Property(e => e.Acwtime).HasColumnName("acwtime");

                entity.Property(e => e.Anstime).HasColumnName("anstime");

                entity.Property(e => e.Auxincalls).HasColumnName("auxincalls");

                entity.Property(e => e.Auxintime).HasColumnName("auxintime");

                entity.Property(e => e.Auxoutcalls).HasColumnName("auxoutcalls");

                entity.Property(e => e.Auxouttime).HasColumnName("auxouttime");

                entity.Property(e => e.Busycalls).HasColumnName("busycalls");

                entity.Property(e => e.Conference).HasColumnName("conference");

                entity.Property(e => e.Dequecalls).HasColumnName("dequecalls");

                entity.Property(e => e.Disccalls).HasColumnName("disccalls");

                entity.Property(e => e.Holdabncalls).HasColumnName("holdabncalls");

                entity.Property(e => e.Holdcalls).HasColumnName("holdcalls");

                entity.Property(e => e.Holdtime).HasColumnName("holdtime");

                entity.Property(e => e.IAcdothertime).HasColumnName("i_acdothertime");

                entity.Property(e => e.IAcdtime).HasColumnName("i_acdtime");

                entity.Property(e => e.IAcwintime).HasColumnName("i_acwintime");

                entity.Property(e => e.IAcwouttime).HasColumnName("i_acwouttime");

                entity.Property(e => e.IAcwtime).HasColumnName("i_acwtime");

                entity.Property(e => e.IArrived).HasColumnName("i_arrived");

                entity.Property(e => e.IAuxintime).HasColumnName("i_auxintime");

                entity.Property(e => e.IAuxouttime).HasColumnName("i_auxouttime");

                entity.Property(e => e.IAuxtime).HasColumnName("i_auxtime");

                entity.Property(e => e.IAvailtime).HasColumnName("i_availtime");

                entity.Property(e => e.IOthertime).HasColumnName("i_othertime");

                entity.Property(e => e.IRingtime).HasColumnName("i_ringtime");

                entity.Property(e => e.Outflowcalls).HasColumnName("outflowcalls");

                entity.Property(e => e.Ringcalls).HasColumnName("ringcalls");

                entity.Property(e => e.Ringtime).HasColumnName("ringtime");

                entity.Property(e => e.Transferred).HasColumnName("transferred");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.HSplit)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_hSplit_Vendor");

                entity.HasOne(d => d.HSplitNavigation)
                    .WithOne(p => p.InverseHSplitNavigation)
                    .HasForeignKey<HSplit>(d => new { d.RowDate, d.Interval, d.VendorId, d.Acd, d.Split })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_hSplit_hSplit");
            });

            modelBuilder.Entity<IdpDet>(entity =>
            {
                entity.HasKey(e => new { e.IdpSk, e.StfGrpSk, e.Element, e.Period })
                    .HasName("PK_IDP_DET");

                entity.ToTable("IDP_DET");

                entity.Property(e => e.IdpSk)
                    .HasColumnName("IDP_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.StfGrpSk)
                    .HasColumnName("STF_GRP_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.Element).HasColumnType("varchar(30)");

                entity.Property(e => e.Period).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("numeric");
            });

            modelBuilder.Entity<IdpFgDet>(entity =>
            {
                entity.ToTable("IDP_FG_DET");

                entity.HasIndex(e => new { e.IdpSk, e.ForGrpSk, e.Element, e.Period })
                    .HasName("IX_IDP_FG_DET")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Element)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.ForGrpSk)
                    .IsRequired()
                    .HasColumnName("FOR_GRP_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.IdpSk)
                    .IsRequired()
                    .HasColumnName("IDP_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.Period)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal");

                entity.HasOne(d => d.ForGrpSkNavigation)
                    .WithMany(p => p.IdpFgDet)
                    .HasForeignKey(d => d.ForGrpSk)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_IDP_FG_DET_For_Grp");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatId).HasColumnName("catID");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_Product_Product_Category");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("Product_Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasIndex(e => e.Site1)
                    .HasName("IX_Site")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Location).HasColumnType("varchar(50)");

                entity.Property(e => e.Site1)
                    .IsRequired()
                    .HasColumnName("Site")
                    .HasMaxLength(30);

                entity.Property(e => e.VendorId).HasColumnName("vendorID");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Site)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Site_Vendor");
            });

            modelBuilder.Entity<Split>(entity =>
            {
                entity.Property(e => e.SplitId).HasColumnName("Split_ID");

                entity.Property(e => e.Acd).HasColumnName("acd");

                entity.Property(e => e.LobId).HasColumnName("LOB_ID");

                entity.Property(e => e.Split1).HasColumnName("split");

                entity.Property(e => e.VendorId).HasColumnName("Vendor_ID");

                entity.Property(e => e.CTF).HasColumnName("CTF");

                entity.HasOne(d => d.Lob)
                    .WithMany(p => p.Split)
                    .HasForeignKey(d => d.LobId)
                    .HasConstraintName("FK_Split_LOB");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Split)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Split_Vendor");
            });

            modelBuilder.Entity<StfGrp>(entity =>
            {
                entity.HasKey(e => e.StfGrpSk)
                    .HasName("PK_Stf_Grp_1");

                entity.ToTable("Stf_Grp");

                entity.Property(e => e.StfGrpSk)
                    .HasColumnName("STF_GRP_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.EmpGrpNodeSk)
                    .HasColumnName("EMP_GRP_NODE_SK")
                    .HasColumnType("decimal");

                entity.Property(e => e.TimeZoneSk)
                    .HasColumnName("TIME_ZONE_SK")
                    .HasColumnType("numeric");
            });

            modelBuilder.Entity<StfGrpLob>(entity =>
            {
                entity.ToTable("Stf_Grp_LOB");

                entity.HasIndex(e => new { e.StfGrpSk, e.LobId, e.VendorId, e.SiteId })
                    .HasName("IX_Stf_Grp_LOB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LobId).HasColumnName("lobID");

                entity.Property(e => e.SiteId).HasColumnName("siteID");

                entity.Property(e => e.StfGrpSk)
                    .HasColumnName("STF_GRP_SK")
                    .HasColumnType("numeric");

                entity.Property(e => e.VendorId).HasColumnName("vendorID");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.StfGrpLob)
                    .HasForeignKey(d => d.SiteId)
                    .HasConstraintName("FK_Stf_Grp_LOB_Site");

                entity.HasOne(d => d.Lob)
                    .WithMany(p => p.StfGrpLob)
                    .HasForeignKey(d => d.LobId)
                    .HasConstraintName("FK_Stf_Grp_LOB_LOB");

                entity.HasOne(d => d.StfGrpSkNavigation)
                    .WithMany(p => p.StfGrpLob)
                    .HasForeignKey(d => d.StfGrpSk)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Stf_Grp_LOB_Stf_Grp");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.StfGrpLob)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Stf_Grp_LOB_Vendor");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasIndex(e => new { e.ProdId, e.YearNum, e.MonthNum })
                    .HasName("IX_Units")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activations).HasColumnName("activations");

                entity.Property(e => e.Deactivations).HasColumnName("deactivations");

                entity.Property(e => e.MonthNum)
                    .IsRequired()
                    .HasColumnName("monthNum");

                entity.Property(e => e.ProdId)
                    .IsRequired()
                    .HasColumnName("prodID");

                entity.Property(e => e.UnitCount).HasColumnName("unitCount");

                entity.Property(e => e.YearNum)
                    .IsRequired()
                    .HasColumnName("yearNum");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.ProdId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Units_Product");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasIndex(e => e.Abbrev)
                    .HasName("IX_Abbrev")
                    .IsUnique();

                entity.HasIndex(e => e.Vendor1)
                    .HasName("IX_Vendor")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Abbrev)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Vendor1)
                    .IsRequired()
                    .HasColumnName("Vendor")
                    .HasMaxLength(50);
            });
        }
    }
}