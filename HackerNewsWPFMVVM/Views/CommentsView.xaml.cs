using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HackerNewsWPFMVVM.Views
{
    /// <summary>
    /// Interaction logic for CommentsView.xaml
    /// </summary>
    public partial class CommentsView : UserControl
    {

        //public int MyProperty
        //{
        //    get { return (int)GetValue(MyPropertyProperty); }
        //    set { SetValue(MyPropertyProperty, value); }
        //}

        //public static readonly DependencyProperty MyPropertyProperty =
        //    DependencyProperty.Register("MyProperty", typeof(int), typeof(CommentsView), new PropertyMetadata(999));



        //public static readonly DependencyProperty CityProperty = DependencyProperty.Register
        //            (
        //                 "City",
        //                 typeof(string),
        //                 typeof(CommentsView),
        //                 new PropertyMetadata(string.Empty)
        //            );

        //public string City
        //{
        //    get { return (string)GetValue(CityProperty); }
        //    set { SetValue(CityProperty, value); }
        //}




        public CommentsView()
        {
            InitializeComponent();
        }
    }
}
