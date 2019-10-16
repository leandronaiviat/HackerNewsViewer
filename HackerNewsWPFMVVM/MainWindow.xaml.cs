using HackerNewsWPFMVVM.ModelViews;
using System.Windows;

namespace HackerNewsWPFMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int storyId { get; set; }
        public StoriesViewModel StoriesModel { get; set; }

        public MainWindow()
        {
            StoriesModel = new StoriesViewModel();
            DataContext = StoriesModel;
            InitializeComponent();
        }
    }
}
