//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portfolio
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PortfolioEntities : DbContext
    {
        public PortfolioEntities()
            : base("name=PortfolioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AboutCategory> AboutCategories { get; set; }
        public virtual DbSet<AboutTopic> AboutTopics { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Certifcate> Certifcates { get; set; }
        public virtual DbSet<EducationCategory> EducationCategories { get; set; }
        public virtual DbSet<EducationTopic> EducationTopics { get; set; }
        public virtual DbSet<HeaderCategory> HeaderCategories { get; set; }
        public virtual DbSet<Header> Headers { get; set; }
        public virtual DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SocialCategory> SocialCategories { get; set; }
        public virtual DbSet<SocialLink> SocialLinks { get; set; }
        public virtual DbSet<SumaryCategory> SumaryCategories { get; set; }
        public virtual DbSet<SumaryTopic> SumaryTopics { get; set; }
        public virtual DbSet<Viewer> Viewers { get; set; }
        public virtual DbSet<Image> Images { get; set; }
    }
}
