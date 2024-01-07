using Microsoft.EntityFrameworkCore;
using PaddySe.Recipes.DataAccess.Interfaces;

namespace PaddySe.Recipes.DataAccess.Interceptors;

/// <summary>
///     Interceptor used to track modification of entities which implement the <see cref="ITrackModification"/> interface.
/// </summary>
public class TrackModificationInterceptor : SaveChangesInterceptorBase
{
	/// <summary>
	///     Singleton instance of the <see cref="TrackModificationInterceptor"/> class.
	/// </summary>
	public static Lazy<TrackModificationInterceptor> Instance { get; } = new(() => new TrackModificationInterceptor());

	/// <summary>
	///     Processes the entries which implement the ITrackDeletion interface in the ChangeTracker if they are in a Deleted
	///     state.
	/// </summary>
	/// <param name="context">The DbContextBase instance.</param>
	protected override void ProcessEntries(RecipesDbContext context)
	{
		foreach (var entry in context.ChangeTracker.Entries<ITrackModification>())
		{
			if (entry.State != EntityState.Modified)
			{
				continue;
			}

			var entity = entry.Entity;
			entity.LastModifiedDate = DateTime.Now;
		}
	}
}
