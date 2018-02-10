using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace git_commit_msg_notes
{
    public class NotesTxtParser
    {
        public int NextNoteNumber { get; }
        public NotesTxtParser(string notesFile)
        {
            var matches = Regex.Matches(notesFile, "# Step ([0-9]+)", RegexOptions.Multiline);
            int currentNumber = 0;
            foreach (Match match in matches)
            {
                int stepNumber = Int32.Parse(match.Groups[0].Value.Substring(7));
                if (stepNumber > currentNumber)
                {
                    currentNumber = stepNumber;
                }
            }

            this.NextNoteNumber = currentNumber + 1;
        }
    }
}
