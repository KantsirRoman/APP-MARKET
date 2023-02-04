using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace MyApp
{

    public class NavButton : ListBoxItem
    {
        static NavButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
        }


        public Uri Navlink
        {
            get { return (Uri)GetValue(NavlinkProperty); }
            set { SetValue(NavlinkProperty, value); }
        }
        public static readonly DependencyProperty NavlinkProperty = DependencyProperty.Register("Navlink", typeof(Uri), typeof(NavButton), new PropertyMetadata(null));

        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(NavButton), new PropertyMetadata(null));


    }
    /*public class NavButton : ListBoxItem
    {
        static NavButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(NavButton), new PropertyMetadata(null));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(NavButton), new PropertyMetadata(null));
        public static readonly DependencyProperty NavUriProperty = DependencyProperty.Register("NavUri", typeof(Uri), typeof(NavButton), new PropertyMetadata(null));



        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Uri NavUri
        {
            get { return (Uri)GetValue(NavUriProperty); }
            set { SetValue(NavUriProperty, value); }
        }
    }*/
}
