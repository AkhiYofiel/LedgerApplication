using System.ComponentModel.DataAnnotations;

namespace LedgerApplication.Models.Request
{
    /// <summary>
    /// Request model for adding a transaction to the ledger.
    /// </summary>
    public class TransactionRequest
    {
        /// <summary>
        /// AccountNumber
        /// </summary>
        [Required]
        public required string AccountNumber { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public required decimal Amount { get; set; }

        /// <summary>
        /// TransactionType
        /// </summary>
        [Required]
        [RegularExpression("^(deposit|withdrawal)$", ErrorMessage = "TransactionType must be 'deposit' or 'withdrawal'.")]
        public required string TransactionType { get; set; }
    }
}
