using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rocky_Models;
using Rocky_Models.Models;

namespace Rocky_DataAccess
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<ApplicationType> ApplicationType { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<ApplicationUser> Users { get;set; } = null!;

        public DbSet<InquiryHeader> InquiryHeader{ get; set; } = null!;

        public DbSet<InquiryDetail> InquiryDetail{ get; set; } = null!;





    }
}
