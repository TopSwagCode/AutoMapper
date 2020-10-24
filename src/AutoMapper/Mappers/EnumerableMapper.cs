using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper.Internal;

namespace AutoMapper.Mappers
{
    using static Expression;
    using static CollectionMapperExpressionFactory;

    public class EnumerableMapper : EnumerableMapperBase
    {
        public override bool IsMatch(in TypePair context) => 
            context.SourceType.IsEnumerableType() && (context.DestinationType.IsInterface && context.DestinationType.IsEnumerableType());

        public override Expression MapExpression(IGlobalConfiguration configurationProvider, ProfileMap profileMap,
            IMemberMap memberMap, Expression sourceExpression, Expression destExpression, Expression contextExpression)
        {
            if(destExpression.Type.IsInterface)
            {
                var listType = typeof(ICollection<>).MakeGenericType(ElementTypeHelper.GetElementType(destExpression.Type));
                destExpression = Convert(destExpression, listType);
            }
            return MapCollectionExpression(configurationProvider, profileMap, memberMap, sourceExpression,
                destExpression, contextExpression, typeof(List<>), MapItemExpr);
        }
    }
}