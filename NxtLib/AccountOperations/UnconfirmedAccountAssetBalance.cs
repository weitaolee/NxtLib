﻿using Newtonsoft.Json;
using NxtLib.Internal;

namespace NxtLib.AccountOperations
{
    public class UnconfirmedAccountAssetBalance
    {
        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        public ulong Asset { get; set; }

        [JsonConverter(typeof(NqtAmountConverter))]
        [JsonProperty(PropertyName = "unconfirmedBalanceQnt")]
        public Amount UnconfirmedBalance { get; set; }
    }
}