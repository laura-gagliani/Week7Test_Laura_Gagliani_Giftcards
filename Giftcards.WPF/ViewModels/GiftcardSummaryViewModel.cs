using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Giftcards.Core.BusinessLayers;
using Giftcards.Core.Entities;
using Giftcards.Core.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Giftcards.WPF.ViewModels
{
    public class GiftcardSummaryViewModel : ViewModelBase
    {
        public ICommand ShowCreateFormCommand { get; set; }
        public ICommand LoadGiftcardsCommand { get; set; }

        public GiftcardSummaryViewModel()
        {
            ShowCreateFormCommand = new RelayCommand(() => ExecuteShowCreateForm());
            LoadGiftcardsCommand = new RelayCommand(() => ExecuteLoadGiftcards());

            _giftcardSource = new ObservableCollection<GiftcardRowViewModel>();
            _giftcards = new CollectionView(_giftcardSource);

            LoadGiftcardsCommand.Execute(null);
        }

        public ObservableCollection<GiftcardRowViewModel> _giftcardSource;
        private ICollectionView _giftcards;
        public ICollectionView Giftcards
        {
            get { return _giftcards; }
            set { _giftcards = value; RaisePropertyChanged(); }
        }

        private void ExecuteLoadGiftcards()
        {
            MainBusinessLayer bl = new MainBusinessLayer(new MockGiftcardRepository());
            IList<Giftcard> giftcards = bl.FetchAllGiftcards();

            _giftcardSource.Clear();

            foreach (var item in giftcards)
            {
                GiftcardRowViewModel row = new GiftcardRowViewModel();
                _giftcardSource.Add(row);
            }
        }

        private void ExecuteShowCreateForm()
        {
            throw new NotImplementedException();
        }
    }
}
