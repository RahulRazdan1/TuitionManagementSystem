using Application.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Application.TMS;
using Application.Subjects;
using Application.Courses;
using Application.SlotRequests;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Application.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }        
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SlotRequest> SlotRequest { get; set; }
        public DbSet<SlotTimes> SlotTimes { get; set; }
        public DbSet<SlotResult> SlotResult { get; set; }
        public DbSet<OtherActivity> OtherActivity { get; set; }
    }

    public static class DataAccess
    {
        public static string Test(string connectionString,String userName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("dbo.Test", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@UserName", userName));

                // execute the command
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return rdr[0].ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static IList<SlotResult> GetSlotResultList(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("dbo.SlotRequestResult", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // execute the command
                using (var rdr = cmd.ExecuteReader())
                {
                    IList<SlotResult> result = new List<SlotResult>();
                    //3. Loop through rows
                    while (rdr.Read())
                    {
                        //Get each column
                        result.Add(new SlotResult() { 
                                                Id = Convert.ToInt64(rdr[0]), 
                                                Subject = Convert.ToString(rdr[1]), 
                                                Tutor = Convert.ToString(rdr[2]), 
                                                Hours = Convert.ToDecimal(rdr[3]) });
                    }
                    return result;
                }
            }
        }
    }
}