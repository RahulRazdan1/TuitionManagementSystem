using Application.Common;

namespace Application.SlotRequests
{
    public class AddSlotRequestCommand : CommandAsync<SlotRequest>
    {
        public AddSlotRequestCommand(Providers provider) : base(provider)
        {
        }

        public override async Task<ExecutionResult> ExecuteAsync(SlotRequest input)
        {
            if (NameExists(input.Id, input.TuteeId, input.SubjectId, input.CourseId, input.Date, "", "", ""))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Subject.Name} with {input.Course.Name} is already added."));
            }

            SlotRequest slotRequest = new SlotRequest();
            slotRequest.Id = input.Id;
            slotRequest.TuteeId = input.TuteeId;
            slotRequest.SubjectId = input.SubjectId;
            slotRequest.CourseId = input.CourseId;
            slotRequest.Topic = input.Topic;
            slotRequest.Date = Convert.ToDateTime(input.Date);
            slotRequest.SlotTime1 = input.SlotTime1;
            slotRequest.SlotTime2 = input.SlotTime2;
            slotRequest.SlotTime3 = input.SlotTime3;
            slotRequest.IsActive = true;
            slotRequest.CreatedBy = input.TuteeId;
            slotRequest.CreatedOn = DateTime.Now;
            slotRequest.ModifiedBy = null;
            slotRequest.ModifiedOn = null;
            slotRequest.TutorId = null;
            slotRequest.AcceptedSlotTime = null;
            slotRequest.AcceptedOn = null;

            Providers.Database.SlotRequest.Add(slotRequest);
            await Providers.Database.SaveChangesAsync();

            return ExecutionResult.Success();

        }


        public ExecutionResult ExecuteSync(SlotRequest input)
        {
            if (NameExists(input.Id, input.TuteeId, input.SubjectId, input.CourseId, input.Date, input.SlotTime1, input.SlotTime2, input.SlotTime3))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Subject.Name} with {input.Course.Name} is already added."));
            }

            SlotRequest slotRequest = new SlotRequest();
            slotRequest.Id = input.Id;
            slotRequest.TuteeId = input.TuteeId;
            slotRequest.SubjectId = input.SubjectId;
            slotRequest.CourseId = input.CourseId;
            slotRequest.Topic = input.Topic;
            slotRequest.Date = Convert.ToDateTime(input.Date);
            slotRequest.SlotTime1 = input.SlotTime1;
            slotRequest.SlotTime2 = input.SlotTime2;
            slotRequest.SlotTime3 = input.SlotTime3;
            slotRequest.IsActive = true;
            slotRequest.CreatedBy = input.TuteeId;
            slotRequest.CreatedOn = DateTime.Now;
            slotRequest.ModifiedBy = null;
            slotRequest.ModifiedOn = null;
            slotRequest.TutorId = null;
            slotRequest.AcceptedSlotTime = null;
            slotRequest.AcceptedOn = null;

            Providers.Database.SlotRequest.Add(slotRequest);
            Providers.Database.SaveChanges();

            return ExecutionResult.Success();

        }

        private bool NameExists(long Id, long TuteeId, long SubjectId, long CourseId, DateTime Date, string SlotTime1, string SlotTime2, string SlotTime3)
        {
            return Providers.Database.SlotRequest.Any(x => x.TuteeId == TuteeId &&
                                                           x.SubjectId == SubjectId &&
                                                           x.CourseId == CourseId &&
                                                           x.Date == Date &&
                                                           x.SlotTime1 == SlotTime1 &&
                                                           x.SlotTime2 == SlotTime2 &&
                                                           x.SlotTime3 == SlotTime3 &&
                                                           x.Id != Id);
        }
    }
}
