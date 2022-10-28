using Application.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Application.TMS
{
    public class GetOtherActivityQuery : CommandAsync<OtherActivity>
    {
        public GetOtherActivityQuery(Providers provider) : base(provider)
        {
        }
        public override Task<ExecutionResult> ExecuteAsync(OtherActivity input)
        {
            throw new NotImplementedException();
        }

        public ExecutionResult ExecuteSync(OtherActivity input)
        {
            Providers.Database.OtherActivity.Add(input);
            Providers.Database.SaveChanges();
            return ExecutionResult.Success();
        }

        public ExecutionResult DeleteExecuteSync(OtherActivity input)
        {            
            Providers.Database.Entry(input).State = EntityState.Deleted;
            Providers.Database.SaveChanges();

            return ExecutionResult.Success();
        }

        public OtherActivity otherActivityById(long id)
        {
            var db = Providers.Database;
            return (from oa in db.OtherActivity
                    where oa.Id == id
                    select new OtherActivity
                    {
                        Id = oa.Id,
                        UserId = oa.UserId,
                        Users = oa.Users,
                        IsActive = oa.IsActive
                    }).AsNoTracking()
                         .FirstOrDefault();
        }

        public static IList<OtherActivity> GetOtherActivityList(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetOtherActivityList", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var rdr = cmd.ExecuteReader())
                {
                    IList<OtherActivity> result = new List<OtherActivity>();
                    while (rdr.Read())
                    {                        
                        result.Add(new OtherActivity()
                        {
                            Id = Convert.ToInt64(rdr[0]),
                            UserId = Convert.ToInt64(rdr[1]),
                            Users = Convert.ToString(rdr[2]),
                            SubjectId = Convert.ToInt64(rdr[3]),
                            Subject = Convert.ToString(rdr[4]),
                            Hours = Convert.ToDecimal(rdr[5])
                        });
                    }
                    return result;
                }
            }
        }        
    }
}
