﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoFPT.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DemoFPTEntities : DbContext
    {
        public DemoFPTEntities()
            : base("name=DemoFPTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Products { get; set; }
    
        public virtual int sp_Delete_Product(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Delete_Product", idParameter);
        }

        public virtual ObjectResult<sp_GetAll_Products_Result> sp_GetAll_Products()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetAll_Products_Result>("sp_GetAll_Products");
        }
    
        public virtual ObjectResult<sp_GetById_Product_Result> sp_GetById_Product(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetById_Product_Result>("sp_GetById_Product", idParameter);
        }
    
        public virtual int sp_Insert_Product(string name, string manufacture, string createdby, Nullable<bool> active, string description, Nullable<System.DateTime> createdat)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var manufactureParameter = manufacture != null ?
                new ObjectParameter("manufacture", manufacture) :
                new ObjectParameter("manufacture", typeof(string));
    
            var createdbyParameter = createdby != null ?
                new ObjectParameter("createdby", createdby) :
                new ObjectParameter("createdby", typeof(string));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("active", active) :
                new ObjectParameter("active", typeof(bool));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var createdatParameter = createdat.HasValue ?
                new ObjectParameter("createdat", createdat) :
                new ObjectParameter("createdat", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insert_Product", nameParameter, manufactureParameter, createdbyParameter, activeParameter, descriptionParameter, createdatParameter);
        }
    
        public virtual int sp_Update_Product(Nullable<int> id, string name, string manufacture, string createdby, Nullable<bool> active, string description, Nullable<System.DateTime> updateat, string updateby, Nullable<bool> deleted)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var manufactureParameter = manufacture != null ?
                new ObjectParameter("manufacture", manufacture) :
                new ObjectParameter("manufacture", typeof(string));
    
            var createdbyParameter = createdby != null ?
                new ObjectParameter("createdby", createdby) :
                new ObjectParameter("createdby", typeof(string));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("active", active) :
                new ObjectParameter("active", typeof(bool));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var updateatParameter = updateat.HasValue ?
                new ObjectParameter("updateat", updateat) :
                new ObjectParameter("updateat", typeof(System.DateTime));
    
            var updatebyParameter = updateby != null ?
                new ObjectParameter("updateby", updateby) :
                new ObjectParameter("updateby", typeof(string));
    
            var deletedParameter = deleted.HasValue ?
                new ObjectParameter("deleted", deleted) :
                new ObjectParameter("deleted", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Update_Product", idParameter, nameParameter, manufactureParameter, createdbyParameter, activeParameter, descriptionParameter, updateatParameter, updatebyParameter, deletedParameter);
        }
    }
}
