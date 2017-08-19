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
				Items.Add(item);
				await DataStore.AddItemAsync(item);
			});
        }

        public override async void OnItemSelected(Item item)
        {
            if (await DataStore.DeleteItemAsync(item))
            {
                Items.Remove(item);
            }
        }
    }
}
