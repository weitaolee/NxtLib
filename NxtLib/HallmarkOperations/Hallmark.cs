﻿using System;
using Newtonsoft.Json;
using NxtLib.Internal;

namespace NxtLib.HallmarkOperations
{
    public class Hallmark : BaseReply
    {
        [JsonProperty(PropertyName = "account")]
        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        public ulong AccountId { get; set; }
        public string AccountRs { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Date { get; set; }
        public string Host { get; set; }
        public bool Valid { get; set; }
        public int Weight { get; set; }
    }
}