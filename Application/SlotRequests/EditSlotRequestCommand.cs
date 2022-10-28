using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.SlotRequests
{
    public class EditSlotRequestCommand : CommandAsync<SlotRequest>
    {
        public EditSlotRequestCommand(Providers provider) : base(provider)
        {
        }

        public override async Task<ExecutionResult> ExecuteAsync(SlotRequest input)
        {
            if (NameExists(input.Id, input.TuteeId, input.SubjectId, input.CourseId, input.Date))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Subject.Name} with {input.Course.Name} is already added."));
            }
            Providers.Database.Entry(input).State = EntityState.Modified;
            await Providers.Database.SaveChangesAsync();

            return ExecutionResult.Success();
        }

        public ExecutionResult ExecuteSyncDelete(SlotRequest input)
        {
            if (NameExists(input.Id, input.TuteeId, input.SubjectId, input.CourseId, input.Date))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Subject.Name} with {input.Course.Name} is already added."));
            }
            SlotRequest slotRequest = new SlotRequest();
            slotRequest = Providers.Database.SlotRequest.SingleOrDefault(x => x.Id == input.Id);

            if (slotRequest != null)
            {
                slotRequest.IsActive = input.IsActive;
                slotRequest.ModifiedBy = input.ModifiedBy;
                slotRequest.ModifiedOn = DateTime.Now;
            }
            Providers.Database.Entry(slotRequest).State = EntityState.Modified;
            Providers.Database.SaveChanges();

            return ExecutionResult.Success();
        }

        public ExecutionResult ExecuteSyncCancel(SlotRequest input)
        {
            if (NameExists(input.Id, input.TuteeId, input.SubjectId, input.CourseId, input.Date))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Subject.Name} with {input.Course.Name} is already added."));
            }
            SlotRequest slotRequest = new SlotRequest();
            slotRequest = Providers.Database.SlotRequest.SingleOrDefault(x => x.Id == input.Id);

            if (slotRequest != null)
            {
                slotRequest.IsActive = input.IsActive;
                slotRequest.ModifiedBy = input.ModifiedBy;
                slotRequest.ModifiedOn = DateTime.Now;
                slotRequest.TutorId = 0;
                slotRequest.AcceptedSlotTime = null;
                slotRequest.AcceptedOn = null;
            }
            Providers.Database.Entry(slotRequest).State = EntityState.Modified;
            Providers.Database.SaveChanges();

            return ExecutionResult.Success();
        }



        public ExecutionResult ExecuteSync(SlotRequest input)
        {
            if (NameExists(input.Id, input.TuteeId, input.SubjectId, input.CourseId, input.Date))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Subject.Name} with {input.Course.Name} is already added."));
            }
            SlotRequest slotRequest = new SlotRequest();
            slotRequest = Providers.Database.SlotRequest.SingleOrDefault(x => x.Id == input.Id);

            if (slotRequest != null)
            {
                slotRequest.IsActive = input.IsActive;
                slotRequest.ModifiedBy = input.TutorId;
                slotRequest.ModifiedOn = DateTime.Now;
                slotRequest.TutorId = input.TutorId;
                slotRequest.AcceptedSlotTime = input.AcceptedSlotTime;
                slotRequest.AcceptedOn = DateTime.Now;
            }
            Providers.Database.Entry(slotRequest).State = EntityState.Modified;
            Providers.Database.SaveChanges();

            return ExecutionResult.Success();
        }

        private bool NameExists(long Id, long TuteeId, long SubjectId, long CourseId, DateTime Date)
        {
            return Providers.Database.SlotRequest.Any(x => x.TuteeId == TuteeId &&
                                                           x.SubjectId == SubjectId &&
                                                           x.CourseId == CourseId &&
                                                           x.Date == Date &&
                                                           x.Id != Id);
        }
    }
}