using SportEventReminder.Common.Enums;

namespace SportEventReminder.Domain
{
    public class ExternalSourceIntegration : EntityBase<int>
    {
        public ExternalSourceEnum ExternalSource { get; set; }

        public int ExternalObjectId { get; set; }

        public ObjectTypeEnum ObjectType { get; set; }

        public int ObjectId { get; set; }
    }
}
