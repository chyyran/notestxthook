using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace git_commit_msg_notes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] commitMessage = File.ReadAllLines(".git/COMMIT_EDITMSG");
            FileInfo gitCommitInfo = new FileInfo(".git/COMMIT_EDITMSG");
            var rootDirectory = new DirectoryInfo(gitCommitInfo.DirectoryName).Parent;
            Console.WriteLine("Parsing commit message....");
            Console.WriteLine("==========================");
            for (int i = 0; i < commitMessage.Length; i++)
            {
                Console.WriteLine($"{i}: {commitMessage[i]}");
            }
            Console.WriteLine("==========================");

            if (commitMessage.Length < 4)
            {
                Console.WriteLine("Your commit message must be in format");
                Console.WriteLine("Summary");
                Console.WriteLine("Changed:");
                Console.WriteLine("Flaw:");
                Console.WriteLine("Fixed:");
                Environment.Exit(1);
            }
            var parsedCommitMessage = new CommitMessage(commitMessage);

            Console.WriteLine("Finding notes.txt.....");
            string note = Directory.EnumerateFiles(rootDirectory.FullName,
                "notes.txt", SearchOption.AllDirectories).FirstOrDefault();
            if (note == null)
            {
                Console.WriteLine("Could not find notes.txt");
                Environment.Exit(1);
            }

            Console.WriteLine($"Found {note}...");
            var noteHeader = new NotesTxtParser(File.ReadAllText(note));
            int nextNumber = noteHeader.NextNoteNumber;
            Console.WriteLine($"Parsed next step to be Step {nextNumber}.");

            string headerToAppend = $"{new NoteHeader(nextNumber)}{parsedCommitMessage}";
            Console.WriteLine("Appending the following text to notes.txt");
            Console.WriteLine("=========================================");
            Console.WriteLine(headerToAppend);
            Console.WriteLine("=========================================");

            File.AppendAllText(note, headerToAppend);
            Console.WriteLine("Adding notes.txt to commit...");
            Process.Start("git", $"add {note}").WaitForExit();
            Console.WriteLine("Adding notes.txt to commit...");
            File.Delete(".git/HEAD.lock"); // This is the real hack.
            Process.Start("git", "commit --amend --no-verify").WaitForExit();
            Environment.Exit(0);
        }
    }
}
