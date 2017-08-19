using System;
namespace Kanbado
{
    public class InProgressItemsViewModel: ItemsViewModel
	{
        public InProgressItemsViewModel(): base(ScreenType.InProgress.GetFilter())
		{
			Title = "In Progress";
		}

		public override async void OnItemSelected(Item item)
		{
            if (await DataStore.CompleteItemAsync(item))
            {
                Items.Remove(item);
            }
		}
    }
}
