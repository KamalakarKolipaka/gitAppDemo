using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Core.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public string  AccountNumber { get; set; }

        [Required]
        public decimal TransactionAmount { get; set; }

        [Required]
        public decimal CurrentTotalAmount { get; set; }

        [Required]
        public TranStatus TransactionStatus { get; set; }

        [Required]
        public bool IsSuccessful => TransactionStatus.Equals(TranStatus.Success);

        //[Required]
        //[StringLength(50)]
        //public string TransactionSourceAccount { get; set; }


        //[Required]
        //[StringLength(50)]
        //public string TransactionDestinationAccount { get; set; }

        [StringLength(100)]
        public string TransactionDescription{ get; set; }
        public TranType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }        
    }
    public enum TranStatus
    {
        Failed,
        Success,
        Error
    }

    public enum TranType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}
