using System.ComponentModel.DataAnnotations;

namespace LedgerApplication.Models
{
    public class Transaction
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Account Number associated with the transaction
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Amount of the transaction
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Type of transaction 
        /// </summary>
        public string TransactionType { get; set; }

        /// <summary>
        /// Date of Transaction
        /// </summary>
        public DateTime DateOfTransaction { get; set; } = DateTime.UtcNow; 
    }
}