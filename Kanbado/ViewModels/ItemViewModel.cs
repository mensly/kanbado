using System;
using Xamarin.Forms;
namespace Kanbado
{
    public class ItemViewModel
    {
        public Item Item { get; private set; }
        public string Text => Item.Text;
        public Color Color { get; set; }
        public ItemViewModel(Item item)
        {
            Item = item;
            Color = item.State.ToColor();
        }
    }
}
