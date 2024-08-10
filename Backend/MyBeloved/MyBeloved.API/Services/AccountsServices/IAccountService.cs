using MyBeloved.API.DTOs;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.AccountsServices
{
    public interface IAccountService
    {
        Task<Response<Account>> GetAccountByIdAsync(int id);
        Task<Response<Account>> CreateAccountAsync(string nickname, string email);
        Task<Response<Account>> UpdateAccountByIdAsync(AccountDTO editedAccount);
        Task<Response<List<Account>>> DeleteAccountByIdAsync(int id);
        Task<Response<List<Account>>> GetAllAccountsAsync();
        Task<Response<Account>> GenerateNewPartnerLinkById(int id);
    }
}
