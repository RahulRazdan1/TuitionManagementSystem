using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.SlotRequests
{
    public class GetSlotTimeById : QueryAsync<long, SlotTimes>
    {
        public GetSlotTimeById(Providers provider) : base(provider) { }
        public override async Task<SlotTimes> ExecuteAsync(long slotTimeId)
        {
            var db = Providers.Database;
            return await (from sT in db.SlotTimes
                          where sT.Id == slotTimeId
                          select new SlotTimes { Id = sT.Id, Name = sT.Name }).FirstOrDefaultAsync();
        }

        public SlotTimes ExecuteSync(long slotTimeId)
        {
            var db = Providers.Database;
            return (from sT in db.SlotTimes
                    where sT.Id == slotTimeId
                    select new SlotTimes { Id = sT.Id, Name = sT.Name }).FirstOrDefault();
        }
    }
}
