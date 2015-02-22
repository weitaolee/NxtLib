using System;
using System.Threading.Tasks;

namespace NxtLib.Accounts
{
    public interface IAccountService
    {
        Task<AccountReply> GetAccount(string accountId, bool? includeLessors = null, bool? includeAssets = null,
            bool? includeCurrencies = null);
        Task<AccountBlockCountReply> GetAccountBlockCount(string accountId);
        Task<AccountBlockIdsReply> GetAccountBlockIds(string accountId, DateTime? timeStamp = null, int? firstIndex = null, int? lastIndex = null);
        Task<AccountBlocksReply<ulong>> GetAccountBlocks(string accountId, DateTime? timeStamp = null, int? firstIndex = null, int? lastIndex = null);
        Task<AccountBlocksReply<Transaction>> GetAccountBlocksIncludeTransactions(string accountId, DateTime? timeStamp = null, int? firstIndex = null, int? lastIndex = null);
        Task<AccountIdReply> GetAccountId(AccountIdLocator locator);
        Task<AccountLessorsReply> GetAccountLessors(string accountId, int? height = null);
        Task<AccountPublicKeyReply> GetAccountPublicKey(string accountId);
        Task<AccountTransactionIdsReply> GetAccountTransactionIds(string accountId, DateTime? timeStamp = null,
            byte? type = null, byte? subtype = null, int? firstIndex = null, int? lastIndex = null,
            int? numberOfConfirmations = null, bool? withMessage = null);
        Task<AccountTransactionsReply> GetAccountTransactions(string accountId, DateTime? timeStamp = null,
            byte? type = null, byte? subtype = null, int? firstIndex = null, int? lastIndex = null,
            int? numberOfConfirmations = null, bool? withMessage = null);
        Task<BalanceReply> GetBalance(string accountId);
        Task<GuaranteedBalanceReply> GetGuaranteedBalance(string accountId, int? numberOfConfirmations = null);
        Task<UnconfirmedTransactionIdsResply> GetUnconfirmedTransactionIds(string accountId = null);
        Task<UnconfirmedTransactionsReply> GetUnconfirmedTransactions(string accountId = null);
        Task<TransactionCreatedReply> SendMoney(CreateTransactionParameters parameters, string recipient, Amount amount);
        Task<TransactionCreatedReply> SetAccountInfo(CreateTransactionParameters parameters, string name, string description);
    }
}