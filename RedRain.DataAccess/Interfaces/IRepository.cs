namespace RedRain.DataAccess.Interfaces
{
    #region RepositoryBase

    public interface IRepository : IFetch, IFetchList, IExecute { }

    public interface IRepositoryWithObjectHierarchyMapSettings : IRepository, IFetchWithObjectHierarchyMapSettings, IFetchListWithObjectHierarchyMapSettings { }

    #endregion

    #region Fetch

    public interface IFetch
    {
        Task<TOutput?> FetchAsync<TInput, TOutput>(TInput input) where TInput : IRequestObject;
    }

    public interface IFetchWithObjectHierarchyMapSettings
    {
        Task<TOutput?> FetchAsync<TInput, TFirst, TSecond, TOutput>(TInput input, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id") where TInput : IRequestObject;
    }

    #endregion

    #region Fetch List

    public interface IFetchList
    {
        Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput input) where TInput : IRequestObject;
    }

    public interface IFetchListWithObjectHierarchyMapSettings
    {
        Task<TOutput> FetchListAsync<TInput, TFirst, TSecond, TOutput>(TInput input, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id") where TInput : IRequestObject;
    }

    #endregion

    #region Execute

    public interface IExecute
    {
        Task<int> ExecuteAsync<TInput>(TInput input) where TInput : IRequestObject;
    }

    #endregion
}
