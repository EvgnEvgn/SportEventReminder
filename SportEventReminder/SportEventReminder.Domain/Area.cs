namespace SportEventReminder.Domain
{
    public class Area : EntityBase<int>
    {
        public string Name { get; set; }

        public string ParentArea { get; set; }
    }
}