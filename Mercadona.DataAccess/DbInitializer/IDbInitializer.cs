/**
 *@file IDbInitializer.cs
 *brief Interface for DbInitializer
*/
namespace Mercadona.DataAccess.DbInitializer
{
    public interface IDbInitializer
    {
        /**
        *@fn Initialize()
         *brief Check if the database contains roles, then an admin user. If not creates them.
        */
        void Initialize();
    }
}
