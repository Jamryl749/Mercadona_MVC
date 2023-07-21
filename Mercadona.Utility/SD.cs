/**
 *@file SD.cs
 *brief A simple class containing Users's roles and console commands for creating and formating coverlet code coverage report 
*/
namespace Mercadona.Utility
{
    /// <summary>
    /// Codecoverage Command
    /// dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings
    /// Generate reports
    /// reportgenerator -reports:"Path of the previously generated report" -targetdir:"coveragereport" -reporttypes:Html
    /// </summary>

    public static class SD
    {
        public const string Role_Admin = "Admin";
    }
}
