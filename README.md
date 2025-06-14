# LedgerApplication

A .NET 8 Web API for recording deposits, withdrawals, and checking account balance and transaction history

## Features

- Add transactions (deposit / withdrawal)
- Get current balance
- View transaction history
- In-memory database (no external DB required)
- Swaggerfor testing

## Technologies

- .NET 8 Web API
- Entity Framework Core (InMemory)
- C#

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Run the Application

```bash
git clone https://github.com/AkhiYofiel/LedgerApplication.git
cd LedgerApplication/LedgerApplication/LedgerApplication
dotnet run
Once the application is running, open your browser and go to:
(http://localhost:5022/swagger/index.html)
