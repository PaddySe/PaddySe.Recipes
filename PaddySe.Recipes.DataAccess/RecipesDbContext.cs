using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PaddySe.Recipes.DataAccess;

public class RecipesDbContext : IdentityDbContext
{
	public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
		: base(options)
	{
	}
}