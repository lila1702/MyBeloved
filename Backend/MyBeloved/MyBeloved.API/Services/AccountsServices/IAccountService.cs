using MyBeloved.API.DTOs.Account;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.AccountsServices
{
    public interface IAccountService
    {
        Task<Response<Account>> GetAccountByIdAsync(int id);
        Task<Response<Account>> CreateAccountAsync(AccountDTO newAccount);
        Task<Response<Account>> UpdateAccountByIdAsync(AccountEditDTO editedAccount);
        Task<Response<List<Account>>> DeleteAccountByIdAsync(int id);
        Task<Response<List<Account>>> GetAllAccountsAsync();
        Task<Response<Account>> GenerateNewPartnerLinkById(int id);
    }
}
