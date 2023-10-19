namespace HandySquad.Pagination;

public class PaginatedResultDto<T>
{
    public IEnumerable<T> Data { get; set; }
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    
  
}