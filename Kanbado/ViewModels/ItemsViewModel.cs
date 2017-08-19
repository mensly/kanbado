using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Kanbado
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ItemViewModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private readonly ICollection<ItemState> filter;

        public ItemsViewModel(ICollection<ItemState> filter)
        {
            this.filter = filter;
            Items = new ObservableCollection<ItemViewModel>();
            LoadItemsCommand = new Command(async (isEmpty) =>
                                           await ExecuteLoadItemsCommand(isEmpty as bool? ?? false));
        }

        protected virtual async Task ExecuteLoadItemsCommand(bool forceRefresh)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(filter, forceRefresh);
                foreach (var item in items)
                {
                    Items.Add(new ItemViewModel(item));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public virtual void OnItemSelected(ItemViewModel item) {
            
        }
    }
}
