namespace Tadbir.Domain.Core
{
    public interface IHandelMessage<T> where T : class
    {
       
        Task<bool> AfterReadMessageAsync(T Message);
    }
}
