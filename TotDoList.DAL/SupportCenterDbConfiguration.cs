using System.Data.Entity;

namespace TotDoList.DAL
{
    public class SupportCenterDbConfiguration : DbConfiguration
    {
        public SupportCenterDbConfiguration()
        {
            this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory()); // SQL Server instantie op machine

            this.SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);

            this.SetDatabaseInitializer<ToDoListDbContext>(new SupportCenterDbInitializer());
        }
    }
}