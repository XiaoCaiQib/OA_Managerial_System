﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OA_Managerial_System.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OAEntities : DbContext
    {
        public OAEntities()
            : base("name=OAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<ActionInfo> ActionInfo { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }
    }
}
