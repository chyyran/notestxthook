# notes.txt.hook

If you're here, you know what this is for.

## Getting Started
You need the [.NET Core SDK 2.1.4](https://www.microsoft.com/net/download/) and `git` in your path. 

You should probably build it from scratch, but if not copy `hooks` into your `.git` folder, and make sure you don't have any existing `commit-msg` and `post-commit` hooks.

**Your commit messages must be in the following format**
```
A summary
Changed: [Put stuff for 'Code affected']
Flaw: [Put stuff for 'Flaw']
Fixed: [Put stuff for 'Fixed']
```

If it is not in this format, the hook will prevent you from committing.

## How it works

`git` has "hooks" that let you extend its behavior. `commit-msg` is called when you make a commit, with the argument being the message you made.

If the message is in that format, I parse the message, append it in the proper format to `notes.txt`, then flags the `post-commit` hook to amend the commit with the new `notes.txt`.

## Why is it in C#
**Because this is a dirty hack and hell if I'm going to work in another language I have to learn about.** 

## Disclaimer
This is a hack done in an hour. If it wipes your entire repository... **well don't push anything until you're sure the `git log` checks out.**