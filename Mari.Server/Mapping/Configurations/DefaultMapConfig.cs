using Mapster;

namespace Mari.Server.Mapping.Configurations;

public class DefaultMapConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.Default.EnumMappingStrategy(EnumMappingStrategy.ByValue);
    }
}
