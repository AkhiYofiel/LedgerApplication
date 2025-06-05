using LedgerApplication.Models.Request;
using LedgerApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace LedgerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            // Initialize services
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }
        /// <summary>
        /// Gets the current balance.
        /// </summary>
        /// <returns>The current balance as a decimal.</returns>
        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            var balance = _transactionService.GetBalance(); 
            var response = new { message = $"Current Balance: {balance}" };
            return Ok(response);
        }

            /// <summary>
            ///Gets the transaction history.
            ///</summary>
            ///<returns>A list of transactions.</returns>
            [HttpGet("transactionhistory")]
        public IActionResult GetAllTransactions() => Ok(_transactionService.GetAllTransactions());

        /// <summary>
        /// Record a new transaction.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateTransaction([FromBody] TransactionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = _transactionService.AddTransaction(request);
                return Ok(response);
            
        }
    }
}