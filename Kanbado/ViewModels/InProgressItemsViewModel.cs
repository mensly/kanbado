using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kanbado
{
    public class InProgressItemsViewModel: ItemsViewModel
	{
        public InProgressItemsViewModel(): base(ScreenType.InProgress.GetFilter())
		{
			Title = "In Progress";
		}

        protected override async Task ExecuteLoadItemsCommand(bool forceRefresh)
		{
			if (IsBusy)
				return;
            await base.ExecuteLoadItemsCommand(forceRefresh);
            IsBusy = true;
            try 
            {
                var filter = ScreenType.Backlog.GetFilter();
                var nextItem = (await DataStore.GetItemsAsync(filter, forceRefresh)).FirstOrDefault();
                if (nextItem != null)
                {
                    Items.Add(new ItemViewModel(nextItem)
                    {
                        Color = Color.Blue
                    });
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override async void OnItemSelected(ItemViewModel item)
        {
            if (item.Item.State == ItemState.Backlog) 
            {
                if (await DataStore.StartItemAsync(item.Item))
                {
                    await ExecuteLoadItemsCommand(true);
                }
            }
            else if (await DataStore.CompleteItemAsync(item.Item))
            {
                Items.Remove(item);
            }
		}
    }
}
