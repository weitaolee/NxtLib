﻿using System.Collections.Generic;
using Newtonsoft.Json;
using NxtLib.Internal;

namespace NxtLib.ServerInfo
{
    public class GetConstantsReply : BaseReply
    {
        [JsonConverter(typeof(ApiTagsConverter))]
        public Dictionary<string, ApiTag> ApiTags { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> CurrencyTypes { get; set; }
        public IEnumerable<IEnumerable<string>> DisabledApis { get; set; }
        public IEnumerable<string> DisabledApiTags { get; set; }

        public long EpochBeginning { get; set; }

        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        public ulong GenesisAccountId { get; set; }

        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        public ulong GenesisBlockId { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> HashAlgorithms { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> HoldingTypes { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> MintingHashAlgorithms { get; set; }
        public int MaxArbitraryMessageLength { get; set; }
        public int MaxBlockPayloadLength { get; set; }
        public int MaxPhasingDuration { get; set; }
        public int MaxPrunableMessageLength { get; set; }
        public int MaxTaggedDataDataLength { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> MinBalanceModels { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> PeerStates { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> PhasingHashAlgorithms { get; set; }

        [JsonConverter(typeof(RequestTypesConverter))]
        public IList<RequestType> RequestTypes { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> ShufflingParticipantStates { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> ShufflingStages { get; set; }

        [JsonConverter(typeof(TransactionTypesConverter))]
        public Dictionary<int, Dictionary<int, TransactionType>> TransactionTypes { get; set; }

        [JsonConverter(typeof(TransactionSubTypesConverter))]
        public Dictionary<string, TransactionType> TransactionSubTypes { get; set; }

        [JsonConverter(typeof(DictionaryConverter))]
        public Dictionary<string, sbyte> VotingModels { get; set; }
    }
}