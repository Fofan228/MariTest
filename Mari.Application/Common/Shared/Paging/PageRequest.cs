namespace Mari.Application.Common.Shared.Paging;

public abstract record PageRequest
{
    public PageRequest(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }

    public int Page { get; }
    public int PageSize { get; }
    public Range Range => ((Page - 1) * PageSize)..(Page * PageSize);
}
