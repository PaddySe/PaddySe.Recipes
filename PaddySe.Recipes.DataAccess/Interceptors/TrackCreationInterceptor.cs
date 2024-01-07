using Microsoft.EntityFrameworkCore;
using PaddySe.Recipes.DataAccess.Interfaces;

namespace PaddySe.Recipes.DataAccess.Interceptors;

/// <summary>
///     Interceptor used to track creation of entities which implement the <see cref="ITrackCreation"/> interface.
/// </summary>
public class TrackCreationInterceptor : SaveChangesInterceptorBase
{
	/// <summary>
	///     Singleton instance of the <see cref="TrackCreationInterceptor"/> class.
	/// </summary>
	public static Lazy<TrackCreationInterceptor> Instance { get; } = new(() => new TrackCreationInterceptor());

	/// <summary>
	///     Processes the entries which implement the ITrackDeletion interface in the ChangeTracker if they are in a Deleted
	///     state.
	/// </summary>
	/// <param name="context">The DbContextBase instance.</param>
	protected override void ProcessEntries(RecipesDbContext context)
	{
		foreach (var entry in context.ChangeTracker.Entries<ITrackCreation>())
		{
			if (entry.State != EntityState.Added)
			{
				continue;
			}

			var entity = entry.Entity;
			entity.CreatedDate = DateTime.Now;
		}
	}
}
