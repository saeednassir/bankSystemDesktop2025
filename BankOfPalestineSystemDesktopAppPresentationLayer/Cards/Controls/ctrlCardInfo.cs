using BankOfPalestineSystemBusinessLayer;
using BankOfPalestineSystemDesktopAppPresentationLayer.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Cards.Controls
{
    public partial class ctrlCardInfo : UserControl
    {

        private clsCard _Card;
        private int _CardID = -1;

        public int CardID
        {
            get { return _CardID; }
        }


        public clsCard SelectedCardInfo
        {
            get { return _Card; }
        }


        public ctrlCardInfo()
        {
            InitializeComponent();
        }

        public void LoadCardInfo(int CardID)
        {
            _Card = clsCard.Find(CardID);
            if (_Card == null)
            {
                _ResetCardInfo();
                MessageBox.Show("لا يوجد بطاقة بهذا الرقم = " + CardID.ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillCardInfo();
        }

        private void _FillCardInfo()
        {

            _CardID = _Card.ID;
            lblCardID.Text = _CardID.ToString();
            lblCardTypeName.Text = $"بطاقة {_Card.CardTypeInfo.TypeName}";
            lblCardNumber.Text = _Card.CardNumber;
            lblNameOnCard.Text = _Card.NameOnCard;

            DateTime Exp = _Card.ExpierdDate;
            lblExp.Text = $"{Exp.Month}/{Exp.Year}";
            lblBalance.Text = Math.Round(_Card.AccountLinkedInfo.Balance, _Card.AccountLinkedInfo.CurrencyInfo.DecimalPlaces,MidpointRounding.ToEven) + _Card.AccountLinkedInfo.CurrencyInfo.CodeCurrency;
            lblClientNumber.Text = $"{_Card.AccountLinkedInfo.BranchInfo.Code}-{_Card.AccountLinkedInfo.ClientInfo.ClientNumber}";

            if (_Card.IsActive)
                lblIsActive.Text = "نعم";
            else
                lblIsActive.Text = "لا";

        }

        public void _ResetCardInfo()
        {
           
            lblCardID.Text = "[؟؟؟]";
            lblIsActive.Text = "[؟؟؟]";
            lblCardTypeName.Text = "بطاقة ؟؟؟؟";
            lblCardNumber.Text = "???? ???? ???? ????";
            lblNameOnCard.Text = "???????????????????";
            lblClientNumber.Text = "???-???";
            lblExp.Text = "??/??";
        }


    }
}
