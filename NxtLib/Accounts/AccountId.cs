﻿using Newtonsoft.Json;
using NxtLib.Internal;

namespace NxtLib.Accounts
{
    public class AccountId : BaseReply
    {
        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        public ulong Account { get; set; }
        public string AccountRs { get; set; }
        public string PublicKey { get; set; }
    }
}