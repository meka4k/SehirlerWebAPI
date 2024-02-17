using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{
	}

    public DbSet<City> Cities { get; set; }
}
