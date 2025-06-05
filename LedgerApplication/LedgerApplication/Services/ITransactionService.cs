using LedgerApplication.Models;
using LedgerApplication.Models.Request;
using LedgerApplication.Models.Response;
namespace LedgerApplication.Services
{
    /// <summary>
    /// Interface defining transaction service operations.
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Retrieves the current balance of the ledger.
        /// </summary>
        /// <returns></returns>
        decimal GetBalance(string accountNumber);
        /// <summary>
        /// Retrieves all transactions in the ledger, ordered by date.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Transaction> GetAllTransactions(string accountNumber);
        /// <summary>
        /// Adds a new transaction to the ledger.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TransactionResponse AddTransaction(TransactionRequest request);       
    }
}