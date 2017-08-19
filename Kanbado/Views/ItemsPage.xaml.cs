using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Kanbado
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage(ScreenType screenType)
        {
            InitializeComponent();

            switch (screenType) {
                case ScreenType.Backlog:
                    viewModel = new BacklogItemsViewModel();
                    break;
                case ScreenType.InProgress:
                    viewModel = new InProgressItemsViewModel();
                    break;
                default:
                    viewModel = new ItemsViewModel(screenType.GetFilter());
                    break;
            }
            BindingContext = viewModel;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ItemViewModel;
            if (item == null)
                return;

            viewModel.OnItemSelected(item);

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(viewModel.Items.Count == 0);
        }
    }
}
