using System.Collections.Generic;
using System.Linq;
using NxtLib.Internal;
using NxtLib.VotingSystem;

namespace NxtLib
{
    public class TransactionPhasing
    {
        public bool Phased { get; set; }
        public int FinishHeight { get; set; }
        public VotingModel VotingModel { get; set; }
        public string Quorum { get; set; }
        public long? MinBalance { get; set; }
        public ulong? HoldingId { get; set; }
        public MinBalanceModel? MinBalanceModel { get; set; }
        public List<string> WhiteListed { get; set; }
        public List<BinaryHexString> LinkedFullHash { get; set; }
        public BinaryHexString HashedSecret { get; set; }
        public string HashedSecretAlgorithm { get; set; }

        public TransactionPhasing(int finishHeight, VotingModel votingModel, string quorum)
        {
            Phased = true;
            FinishHeight = finishHeight;
            VotingModel = votingModel;
            Quorum = quorum;
            WhiteListed = new List<string>();
            LinkedFullHash = new List<BinaryHexString>();
        }

        public void AppendToQueryParameters(Dictionary<string, string> queryParameters)
        {
            if (Phased)
            {
                queryParameters.Add("phased", Phased.ToString());
                queryParameters.Add("phasingFinishHeight", FinishHeight.ToString());
                queryParameters.Add("phasingVotingModel", ((int)VotingModel).ToString());
                queryParameters.Add("phasingQuorum", Quorum);

                if (MinBalance.HasValue)
                {
                    queryParameters.Add("phasingMinBalance", MinBalance.ToString());
                }
                if (HoldingId.HasValue)
                {
                    queryParameters.Add("phasingHolding", HoldingId.ToString());
                }
                if (MinBalanceModel.HasValue)
                {
                    queryParameters.Add("phasingMinBalanceModel", ((int)MinBalanceModel.Value).ToString());
                }
                WhiteListed.ForEach(w => queryParameters.Add("phasingWhitelisted", w));
                LinkedFullHash.ForEach(h => queryParameters.Add("phasingLinkedFullHash", h.ToHexString()));
                if (HashedSecret != null)
                {
                    queryParameters.Add("phasingHashedSecret", HashedSecret.ToHexString());
                }
                if (!string.IsNullOrEmpty(HashedSecretAlgorithm))
                {
                    queryParameters.Add("phasingHashedSecretAlgorithm", HashedSecretAlgorithm);
                }
            }
        }
    }
}