using Application.Common;
using Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Application.TMS
{
    public class Report : QueryAsync<IList<SlotResult>>
    {
        public Report(Providers provider) : base(provider) { }
        public override async Task<IList<SlotResult>> ExecuteAsync()
        {
            var db = Providers.Database;
            return await (from sl in db.SlotRequest
                          join s in db.Subjects on sl.SubjectId equals s.Id
                          join uTutor in db.Users on sl.TutorId equals uTutor.Id
                          where sl.IsActive == true &&
                          sl.TutorId != 0
                          select new SlotResult
                          {
                              Subject = s.Name,
                              Tutor = uTutor.FullName,
                              Hours = s.Id
                          }).ToListAsync();

        }

        public IList<SlotResult> ExecuteSync(string connectionString)
        {
            return DataAccess.GetSlotResultList(connectionString);
        }
    }
}