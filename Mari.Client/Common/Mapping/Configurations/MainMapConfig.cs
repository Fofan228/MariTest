using Mapster;
using Mari.Client.Models.Releases;
using Mari.Contracts.Releases.PostRequests;

namespace Mari.Client.Common.Mapping.Configurations;

public class MainMapConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<ReleaseModel, CreateReleaseRequest.Body>()
            .Map(dest => dest.MainIssue, src => src.MainIssue)
            .TwoWays();
    }
}
