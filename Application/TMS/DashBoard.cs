using Application.Common;

namespace Application.TMS
{
    public class DashBoard
    {
        public DashBoard(long UserId, Providers provider)
        {
            var db = provider.Database;
            TutorCount = (from s in db.UserDetail where s.UserTypeId == 1 select new UserDetail { Id = s.Id }).ToList().Count();
            TuteeCount = (from s in db.UserDetail where s.UserTypeId == 2 select new UserDetail { Id = s.Id }).ToList().Count();
            OpenSlotCount = (from s in db.SlotRequest where s.IsActive == true && s.AcceptedSlotTime == null select new UserDetail { Id = s.Id }).ToList().Count();
            AcceptedSlotCount = (from s in db.SlotRequest where s.IsActive == true && s.AcceptedSlotTime != null select new UserDetail { Id = s.Id }).ToList().Count();
            TutorAcceptedSlotCount = (from s in db.SlotRequest where s.IsActive == true && s.AcceptedSlotTime != null && s.TutorId == UserId select new UserDetail { Id = s.Id }).ToList().Count();

        }

        public int TutorCount { get; set; }
        public int TuteeCount { get; set; }
        public int OpenSlotCount { get; set; }
        public int AcceptedSlotCount { get; set; }
        public int TutorAcceptedSlotCount { get; set; }

    }
}
