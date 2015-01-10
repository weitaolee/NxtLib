﻿using Newtonsoft.Json;
using NxtLib.Internal;

namespace NxtLib.AccountOperations
{
    public class AccountAssetBalance
    {
        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        public ulong Asset { get; set; }

        [JsonConverter(typeof(NqtAmountConverter))]
        [JsonProperty(PropertyName = "balanceQnt")]
        public Amount Balance { get; set; }
    }
}