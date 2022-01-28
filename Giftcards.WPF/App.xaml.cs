using Giftcards.Core.Mock.InMemoryStorage;
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
            base.OnStartup(e);

            Storage.InitializeMemory();

            GiftcardSummaryView view = new GiftcardSummaryView();
            GiftcardSummaryViewModel viewmodel = new GiftcardSummaryViewModel();
            view.DataContext = viewmodel;

            view.Show();
        }
    }
}
