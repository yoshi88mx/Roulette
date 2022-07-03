using RouletteGame.Core.Wallet;

namespace RouletteGame.Client.Services
{
    public class WalletService : IWallet
    {
        public Task<bool> AddInitialMoney(int amonut)
        {
            throw new NotImplementedException();
        }

        public Task AddMoney(int mount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CanAddInitialMoney()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAvailable()
        {
            throw new NotImplementedException();
        }

        public Task<List<WalletHistory>> GetHistory()
        {
            throw new NotImplementedException();
        }

        public Task RemoveMoney(int mount)
        {
            throw new NotImplementedException();
        }
    }
}
