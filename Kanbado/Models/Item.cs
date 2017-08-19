using System;

namespace Kanbado
{
    public class Item
    {
        public string Id { get; private set; }
        public string Text { get; private set; }
        public ItemState State { get; private set; }

		public Item()
		{
			State = ItemState.Backlog;
		}
        public Item(string text): this()
        {
            Id = Guid.NewGuid().ToString();
            Text = text;
        }

        public Item WithState(ItemState state)
        {
            var item = this.MemberwiseClone() as Item;
            item.State = state;
            return item;
        }
    }
}
