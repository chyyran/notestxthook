using System;
using System.Collections.Generic;
using System.Text;

namespace git_commit_msg_notes
{
    public class CommitMessage
    {
        public string CodeAffected { get; }
        public string Flaw { get; }
        public string Fix { get; }
        public CommitMessage(string[] message)
        {
            this.CodeAffected = message[2].Substring(message[2].IndexOf("Changed:") == 0 ? 9 : 0);
            this.Flaw = message[3].Substring(message[3].IndexOf("Flaw:") == 0 ? 6 : 0);
            this.Fix = message[4].Substring(message[4].IndexOf("Fix:") == 0 ? 5 : 0);
        }

        public override string ToString()
        {
            return $"Code affected: {this.CodeAffected} {Environment.NewLine}{Environment.NewLine}Flaw: {this.Flaw} {Environment.NewLine}{Environment.NewLine}Fix: {this.Fix}{Environment.NewLine}"; 
        }
    }
}
