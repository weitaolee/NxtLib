﻿namespace NxtLib.Aliases
{
    public class AliasReply : Alias, IBaseReply
    {
        public string RawJsonReply { get; set; }
        public int RequestProcessingTime { get; set; }
        public string RequestUri { get; set; }
    }
}