using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace ZimtProcure2Pay.Models
{


    public class UniversalID
    {
        [Key]
        public long ID { get; set; }

    }

    public class WorkGroup
    {
        public long WorkGroupID { get; set; }

        public long UniversalID { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

    }
    public class MobileRequest
    {
        public long MobileRequestID { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int Status { get; set; }

        public int Priority { get; set; }

        public DateTime? Placed { get; set; }

        public string ImageUrl { get; set; }
    }

    public class WorkGroupRole
    {
        public long WorkGroupRoleID { get; set; }

        public string Name { get; set; }

        public long WorkGroupID { get; set; }

        public string UserID { get; set; }
    }

    public class WorkGroupApprover
    {
        public long WorkGroupApproverID { get; set; }

        public string UserID { get; set; }

        public decimal MaxValue { get; set; }

        public string Type { get; set; }
    }

    public class Invoice
    {

        public long InvoiceID { get; set; }
        public long UniversalID { get; set; }
        public string RefNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Vendor { get; set; }
        public string CostObjectType { get; set; }
        public string CostObject { get; set; }
        public string RequisitionerID { get; set; }
    }

    public class InvoiceLineItem
    {
        public long InvoiceLineItemID { get; set; }
        public long UniversalID { get; set; }
        public long RequisitionNumber { get; set; }
        public string ItemNumber { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }

    

    public class Requisition
    {
        public long RequisitionID { get; set; }
        public long UniversalID { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public decimal Total { get; set; }
        public DateTime Expected { get; set; }
        public string Status { get; set; }
        public string Reference { get; set; }
    }

    public class ReqLineItem
    {
        public long ReqLineItemID { get; set; }
        public long UniversalID { get; set; }
        public long RequisitionID { get; set; }
        public string ItemNumber { get; set; }
        public string Description { get; set; }
        public decimal Qty { get; set; }
        public string Unit { get; set; }
        public decimal Total { get; set; }
        public DateTime Expected { get; set; }
        public string Status { get; set; }
        public string PONumber { get; set; }
    }

    public class User_WorkGroup
    {
        public long User_WorkGroupID { get; set; }

        public string UserID { get; set; }

        public long WorkGroupID { get; set; }
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public long UniversalID { get; set; }
        public string LastName { get; set; }
        public string ActiveDirectoryID { get; set; }
        public string SAPID { get; set; }

        public string ManagerID { get; set; }

        public DateTime LastIn { get; set; }

        public DateTime CreatedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<ReqLineItem> ReqLineItems { get; set; }
        public DbSet<User_WorkGroup> User_WorkGroups { get; set; }
        public DbSet<UniversalID> MasterIDs { get; set; }
        public DbSet<WorkGroup> WorkGroups { get; set; }
        public DbSet<WorkGroupRole> GroupRoles { get; set; }
        public DbSet<WorkGroupApprover> WorkGroupApprovers { get; set; }
        public DbSet<MobileRequest> MobileRequests { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}