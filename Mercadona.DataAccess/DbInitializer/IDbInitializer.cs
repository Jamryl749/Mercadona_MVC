/// <summary>
/// Namespace for Mercadona.DataAccess.DbInitializer.
/// </summary>
namespace Mercadona.DataAccess.DbInitializer
{
    /// <summary>
    /// Represents an interface for database initializer that can initialize the database at application startup.
    /// </summary>
    public interface IDbInitializer
    {
        /// <summary>
        /// Initializes the database by migrating pending migrations and seeding necessary roles and users.
        /// </summary>
        void Initialize();
    }
}
