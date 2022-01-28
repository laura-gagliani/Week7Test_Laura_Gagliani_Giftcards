using GalaSoft.MvvmLight.Messaging;
using Giftcards.Core.Mock.InMemoryStorage;
using Giftcards.WPF.Messages;
using Giftcards.WPF.ViewModels;
using Giftcards.WPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Giftcards.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Messenger.Default.Register<DialogMessage>(this, OnDialogMessageReceived);


            base.OnStartup(e);

            Storage.InitializeMemory();

            GiftcardSummaryView view = new GiftcardSummaryView();
            GiftcardSummaryViewModel viewmodel = new GiftcardSummaryViewModel();
            view.DataContext = viewmodel;

            view.Show();
        }

        private void OnDialogMessageReceived(DialogMessage message)
        {
            MessageBoxResult result = MessageBox.Show(message.Content, message.Title, message.Buttons, message.Icon);

            if (message.Callback != null)
                message.Callback(result);
        }
    }
}
