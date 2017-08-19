using System;
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
