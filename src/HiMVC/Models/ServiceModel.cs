using System.Text;

namespace BellagioService.Service.v1.Models {
    public class EntryModelX {
        public string OperatorId { get; set; }

        public string TerminalId { get; set; }

        public string PIN { get; set; }

        public string DrawId { get; set; }

        public string SequenceNumber { get; set; }

        public string PlayNumber { get; set; }

        public decimal AmountPlayed { get; set; }

        public decimal AmountPayed { get; set; }

        public string GameType { get; set; }

        public override string ToString() {

            var str = new StringBuilder();
            str.Append(OperatorId + " / ");
            str.Append(TerminalId + " / ");
            str.Append(SequenceNumber + " / ");
            //str.Append(Voucher + " / ");
            str.Append(PlayNumber + " / ");
            str.Append(AmountPlayed + " / ");
            str.Append(AmountPayed + " / ");

            return str.ToString();
        }

        public override bool Equals(object obj) {
            // STEP 1: Check for null
            if (obj == null) {
                return false;
            }

            // STEP 3: equivalent data types
            if (this.GetType() != obj.GetType()) {
                return false;
            }

            var model = (EntryModelX)obj;

            return this.OperatorId == model.OperatorId &&
                this.TerminalId == model.TerminalId &&
                this.SequenceNumber == model.SequenceNumber &&
                this.PlayNumber == model.PlayNumber &&
                this.AmountPlayed == model.AmountPlayed &&
                this.AmountPayed == model.AmountPayed;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    public class RefillModel {
        public string OperatorId { get; set; }

        public decimal Amount { get; set; }

        public string MaskedPAN { get; set; }

        public string AuthCode { get; set; }

        public string TransactionRef { get; set; }

        public string SequenceNumber { get; set; }

        public override string ToString() {

            var str = new StringBuilder();
            str.Append(OperatorId + " / ");
            str.Append(SequenceNumber + " / ");
            str.Append(TransactionRef + " / ");
            str.Append(AuthCode + " / ");
            str.Append(MaskedPAN + " / ");
            str.Append(Amount + " / ");

            return str.ToString();
        }

        public override bool Equals(object obj) {
            // STEP 1: Check for null
            if (obj == null) {
                return false;
            }

            // STEP 3: equivalent data types
            if (this.GetType() != obj.GetType()) {
                return false;
            }

            var model = (RefillModel)obj;

            return this.OperatorId == model.OperatorId &&
                this.TransactionRef == model.TransactionRef &&
                this.SequenceNumber == model.SequenceNumber &&
                this.AuthCode == model.AuthCode &&
                this.MaskedPAN == model.MaskedPAN &&
                this.Amount == model.Amount;
        
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class ReversalModel {
        public string OperatorId { get; set; }

        public string SequenceNumber { get; set; }

        public override string ToString() {

            var str = new StringBuilder();
            str.Append(OperatorId + " / ");
            str.Append(SequenceNumber + " / ");

            return str.ToString();
        }

        public override bool Equals(object obj) {
            // STEP 1: Check for null
            if (obj == null) {
                return false;
            }

            // STEP 3: equivalent data types
            if (this.GetType() != obj.GetType()) {
                return false;
            }

            var model = (ReversalModel)obj;

            return this.OperatorId == model.OperatorId &&
                this.SequenceNumber == model.SequenceNumber;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class CredentialModel {

        public string OperatorId { get; set; }

        public string PIN { get; set; }

        public string TerminalId { get; set; }

    }

    public class PINModel {
        public string OperatorId { get; set; }

        public string OldPIN { get; set; }

        public string NewPIN { get; set; }

        public override bool Equals(object obj) {
            // STEP 1: Check for null
            if (obj == null) {
                return false;
            }

            // STEP 3: equivalent data types
            if (this.GetType() != obj.GetType()) {
                return false;
            }

            var model = (PINModel)obj;

            return this.OperatorId == model.OperatorId &&
                this.OldPIN == model.OldPIN &&
                this.NewPIN == model.NewPIN;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class DrawModel
    {
        //public string DrawName { get; set; }

        public string Name { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }

    public class ResponseModel {
        public string TransactionId { get; set; }

        public string ResponseCode { get; set; }

        public dynamic PayLoad { get; set; }

        public override string ToString() {
            return string.Format("{0} / {1} / {2}", TransactionId, ResponseCode, PayLoad);
        }

    }

}