using Microsoft.EntityFrameworkCore;
using thi.netapi.Entities;

namespace thi.netapi.Context
{
	public class DBcontext : DbContext
	{
		public DBcontext(DbContextOptions options) : base(options) { }
		public DbSet<OrderTbl> OrderTbls { get; set; }
	}
}
