using System;

using Xamarin.Forms;

namespace Kanbado
{
    public partial class NewItemPage : ContentPage
    {
        public string Text { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Text = "Item Name";

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Text);
            await Navigation.PopToRootAsync();
        }
    }
}
