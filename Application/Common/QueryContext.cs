using Application.Data;

namespace Application.Common
{
    public class QueryContext
    {
        public QueryContext(ApplicationDbContext db)
        {
            Database = db;
        }
        public ApplicationDbContext Database { get; private set; }
    }

}
