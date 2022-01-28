using GalaSoft.MvvmLight;
using Giftcards.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftcards.WPF.ViewModels
{
    public class GiftcardRowViewModel : ViewModelBase
    {

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
        }

        public GiftcardRowViewModel()
        {
            //TODO: comandi update e delete
        }

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

        private bool _showDetails;
        public bool ShowDetails
        {
            get { return _showDetails; }
            set { _showDetails = value; RaisePropertyChanged(); }
        }



    }
}
