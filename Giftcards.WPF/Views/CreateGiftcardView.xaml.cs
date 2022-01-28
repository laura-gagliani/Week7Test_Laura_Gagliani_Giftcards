using GalaSoft.MvvmLight.Messaging;
using Giftcards.WPF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Giftcards.WPF.Views
{
    /// <summary>
    /// Interaction logic for CreateGiftcardView.xaml
    /// </summary>
    public partial class CreateGiftcardView : Window
    {
        public CreateGiftcardView()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseCreateFormMessage>(this, _ => Close());

            Closing += (s, e) =>
            { 
                Messenger.Default.Unregister(this);
                Messenger.Default.Unregister(DataContext);
            };
        }

            }
}
