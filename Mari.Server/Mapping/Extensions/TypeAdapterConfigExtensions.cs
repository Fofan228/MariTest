using Mapster;

namespace Mari.Server.Mapping.Extensions;

public static class TypeAdapterConfigExtensions
{
    public static void ForManyToOne<T1, T2, T3, TDest>(this TypeAdapterConfig config)
    {
        config.ForType<(T1 t1, T2 t2, T3 t3), TDest>()
            .Map(dest => dest, src => src.t1)
            .Map(dest => dest, src => src.t2)
            .Map(dest => dest, src => src.t3);
    }

    public static void ForManyToOne<T1, T2, TDest>(this TypeAdapterConfig config)
    {
        config.ForType<(T1 t1, T2 t2), TDest>()
            .Map(dest => dest, src => src.t1)
            .Map(dest => dest, src => src.t2);
    }
}
