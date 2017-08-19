using System;
using Xamarin.Forms;

namespace Kanbado
{
    public class BacklogItemsViewModel: ItemsViewModel
    {
        public BacklogItemsViewModel(): base(ScreenType.Backlog.GetFilter())
		{
			Title = "Backlog";
			MessagingCenter.Subscribe<NewItemPage, string>(this, "AddItem", async (obj, text) =>
			{
                var item = new Item(text as string);
                Items.Add(new ItemViewModel(item));
				await DataStore.AddItemAsync(item);
			});
        }

        public override async void OnItemSelected(ItemViewModel item)
        {
            if (await DataStore.DeleteItemAsync(item.Item))
            {
                Items.Remove(item);
            }
        }
    }
}
