using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.SlotRequests
{
    internal class GetSlotRequestsLookup : QueryAsync<IEnumerable<AppLookup>>
    {
        public GetSlotRequestsLookup(Providers provider) : base(provider) { }

        //public override async Task<IEnumerable<AppLookup>> ExecuteAsync(long? subjectId)
        //{
        //    if (!subjectId.HasValue)
        //    {
        //        return new List<AppLookup>();
        //    }
        //    return await Providers.Database.Courses
        //        .Where(course => (course.SubjectId == subjectId.Value) && course.IsActive)
        //        .Select(course => new AppLookup
        //        {
        //            Key = course.Id.ToString(),
        //            Value = course.Name
        //        })
        //        .ToListAsync();
        //}

        public override async Task<IEnumerable<AppLookup>> ExecuteAsync()
        {
            return await Providers.Database.SlotRequest.
                Where(slotRequest => slotRequest.IsActive)
                .Select(slotRequest => new AppLookup
                {
                    Key = slotRequest.Id.ToString(),
                    Value = slotRequest.Topic
                })
                .ToListAsync();
        }

        public IEnumerable<AppLookup> ExecuteSync()
        {
            return Providers.Database.SlotRequest.
                Where(slotRequest => slotRequest.IsActive)
                .Select(slotRequest => new AppLookup
                {
                    Key = slotRequest.Id.ToString(),
                    Value = slotRequest.Topic
                })
                .ToList();
        }
    }
}