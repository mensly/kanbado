using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanbado
{
    public interface IDataStore<T>
    {
		Task<bool> AddItemAsync(T item);
		Task<bool> StartItemAsync(T item);
		Task<bool> UpdateItemAsync(T item);
		Task<bool> DeleteItemAsync(T item);
		Task<bool> CompleteItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(ICollection<ItemState> stateFilter = null, bool forceRefresh = false);
    }
}
