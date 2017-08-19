using System;

using Xamarin.Forms;

namespace Kanbado
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page backlogPage, inProgressPage, donePage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    // TODO
                    throw new NotImplementedException();
                    break;
				default:
                    backlogPage = new ItemsPage(ScreenType.Backlog)
					{
						Title = "Backlog"
					};
                    inProgressPage = new ItemsPage(ScreenType.InProgress)
					{
						Title = "In Progress"
					};
                    donePage = new ItemsPage(ScreenType.Done)
					{
						Title = "Done"
					};
                    break;
            }

			Children.Add(backlogPage);
			Children.Add(inProgressPage);
            Children.Add(donePage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
