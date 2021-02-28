using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingKata.Entities
{
    public struct AccountTransaction
    {
        public DateTime TransactionDate { init; get; }

        public int Amount { init; get; }
    }
}
