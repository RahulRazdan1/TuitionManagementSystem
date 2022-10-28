namespace Application.SlotRequests
{
    public class SlotTimes
    {
        public SlotTimes()
        {
            IsActive = true;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
