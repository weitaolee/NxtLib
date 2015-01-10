using System.Collections.Generic;
using Newtonsoft.Json;

namespace NxtLib.AssetOperations
{
    public class AccountAssets : BaseReply
    {
        [JsonProperty(PropertyName = "accountAssets")]
        public List<AccountAsset> AccountAssetList { get; set; }
    }
}