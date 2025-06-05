using LedgerApplication.Data;
using LedgerApplication.Models.Request;
using LedgerApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace Ledger.UniTests.Services
{

    public class TransactionServiceTests
    {
        private readonly LedgerContext _ledgerContext;

        private readonly TransactionService _service;

        public TransactionServiceTests()
        {
            var options = new DbContextOptionsBuilder<LedgerContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;
            _ledgerContext = new LedgerContext(options);
            _service = new TransactionService(_ledgerContext);
        }

        [Fact]
        public void AddTransaction_Deposit_ShouldSuceed()
        {
            var request = new TransactionRequest
            {
                TransactionType = "deposit",
                Amount = 10
            };

            var result = _service.AddTransaction(request);

            Assert.Equal("Transaction successful. Current Balance: 10", result.Message);
        }

        [Fact]
        public void AddTransaction_Withdrawal_WithSufficientBalance_ShouldSucceed()
        {
            // Arrange - deposit first
            _service.AddTransaction(new TransactionRequest { TransactionType = "deposit", Amount = 200m });

            var withdrawalRequest = new TransactionRequest
            {
                TransactionType = "withdrawal",
                Amount = 150m
            };

            var result = _service.AddTransaction(withdrawalRequest);

            Assert.Equal("Transaction successful. Current Balance: 50", result.Message);
        }

        [Fact]
        public void AddTransaction_Withdrawal_WithInsufficientBalance_ShouldFail()
        {
            var withdrawalRequest = new TransactionRequest
            {
                TransactionType = "withdrawal",
                Amount = 100m
            };

            var result = _service.AddTransaction(withdrawalRequest);

            Assert.Equal("Insufficient funds for withdrawal. Current Balance: 0", result.Message);

        }

        [Fact]
        public void GetAllTransations_ShouldReturnAllTransactions()
        {
            _service.AddTransaction(new TransactionRequest { TransactionType = "deposit", Amount = 100 });
            _service.AddTransaction(new TransactionRequest { TransactionType = "deposit", Amount = 1000 });

            var history = _service.GetAllTransactions().ToList();

            Assert.Equal(2, history.Count);
            Assert.Equal(1100, _service.GetBalance());
        }
    }
}

