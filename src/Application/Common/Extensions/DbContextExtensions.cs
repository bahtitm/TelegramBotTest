namespace Application.Common.Extensions
{
    public static class DbContextExtensions
    {
        public static async Task<T> FindByIdAsync<T>(this IApplicationDbContext dbContext, uint id, CancellationToken cancellationToken = default)
            where T : BaseEntity
        {
            var items = dbContext.Set<T>();

            var item = await items.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (item == null)
            {

                throw new Exception($"Entity \"{typeof(T).Name}\" ({id}) was not found.");
            }
            return item;
        }
    }
}