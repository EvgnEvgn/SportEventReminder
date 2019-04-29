using SportEventReminder.Domain;

public class ExternalSource : EntityBase<int>
{
    public string Name { get; set; }

    public string Url { get; set; }
}