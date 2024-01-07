using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PaddySe.Recipes.DataAccess.Interceptors;

/// <summary>
/// Base class for intercepting SaveChanges methods in Entity Framework Core.
/// </summary>
public abstract class SaveChangesInterceptorBase : SaveChangesInterceptor, ISingletonInterceptor
{
	/// <summary>
	/// Processes all entries in a DbContext.
	/// </summary>
	/// <param name="context">The DbContext to process.</param>
	protected abstract void ProcessEntries(RecipesDbContext context);

	/// <inheritdoc />
	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		if (eventData.Context is not RecipesDbContext context)
		{
			return result;
		}

		ProcessEntries(context);

		return result;
	}

	/// <inheritdoc />
	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
																		  InterceptionResult<int> result,
																		  CancellationToken cancellationToken = default)
	{
		if (eventData.Context is not RecipesDbContext context)
		{
			return new ValueTask<InterceptionResult<int>>(result);
		}

		ProcessEntries(context);

		return new ValueTask<InterceptionResult<int>>(result);
	}
}