using System.Linq;
using MyToolkit.Paging;

namespace SampleUwpApp
{
    public class HamburgerFrame
    {
        public HamburgerFrame()
        {
            Frame = new MtFrame();
            Frame.PageAnimation = null; 
            Frame.Navigated += FrameOnNavigated;

            Hamburger = new Hamburger();
            Hamburger.Content = Frame; 
            Hamburger.ItemChanged += HamburgerOnItemChanged;
        }

        public MtFrame Frame { get; private set; }

        public Hamburger Hamburger { get; set; }

        private void FrameOnNavigated(object sender, MtNavigationEventArgs args)
        {
            var currentItem = Hamburger.TopItems.Concat(Hamburger.BottomItems)
                .FirstOrDefault(i => i.PageType == Frame.CurrentPage.Type); 

            Hamburger.CurrentItem = currentItem;
        }

        private async void HamburgerOnItemChanged(object sender, HamburgerItem item)
        {
            if (item != null)
            {
                if (item.FindPageType)
                {
                    var existingPage = Frame.GetNearestPageOfTypeInBackStack(item.PageType);
                    if (existingPage != null)
                        await Frame.MovePageToTopOfStackAsync(existingPage);
                    else
                        await Frame.NavigateAsync(item.PageType, item.PageParameter);
                }
                else
                    await Frame.NavigateAsync(item.PageType, item.PageParameter);
            }
        }
    }
}