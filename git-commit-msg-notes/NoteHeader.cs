using System;
using System.Collections.Generic;
using System.Text;

namespace git_commit_msg_notes
{
    public class NoteHeader
    {
        public int Number { get; }
        public NoteHeader(int number)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return $"{Environment.NewLine}#########{Environment.NewLine}# Step {Number}{Environment.NewLine}";
        }
    }
}
