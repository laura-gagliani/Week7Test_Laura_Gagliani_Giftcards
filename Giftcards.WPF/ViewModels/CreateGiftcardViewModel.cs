using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Giftcards.Core.BusinessLayers;
using Giftcards.Core.Entities;
using Giftcards.Core.Mock.Repositories;
using Giftcards.WPF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Giftcards.WPF.ViewModels
{
    public class CreateGiftcardViewModel : ViewModelBase
    {
        public ICommand CreateNewGiftcardCommand { get; set; }
        public CreateGiftcardViewModel()
        {
            CreateNewGiftcardCommand = new RelayCommand(() => ExecuteCreateNewGiftcard(), () => CanExecuteCreateNewGiftcard());

            if (!IsInDesignMode)
            {
                PropertyChanged += (s, e) =>
                {
                    (CreateNewGiftcardCommand as RelayCommand).RaiseCanExecuteChanged();
                };
            }
        }

        private bool CanExecuteCreateNewGiftcard()
        {
            return !string.IsNullOrEmpty(_recipient) &&
                !string.IsNullOrEmpty(_sender) &&
                !string.IsNullOrEmpty(_message) &&
                (_amount > 0) && (_expirationDate > DateTime.Today);
        }

        private void ExecuteCreateNewGiftcard()
        {
            MainBusinessLayer bl = new MainBusinessLayer(new MockGiftcardRepository());

            Giftcard g = new Giftcard();
            g.Sender = _sender;
            g.Recipient = _recipient;
            g.Message = _message;
            g.Amount = _amount;
            g.ExpirationDate = _expirationDate; 

            Response resp = bl.CreateNewGiftcard(g);


            if (!resp.IsSuccessful)
            {
                Messenger.Default.Send(new DialogMessage()
                {
                    Title = "Create new giftcard",
                    Content = resp.Message,
                    Icon = MessageBoxImage.Error
                });
            }
            else 
            {
                Messenger.Default.Send(new DialogMessage()
                {
                    Title = "Create new giftcard",
                    Content = resp.Message,
                    Icon = MessageBoxImage.Information
                });

                Messenger.Default.Send(new CloseCreateFormMessage());

            }

        }

        private string _recipient;
        public string Recipient
        {
            get { return _recipient; }
            set { _recipient = value; RaisePropertyChanged(); }
        }

        private string _sender;
        public string Sender
        {
            get { return _sender; }
            set { _sender = value; RaisePropertyChanged(); }
        }

        private double _amount;
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged(); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(); }
        }

        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; RaisePropertyChanged(); }
        }
    }
}
