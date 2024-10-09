using AIProcessingService.Data;

namespace AIProcessingService
{
    public static class AppDbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            // Seed initial data if needed
        }
    }
}
