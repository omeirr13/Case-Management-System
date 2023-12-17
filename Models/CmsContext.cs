using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Case_Management_System.Models;

public partial class CmsContext : DbContext
{
    public CmsContext()
    {

    }
    public DbSet<Lawyer> Lawyers { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CaseHistory> CaseHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


}