using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.SlotRequests
{
    public class GetSlotTimeBySlotId : QueryAsync<IEnumerable<AppLookup>>
    {
        public GetSlotTimeBySlotId(Providers provider) : base(provider) { }

        public override Task<IEnumerable<AppLookup>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppLookup> ExecuteSync(long slotId)
        {
            var db = Providers.Database;

            long slotTimeId1 = (from sl in db.SlotRequest
                                join s in db.SlotTimes on sl.SlotTime1 equals s.Name
                                where sl.Id == slotId
                                select new SlotTimes { Id = s.Id }).First().Id;
            long slotTimeId2 = (from sl in db.SlotRequest
                                join s in db.SlotTimes on sl.SlotTime2 equals s.Name
                                where sl.Id == slotId
                                select new SlotTimes { Id = s.Id }).First().Id;
            long slotTimeId3 = (from sl in db.SlotRequest
                                join s in db.SlotTimes on sl.SlotTime3 equals s.Name
                                where sl.Id == slotId
                                select new SlotTimes { Id = s.Id }).First().Id;


            return Providers.Database.SlotTimes.
                Where(slotTimes => slotTimes.IsActive && (slotTimes.Id == slotTimeId1 || slotTimes.Id == slotTimeId2 || slotTimes.Id == slotTimeId3))
                .Select(slotTimes => new AppLookup
                {
                    Key = slotTimes.Id.ToString(),
                    Value = slotTimes.Name
                })
                .ToList();
        }
    }
}
