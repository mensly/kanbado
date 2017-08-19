using System;
using Xamarin.Forms;

namespace Kanbado
{
    public enum ItemState
    {
        Backlog,
        InProgress,
        Completed,
        Deleted
    }

	public static class ItemStateExtensions
	{
        public static Color ToColor(this ItemState instance)
        {
            switch (instance)
            {
                case ItemState.Deleted:
                    return Color.Red;
                case ItemState.Completed:
                    return Color.Green;
                default:
                    return Color.Black;
            }
        }
        public static ScreenType GetScreen(this ItemState instance)
		{
			switch (instance)
			{
				case ItemState.Backlog:
                    return ScreenType.Backlog;
                case ItemState.InProgress:
                    return ScreenType.InProgress;
                case ItemState.Completed:
                case ItemState.Deleted:
                    return ScreenType.Done;
                default:
                    throw new InvalidOperationException();
			}
		}
	}
}
