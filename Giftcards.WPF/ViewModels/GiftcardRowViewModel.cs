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
    public class GiftcardRowViewModel : ViewModelBase
    {
        public ICommand DeleteGiftcardCommand { get; set; }
        public ICommand UpdateGiftcardCommand { get; set;}

        private Giftcard _giftcard;
        public GiftcardRowViewModel(Giftcard item) : this() //costruttore con parametro per associazione specifica row-giftcard
        {
            this._giftcard = item;

            Id = item.Id;
            Recipient = item.Recipient;
            Sender = item.Sender;
            Amount = item.Amount;
            Message = item.Message;
            ExpirationDate = item.ExpirationDate;
            TextDateTime = item.ExpirationDate.ToShortDateString();
        }

        public GiftcardRowViewModel()
        {
            DeleteGiftcardCommand = new RelayCommand(() => ExecuteDelete());
            UpdateGiftcardCommand = new RelayCommand(() => ExecuteUpdate());
        }

        private void ExecuteUpdate()
        {
            Messenger.Default.Send(
                new ShowUpdateFormMessage()
                {
                    Giftcard = _giftcard,
                });
        }

        private void ExecuteDelete()
        {
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Warning",
                Content = "Do you confirm deletion?",
                Icon = System.Windows.MessageBoxImage.Warning,
                Buttons = System.Windows.MessageBoxButton.YesNo,
                Callback = OnMessageBoxResultReceived

            });
        }

        private void OnMessageBoxResultReceived(MessageBoxResult clickResult)
        {
            if (clickResult == MessageBoxResult.Yes)
            {
                MainBusinessLayer bl = new MainBusinessLayer(new MockGiftcardRepository());
                Response response = bl.DeleteGiftcard(_giftcard);

                if (!response.IsSuccessful)
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Error",
                        Content = response.Message,
                        Icon = MessageBoxImage.Error,
                        Buttons = MessageBoxButton.OK,
                    });
                    
                    return;
                }
                else
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Deletion confirmed",
                        Content = response.Message,
                        Icon = MessageBoxImage.Information,
                        Buttons = MessageBoxButton.OK,
                    });
                    return;
                }
            }
        }

        #region proprietà giftcard
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
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
        #endregion

        private bool _showDetails;
        public bool ShowDetails
        {
            get { return _showDetails; }
            set { _showDetails = value; RaisePropertyChanged(); }
        }

        private string _textDateTime;
        public string TextDateTime
        {
            get { return _textDateTime; }
            set { _textDateTime = value; RaisePropertyChanged(); }
        }
        

    }
}
