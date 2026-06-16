# Git Hands-On Labs (HOL 1 - HOL 5)

## Student Information

**Name:** Jagadish Sadineni
**Repository:** GitDemo
**GitHub Repository:** https://github.com/sadineni14/GitDemo

---

# Introduction

Git is a Distributed Version Control System (DVCS) used to track changes in source code and collaborate with other developers. This document summarizes all five Git Hands-On Labs, including Git basics, Git Ignore, Branching & Merging, Conflict Resolution, and Remote Repository Synchronization.

---

# HOL 1 – Git Basics

## Objective

* Configure Git.
* Create a repository.
* Add files.
* Commit changes.
* Understand Git workflow.

## Commands Used

### Check Git Installation

```bash
git --version
```

### Configure User

```bash
git config --global user.name "Jagadish Sadineni"
git config --global user.email "jagadeeshsadineni5@gmail.com"
```

### Verify Configuration

```bash
git config --global --list
```

### Create Repository

```bash
mkdir GitDemo
cd GitDemo
git init
```

### Create File

```bash
echo "Welcome to version control" > welcome.txt
```

### View File

```cmd
type welcome.txt
```

### Check Status

```bash
git status
```

### Add File

```bash
git add welcome.txt
```

### Commit

```bash
git commit -m "Added welcome file"
```

### View History

```bash
git log --oneline
```

---

## Difficulty Faced

### Issue

```text
'cat' is not recognized as an internal or external command
```

### Cause

The command was executed in Windows Command Prompt instead of Git Bash.

### Resolution

Used:

```cmd
type welcome.txt
```

instead of:

```bash
cat welcome.txt
```

---

# HOL 2 – Git Ignore

## Objective

* Learn `.gitignore`.
* Ignore unwanted files and folders.

## Commands Used

### Create Log File

```bash
echo Test Log > app.log
```

### Create Log Folder

```bash
mkdir log
echo Error Log > log/error.log
```

### Create .gitignore

```text
*.bak
*.log
log/
```

### Check Status

```bash
git status
```

### Commit

```bash
git add .gitignore
git commit -m "Updated gitignore rules"
```

---

## Difficulty Faced

### Issue

```text
app.log
log/
```

still appeared in Git status.

### Cause

`.gitignore` only contained:

```text
*.bak
```

### Resolution

Updated `.gitignore`:

```text
*.bak
*.log
log/
```

Committed the changes.

---

# HOL 3 – Branching and Merging

## Objective

* Create branches.
* Switch branches.
* Merge changes.

## Commands Used

### Create Branch

```bash
git branch GitNewBranch
```

### View Branches

```bash
git branch -a
```

### Switch Branch

```bash
git checkout GitNewBranch
```

### Create File

```bash
echo This file belongs to GitNewBranch > branch.txt
```

### Commit Changes

```bash
git add branch.txt
git commit -m "Added branch file"
```

### Switch Back

```bash
git checkout master
```

### Compare Branches

```bash
git diff master GitNewBranch
```

### Merge Branch

```bash
git merge GitNewBranch
```

### Delete Branch

```bash
git branch -d GitNewBranch
```

### View History

```bash
git log --oneline --graph --decorate
```

---

## Difficulty Faced

No major issues occurred during branch creation and merging.

---

# HOL 4 – Merge Conflict Resolution

## Objective

* Understand merge conflicts.
* Resolve conflicts manually.

## Commands Used

### Create Branch

```bash
git checkout -b GitWork
```

### Create File

```bash
echo Branch Version > hello.xml
```

### Commit

```bash
git add hello.xml
git commit -m "Added hello.xml in GitWork"
```

### Switch to Master

```bash
git checkout master
```

### Create Same File with Different Content

```bash
echo Master Version > hello.xml
```

### Commit

```bash
git add hello.xml
git commit -m "Added hello.xml in master"
```

### Merge

```bash
git merge GitWork
```

---

## Conflict Observed

```xml
<<<<<<< HEAD
Master Version
=======
Branch Version
>>>>>>> GitWork
```

### Resolution

Updated content manually:

```xml
Master Version
Branch Version
```

Completed merge:

```bash
git add hello.xml
git commit -m "Resolved merge conflict"
```

---

## Difficulty Faced

### Issue

Merge conflict in `hello.xml`.

### Cause

Both master and branch modified the same file differently.

### Resolution

Manually edited the file and committed the resolved version.

---

# HOL 5 – Clean Up and Push to Remote Repository

## Objective

* Connect local repository to GitHub.
* Push all commits.
* Synchronize local and remote repositories.

## Commands Used

### Check Branch

```bash
git branch
```

### Verify Remote

```bash
git remote -v
```

### Add Remote

```bash
git remote add origin https://github.com/sadineni14/GitDemo.git
```

### Verify Remote

```bash
git remote -v
```

### Push Repository

```bash
git push -u origin master
```

### Verify

```bash
git push -u origin master
```

Output:

```text
Everything up-to-date
```

---

## Difficulty Faced

### Issue

No remote repository was configured.

### Cause

Git repository was only local.

### Resolution

Created GitHub repository and added remote:

```bash
git remote add origin https://github.com/sadineni14/GitDemo.git
```

Successfully pushed all commits.

---

# Overall Learning Outcomes

Through these Hands-On Labs, the following Git concepts were learned:

* Git Configuration
* Repository Creation
* Staging Area
* Commit History
* Git Ignore
* Branching
* Merging
* Merge Conflict Resolution
* Remote Repository Management
* GitHub Integration
* Push and Pull Operations

---

# Conclusion

The Git Hands-On Labs provided practical experience with version control using Git. The exercises covered repository management, file tracking, branching, conflict resolution, and remote repository synchronization. All tasks were successfully completed, and the local repository was connected to GitHub for version control and collaboration.
