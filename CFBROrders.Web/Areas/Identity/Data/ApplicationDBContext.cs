using System;
using System.Collections.Generic;
using CFBROrders.SDK.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CFBROrders.Web.Areas.Identity.Data;

public partial class ApplicationDBContext :IdentityDbContext<ApplicationUser>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
