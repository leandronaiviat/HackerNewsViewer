using System.Collections.Generic;

namespace HackerNewsWPFMVVM.ModelViews
{
    public class BaseViewModel
    {
        public List<string> MenuItems { get; set; }

        public BaseViewModel()
        {
            MenuItems = new List<string>();
            MenuItems.Add("Best");
            MenuItems.Add("Top");
            MenuItems.Add("New");
            MenuItems.Add("Ask");
            MenuItems.Add("Next");
        }
    }
}
