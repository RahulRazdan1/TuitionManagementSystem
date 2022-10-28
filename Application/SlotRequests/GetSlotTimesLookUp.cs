using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.SlotRequests
{
    public class GetSlotTimesLookUp : QueryAsync<IEnumerable<AppLookup>>
    {
        public GetSlotTimesLookUp(Providers provider) : base(provider)
        {
        }

        public override async Task<IEnumerable<AppLookup>> ExecuteAsync()
        {
            return await Providers.Database.SlotTimes.
                Where(slotTimes => slotTimes.IsActive)
                .Select(slotTimes => new AppLookup
                {
                    Key = slotTimes.Id.ToString(),
                    Value = slotTimes.Name
                })
                .ToListAsync();
        }

        public IEnumerable<AppLookup> ExecuteSync()
        {
            return Providers.Database.SlotTimes.
                Where(slotTimes => slotTimes.IsActive)
                .Select(slotTimes => new AppLookup
                {
                    Key = slotTimes.Id.ToString(),
                    Value = slotTimes.Name
                })
                .ToList();
        }
    }
}