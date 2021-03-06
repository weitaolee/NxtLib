using System;
using Newtonsoft.Json;
using NxtLib.Internal;

namespace NxtLib.MonetarySystem
{
    public class ExchangeRequest : CurrencyInfo
    {
        [JsonConverter(typeof(NqtAmountConverter))]
        [JsonProperty(PropertyName = Parameters.RateNqt)]
        public Amount Rate { get; set; }

        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        public byte SubType { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        [JsonProperty(PropertyName = Parameters.Transaction)]
        public ulong TransactionId { get; set; }

        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        public long Units { get; set; }
    }
}