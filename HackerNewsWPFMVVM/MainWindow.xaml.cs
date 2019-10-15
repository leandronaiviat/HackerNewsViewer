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
        public MainWindow()
        {
            InitializeComponent();
            StoriesViewModel StoriesModel = new StoriesViewModel();
            DataContext = StoriesModel;
            //DataContext = new CommentsViewModel();
        }
    }
}
