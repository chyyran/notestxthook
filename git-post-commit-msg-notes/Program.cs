using System;
using System.Diagnostics;
using System.IO;

namespace git_post_commit_msg_notes
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(".git/AMEND_COMMIT"))
            {
                File.Delete(".git/AMEND_COMMIT");
                Process.Start("git", $"commit --amend --no-verify").WaitForExit();
            }
        }
    }
}
