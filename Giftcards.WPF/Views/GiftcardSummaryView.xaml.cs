using GalaSoft.MvvmLight.Messaging;
using Giftcards.WPF.Messages;
using Giftcards.WPF.ViewModels;
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
    /// Interaction logic for GiftcardSummaryView.xaml
    /// </summary>
    public partial class GiftcardSummaryView : Window
    {
        public GiftcardSummaryView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowCreateFormMessage>(this, OnShowCreateFormMessageReceived);
        }

        private void OnShowCreateFormMessageReceived(ShowCreateFormMessage message)
        {
            CreateGiftcardView createView = new CreateGiftcardView();
            CreateGiftcardViewModel createViewModel = new CreateGiftcardViewModel();
            createView.DataContext = createViewModel;

            createView.Show();
        }
    }
}
