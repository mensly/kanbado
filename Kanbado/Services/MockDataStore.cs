using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanbado
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item("First item").WithState(ItemState.Completed),
                new Item("Second item").WithState(ItemState.Deleted),
                new Item("Third item").WithState(ItemState.InProgress),
                new Item("Fourth item"),
                new Item("Fifth item"),
                new Item("Sixth item"),
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			return await UpdateItemAsync(item.WithState(ItemState.Deleted));
		}

		public async Task<bool> CompleteItemAsync(Item item)
		{
            return await UpdateItemAsync(item.WithState(ItemState.Completed));
		}

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(ICollection<ItemState> stateFilter, bool forceRefresh = false)
        {
            if (stateFilter == null)
            {
                return await Task.FromResult(items);
            }
            else
            {
                return await Task.FromResult(items.Where(it => stateFilter.Contains(it.State)));
            }
        }
    }
}
