using System;
using System.IO;

namespace git_commit_msg_notes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string commitMessage = File.ReadAllText(".git/COMMIT_EDITMSG");
            Console.WriteLine(commitMessage);
            Environment.Exit(1);
        }
    }
}
