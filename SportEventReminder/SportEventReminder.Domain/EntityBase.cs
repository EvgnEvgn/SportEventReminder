namespace SportEventReminder.Domain
{
    public class EntityBase<TKeyType>
    {
        public TKeyType Id { get; set; }
    }
}
