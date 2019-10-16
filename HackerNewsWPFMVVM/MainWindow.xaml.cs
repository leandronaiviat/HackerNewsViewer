using HackerNewsWPFMVVM.ModelViews;
using System;
using System.Windows;

namespace HackerNewsWPFMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int StoryId { get; set; }
        public StoriesViewModel StoriesModel { get; set; } = new StoriesViewModel();
        bool _shown;

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
                return;

            _shown = true;

            DataContext = StoriesModel;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
