using SportEventReminder.Domain;

public class Team : EntityBase<int>
{
    public string Name { get; set; }

    public string ShortName { get; set; }

    public string TeamTag { get; set; }

    public Area Area { get; set; }
}