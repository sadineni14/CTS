# Git and Version Control Guide

## Overview

Version Control Systems (VCS) help developers track changes in source code, collaborate efficiently, and maintain a complete history of project modifications. Git is the most widely used distributed version control system and is a fundamental tool in modern software development.

---

# What is Version Control?

Version Control is a system that records changes to files over time, allowing users to:

* Track modifications
* Collaborate with multiple developers
* Restore previous versions
* Manage project history
* Create and merge branches safely

## Types of Version Control Systems

### 1. Local Version Control System

* Stores versions on a local machine.

### 2. Centralized Version Control System (CVCS)

* Uses a central server.
* Example: SVN.

### 3. Distributed Version Control System (DVCS)

* Every developer has a complete copy of the repository.
* Example: Git.

---

# Git Basics

## 1. Git Initialization (`git init`)

Creates a new Git repository in the current directory.

### Command

```bash
git init
```

### Example

```bash
mkdir MyProject
cd MyProject
git init
```

### Output

```text
Initialized empty Git repository in MyProject/.git/
```

---

## 2. Cloning a Repository (`git clone`)

Creates a local copy of an existing remote repository.

### Command

```bash
git clone <repository-url>
```

### Example

```bash
git clone https://github.com/username/project.git
```

---

## 3. Adding Files (`git add`)

Moves files to the staging area before committing.

### Add a Specific File

```bash
git add file.txt
```

### Add All Files

```bash
git add .
```

---

## 4. Committing Changes (`git commit`)

Records staged changes into the repository history.

### Command

```bash
git commit -m "Commit message"
```

### Example

```bash
git commit -m "Added login feature"
```

---

## 5. Checking Repository Status (`git status`)

Displays the current state of the repository.

### Command

```bash
git status
```

### Example Output

```text
On branch main
Changes to be committed:
    modified: app.py
```

---

## 6. Viewing Commit History (`git log`)

Shows the history of commits.

### Command

```bash
git log
```

### Compact Version

```bash
git log --oneline
```

### Example Output

```text
4f3a9b2 Added login functionality
2a1c7d8 Initial commit
```

---

# Basic Git Workflow

```bash
git init
git status
git add .
git commit -m "Initial commit"
git log --oneline
```

## Workflow Diagram

```text
Working Directory
       |
       | git add
       v
Staging Area
       |
       | git commit
       v
Git Repository
```

---

# Branching in Git

A branch is an independent line of development within a repository.

## Why Use Branches?

* Develop features independently
* Fix bugs without affecting production code
* Experiment safely
* Enable team collaboration

### View Existing Branches

```bash
git branch
```

### Create a New Branch

```bash
git branch feature-login
```

### Switch to a Branch

```bash
git checkout feature-login
```

or

```bash
git switch feature-login
```

### Create and Switch in One Command

```bash
git checkout -b feature-login
```

or

```bash
git switch -c feature-login
```

---

# Merging Branches

Merging combines changes from one branch into another.

### Example

```bash
git checkout main
git merge feature-login
```

Git automatically combines changes when possible.

---

# Merge Conflicts

A merge conflict occurs when Git cannot automatically determine which changes should be kept.

### Example Conflict

```text
<<<<<<< HEAD
Welcome User
=======
Welcome Guest
>>>>>>> feature-login
```

### Resolving Conflicts

1. Open the conflicted file.
2. Choose the correct content.
3. Remove conflict markers.
4. Save the file.
5. Stage the file:

```bash
git add filename
```

6. Complete the merge:

```bash
git commit
```

---

# Merge Strategies

## Fast-Forward Merge

Occurs when the target branch has no additional commits.

```bash
git merge feature-login
```

### Advantages

* Clean history
* Simple workflow

---

## Three-Way Merge

Used when both branches contain unique commits.

```bash
git merge feature-login
```

### Advantages

* Preserves development history
* Shows integration points clearly

---

## Squash Merge

Combines multiple commits into a single commit.

```bash
git merge --squash feature-login
```

### Advantages

* Cleaner commit history
* Easier maintenance

---

# Remote Repositories

A remote repository is a version of your project hosted on services such as GitHub, GitLab, or Bitbucket.

### View Remote Repositories

```bash
git remote -v
```

### Add a Remote Repository

```bash
git remote add origin https://github.com/username/project.git
```

---

# Git Push

Uploads local commits to a remote repository.

### Push Changes

```bash
git push origin main
```

### Push a New Branch

```bash
git push origin feature-login
```

---

# Git Pull

Downloads and integrates changes from a remote repository.

### Pull Latest Changes

```bash
git pull origin main
```

### Pull Workflow

```bash
git pull
```

Equivalent to:

```bash
git fetch
git merge
```

---

# Forking a Repository

A fork is a personal copy of another user's repository.

## Benefits

* Contribute to open-source projects
* Experiment without affecting the original repository
* Maintain independent changes

### Fork Workflow

1. Fork the repository on GitHub.
2. Clone your fork.

```bash
git clone https://github.com/yourusername/project.git
```

3. Create a branch.
4. Make changes.
5. Commit and push changes.

---

# Pull Requests (PRs)

A Pull Request is a request to merge changes from one branch into another.

## Purpose

* Code review
* Team collaboration
* Automated testing
* Quality assurance

### Pull Request Workflow

1. Fork the repository.
2. Create a feature branch.
3. Make changes.
4. Commit changes.
5. Push changes.

```bash
git push origin feature-login
```

6. Open a Pull Request.
7. Review and discuss changes.
8. Merge after approval.

---

# Example Collaboration Workflow

```bash
git clone repository-url

git checkout -b feature-login

# Make changes

git add .
git commit -m "Added login functionality"

git push origin feature-login
```

Create a Pull Request and request a review.

---

# Quick Reference

| Command         | Description                     |
| --------------- | ------------------------------- |
| `git init`      | Initialize a new repository     |
| `git clone`     | Clone an existing repository    |
| `git add`       | Stage files for commit          |
| `git commit`    | Save changes permanently        |
| `git status`    | Check repository status         |
| `git log`       | View commit history             |
| `git branch`    | List branches                   |
| `git checkout`  | Switch branches                 |
| `git merge`     | Merge branches                  |
| `git remote -v` | View remote repositories        |
| `git push`      | Upload changes                  |
| `git pull`      | Download changes                |
| Fork            | Create personal repository copy |
| Pull Request    | Request code review and merge   |

---

# Conclusion

Git is a powerful distributed version control system that enables developers to track changes, collaborate effectively, manage project history, work with branches, resolve conflicts, and contribute through forks and pull requests. Mastering these concepts is essential for modern software development and team collaboration.
