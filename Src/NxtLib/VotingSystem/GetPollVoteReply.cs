using System.Collections.Generic;

namespace NxtLib.VotingSystem
{
    public class GetPollVoteReply : PollVote, IBaseReply
    {
        public IEnumerable<KeyValuePair<string, string>> PostData { get; set; }
        public string RawJsonReply { get; set; }
        public int RequestProcessingTime { get; set; }
        public string RequestUri { get; set; }
    }
}