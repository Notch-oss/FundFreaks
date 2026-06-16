namespace Investor_Service.Models
{
    public class InvestorDatabaseSetting : IInvestorDatabaseSetting
    {
        public new string ConnectionString { get; set; } = String.Empty;

        public new string DatabaseName { get; set; } = String.Empty;

        public new string CollectionName { get; set; } = String.Empty;
    }
}
