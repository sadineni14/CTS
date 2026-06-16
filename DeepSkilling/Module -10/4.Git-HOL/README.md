# Git HOL 4 - Merge Conflict Resolution

## Objective

* Understand merge conflicts in Git.
* Learn how conflicts occur.
* Resolve conflicts manually.
* Complete a successful merge after conflict resolution.

## Steps Performed

1. Verified master branch status.
2. Created a new branch named `GitWork`.
3. Added `hello.xml` and committed changes in the branch.
4. Switched back to master.
5. Added a different version of `hello.xml`.
6. Committed changes to master.
7. Compared branch differences using `git diff`.
8. Merged `GitWork` into master.
9. Observed Git conflict markers.
10. Resolved the conflict manually.
11. Added the resolved file and committed changes.
12. Updated `.gitignore` to ignore backup files.
13. Deleted the merged branch.
14. Verified merge history using Git log.

## Conflict Example

```xml
<<<<<<< HEAD
Master Version
=======
Branch Version
>>>>>>> GitWork
```

## Resolution

```xml
Master Version
Branch Version
```

## Useful Commands

```bash
git checkout -b GitWork
git add .
git commit -m "message"
git diff master GitWork
git merge GitWork
git status
git log --oneline --graph --decorate --all
git branch -d GitWork
```

## Conclusion

This lab demonstrated how Git detects conflicting changes during a merge and how developers can manually resolve conflicts before completing the merge process.
