﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agensi.Data.Core
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AgensiDBEntities : DbContext
    {
        public AgensiDBEntities()
            : base("name=AgensiDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerVoteDown> AnswerVoteDowns { get; set; }
        public virtual DbSet<LanguageMaster> LanguageMasters { get; set; }
        public virtual DbSet<QueryVoteDown> QueryVoteDowns { get; set; }
        public virtual DbSet<UserState> UserStates { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserFollow> UserFollows { get; set; }
        public virtual DbSet<UserComment> UserComments { get; set; }
        public virtual DbSet<QueryView> QueryViews { get; set; }
        public virtual DbSet<QueryTag> QueryTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        public virtual DbSet<AnswerVote> AnswerVotes { get; set; }
        public virtual DbSet<QueryVote> QueryVotes { get; set; }
    }
}
