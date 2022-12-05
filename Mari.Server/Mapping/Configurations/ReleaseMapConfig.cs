using Mapster;
using Mari.Application.Releases.Commands.CreateDraftRelease;
using Mari.Application.Releases.Commands.CreateRelease;
using Mari.Application.Releases.Commands.CreateReleaseFromDraft;
using Mari.Contracts.Releases.PostRequests;

namespace Mari.Server.Mapping.Configurations;

public class ReleaseMapConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateReleaseRequest.Body, CreateReleaseCommand>()
            .MapToConstructor(true);

        config.ForType<CreateDraftReleaseRequest.Body, CreateDraftReleaseCommand>()
            .MapToConstructor(true);

        config.ForType<CreateReleaseFromDraftRequest.Route, CreateReleaseFromDraftCommand>()
            .MapToConstructor(true);
    }
}
