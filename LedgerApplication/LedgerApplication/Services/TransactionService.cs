using LedgerApplication.Data;
using LedgerApplication.Models;
using LedgerApplication.Models.Request;
using LedgerApplication.Models.Response;

namespace LedgerApplication.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly LedgerContext _ledgerContext;
        public TransactionService(LedgerContext ledgerContext)
        {
            // Initialize services
            _ledgerContext = ledgerContext ?? throw new ArgumentNullException(nameof(ledgerContext));
        }

        /// <inheritdoc/>
        public IEnumerable<Transaction> GetAllTransactions() => _ledgerContext.Transactions.OrderByDescending(t => t.DateOfTransaction);

        /// <inheritdoc/>
        public decimal GetBalance() => _ledgerContext.Transactions.Sum(t => t.Amount);
        
        /// <inheritdoc/>
        public TransactionResponse AddTransaction(TransactionRequest request)
        {
            var currentBalance = GetBalance();

            if (request.TransactionType.ToLowerInvariant() == "withdrawal" && request.Amount > currentBalance)
            {
                return new TransactionResponse
                {
                    Message = $"Insufficient funds for withdrawal. Current Balance: {currentBalance}"
                };
            }

            var transaction = new Transaction
            {
                TransactionType = request.TransactionType,
                Amount = request.TransactionType.ToLowerInvariant() == "deposit" ? request.Amount : -request.Amount
            };

            _ledgerContext.Transactions.Add(transaction);
            _ledgerContext.SaveChanges();

            return new TransactionResponse
            {
                Message = $"Transaction successful. Current Balance: {GetBalance()}"
            };
        }
    }
}