namespace Ipm.Model
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;

    using Ipm.DataModel;
    using Ipm.Model.Transactions;

    public class IpmModel
    {
        private readonly List<TransactionBase> transactions = new List<TransactionBase>();

        private void Load()
        {
            var dataset = new IpmDataSet();
            // dataset.ReadXml("");
            foreach (var t in dataset.Transaction)
            {
                var bsr = t.GetBuySellTransactionRows();
                if (bsr.Length > 0)
                {
                    var bst = new BuySellTransaction()
                                  {
                                      TransactionDate = t.TransactionDate,
                                      Amount = t.Amount,
                                      Price = bsr[0].Price,
                                      Comission = bsr[0].Comission,
                                  };
                    this.transactions.Add(bst);
                }
                else
                {
                    var ct = new CashTransaction() { TransactionDate = t.TransactionDate, Amount = t.Amount, };
                    this.transactions.Add(ct);
                }
            }
        }

        public IList<TransactionBase> Transactions
        {
            get
            {
                return this.transactions;
            }
        }
    }
}