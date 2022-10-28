using Application.Common;
using Microsoft.EntityFrameworkCore;
using Application.Subjects;
using Application.Courses;
using Application.Users;

namespace Application.SlotRequests
{
    public class GetSlotRequestById : QueryAsync<long, SlotRequest>
    {
        public GetSlotRequestById(Providers provider) : base(provider) { }
        public override async Task<SlotRequest> ExecuteAsync(long slotRequestId)
        {
            var db = Providers.Database;
            return await (from sl in db.SlotRequest
                          join s in db.Subjects on sl.SubjectId equals s.Id
                          join c in db.Courses on sl.CourseId equals c.Id
                          join uTutee in db.Users on sl.TuteeId equals uTutee.Id
                          join uTutor in db.Users on sl.TutorId equals uTutor.Id into grouping
                          from uTutor in grouping.DefaultIfEmpty()
                          where sl.Id == slotRequestId
                          select new SlotRequest
                          {
                              Id = sl.Id,
                              Tutee = new AspNetUser { Name = uTutee.FullName },
                              TuteeId = sl.TuteeId,
                              Subject = new Subject { Name = s.Name },
                              SubjectId = sl.SubjectId,
                              Course = new Course { Name = c.Name },
                              CourseId = sl.CourseId,
                              Topic = sl.Topic,
                              Date = sl.Date,
                              SlotTime1 = sl.SlotTime1,
                              SlotTime2 = sl.SlotTime2,
                              SlotTime3 = sl.SlotTime3,
                              IsActive = sl.IsActive,
                              CreatedOn = sl.CreatedOn,
                              //CreatedBy = sl.CreatedBy,
                              //ModifiedBy = sl.ModifiedBy,
                              //ModifiedOn = sl.ModifiedOn,
                              Tutor = new AspNetUser { Name = uTutor.FullName },
                              TutorId = sl.TutorId,
                              AcceptedSlotTime = sl.AcceptedSlotTime,
                              //AcceptedOn = sl.AcceptedOn
                          }).FirstOrDefaultAsync();
        }

        public SlotRequest ExecuteSync(long slotRequestId)
        {
            var db = Providers.Database;
            return (from sl in db.SlotRequest
                    join s in db.Subjects on sl.SubjectId equals s.Id
                    join c in db.Courses on sl.CourseId equals c.Id
                    join uTutee in db.Users on sl.TuteeId equals uTutee.Id
                    join uTutor in db.Users on sl.TutorId equals uTutor.Id into grouping
                    from uTutor in grouping.DefaultIfEmpty()
                    where sl.Id == slotRequestId
                    select new SlotRequest
                    {
                        Id = sl.Id,
                        Tutee = new AspNetUser { Name = uTutee.FullName, Email = uTutee.Email },
                        TuteeId = sl.TuteeId,
                        Subject = new Subject { Name = s.Name },
                        SubjectId = sl.SubjectId,
                        Course = new Course { Name = c.Name },
                        CourseId = sl.CourseId,
                        Topic = sl.Topic,
                        Date = sl.Date,
                        SlotTime1 = sl.SlotTime1,
                        SlotTime2 = sl.SlotTime2,
                        SlotTime3 = sl.SlotTime3,
                        IsActive = sl.IsActive,
                        CreatedBy = sl.CreatedBy,
                        CreatedOn = sl.CreatedOn,
                        //ModifiedBy = sl.ModifiedBy,
                        //ModifiedOn = sl.ModifiedOn,
                        Tutor = new AspNetUser { Name = uTutor.FullName, Email = uTutor.Email },
                        TutorId = sl.TutorId,
                        AcceptedSlotTime = sl.AcceptedSlotTime,
                        AcceptedOn = sl.AcceptedOn                        
                    }).FirstOrDefault();
        }
    }
}
