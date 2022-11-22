using Mapster;

namespace Mari.Client.Common.Mapping.Configurations;

public class MainMapConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.Default.RequireDestinationMemberSource(true);
    }
}
