using System;
using System.Collections.Generic;

namespace Kanbado
{
    public enum ScreenType
    {
        Backlog,
        InProgress,
        Done
    }

    public static class ScreenTypeExtensions {
        public static ICollection<ItemState> GetFilter(this ScreenType instance)
        {
			switch (instance)
			{
				case ScreenType.Backlog:
					return new List<ItemState>() { ItemState.Backlog };
                case ScreenType.InProgress:
					return new List<ItemState>() { ItemState.InProgress };
                case ScreenType.Done:
                    return new List<ItemState>()
                    { 
                        ItemState.Completed, 
                        ItemState.Deleted 
                    };
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
