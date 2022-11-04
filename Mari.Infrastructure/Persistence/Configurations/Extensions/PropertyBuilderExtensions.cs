using System.Reflection.Emit;
using Mari.Domain.Common.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mari.Infrastructure.Persistence.Configurations.Extensions;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TWrapper> IsValueObjectWrapper<TBase, TWrapper>(this PropertyBuilder<TWrapper> propertyBuilder)
        where TWrapper : ValueObjectWrapper<TBase, TWrapper>, new()
        where TBase : IComparable<TBase>
    {
        propertyBuilder.HasConversion(
            valueObject => valueObject.Value,
            value => ValueObjectWrapper<TBase, TWrapper>.Create(value));

        return propertyBuilder;
    }
}
