using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoMapper.Configuration.Conventions
{
    public interface IParentSourceToDestinationNameMapper
    {
        List<ISourceToDestinationNameMapper> NamedMappers { get; }
        MemberInfo GetMatchingMemberInfo(TypeDetails sourceTypeDetails, Type destType, Type destMemberType, string nameToSearch);
    }
}