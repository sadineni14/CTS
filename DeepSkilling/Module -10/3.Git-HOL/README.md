# Git HOL 3 - Branching and Merging

## Objective

* Understand Git branching and merging.
* Create and switch between branches.
* Compare differences between branches.
* Merge a branch into the master branch.
* Delete a branch after successful merging.

---

## Introduction

Git branches allow developers to work independently on features, bug fixes, and experiments without affecting the main codebase. Once changes are completed, branches can be merged back into the main branch.

---

## Creating a Branch

Create a new branch:

```bash
git branch GitNewBranch
```

List available branches:

```bash
git branch -a
```

The `*` symbol indicates the current branch.

---

## Switching Branches

Switch to the new branch:

```bash
git checkout GitNewBranch
```

Verify the current branch:

```bash
git branch
```

---

## Making Changes

Create a file:

```bash
echo This file belongs to GitNewBranch > branch.txt
```

Stage and commit:

```bash
git add branch.txt
git commit -m "Added branch file"
```

Check status:

```bash
git status
```

---

## Comparing Branches

Switch back to master:

```bash
git checkout master
```

View differences:

```bash
git diff master GitNewBranch
```

---

## Merging Branches

Merge the source branch:

```bash
git merge GitNewBranch
```

Git combines changes from the branch into the master branch.

---

## Viewing History

Display commit history:

```bash
git log --oneline --graph --decorate
```

This shows the branch structure and merge history.

---

## Deleting a Branch

Delete the merged branch:

```bash
git branch -d GitNewBranch
```

Verify:

```bash
git branch
```

---

## Benefits of Branching

* Isolates development work.
* Prevents accidental changes to the main branch.
* Enables parallel development.
* Supports team collaboration.

---

## Conclusion

This Hands-On Lab demonstrated Git branching and merging operations. A new branch was created, modified, committed, compared, merged into master, and finally deleted after successful integration.
