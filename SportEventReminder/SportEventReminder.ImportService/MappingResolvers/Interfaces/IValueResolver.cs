using AutoMapper;

namespace SportEventReminder.ImportService.MappingResolvers.Interfaces
{
    public interface IValueResolver<in TSource, in TDestination, TDestMember>
    {
        TDestMember Resolve(TSource source, TDestination destination, TDestMember destMember,
            ResolutionContext context);
    }
}
