﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyApp.UserComponent
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class CustomDialog : Window
    {
        public CustomDialog(string str1, string str2, string str3, byte[] img, string str4)
        {
            InitializeComponent();

            // Встановлюємо значення в моделі даних
            var vm = new MyViewModel(str1, str2, str3, img, str4);
            
            // Прив'язуємо модель даних до вікна
            this.DataContext = vm;
        }
    private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        var textBlock = sender as TextBlock;
        if (textBlock != null)
        {
            Clipboard.SetText(textBlock.Text);
        }
    }
    }
    

    
    
}
    /*public class CustomDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _message1 = "First message";
        public string Message1
        {
            get { return _message1; }
            set
            {
                _message1 = value;
                OnPropertyChanged("Message1");
            }
        }

        private string _message2 = "Second message";
        public string Message2
        {
            get { return _message2; }
            set
            {
                _message2 = value;
                OnPropertyChanged("Message2");
            }
        }

        private string _message3 = "Third message";
        public string Message3
        {
            get { return _message3; }
            set
            {
                _message3 = value;
                OnPropertyChanged("Message3");
            }
        }

        private BitmapImage _imageSource = new BitmapImage(new Uri("pack://application:,,,/YourNamespace;component/Images/default.jpg"));
        public BitmapImage ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }*/
