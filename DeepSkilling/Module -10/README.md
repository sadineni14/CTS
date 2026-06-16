# Version Control Concepts and Git Basics

## Overview

Version Control Systems (VCS) help developers track changes in source code, collaborate efficiently, and maintain a complete history of project modifications. Git is the most widely used distributed version control system.

---

## What is Version Control?

Version Control is a system that records changes to files over time, allowing users to:

* Track modifications
* Collaborate with multiple developers
* Restore previous versions
* Manage project history
* Create and merge branches safely

### Types of Version Control Systems

1. **Local Version Control System**

   * Stores versions on a local machine.

2. **Centralized Version Control System (CVCS)**

   * Uses a central server.
   * Example: SVN.

3. **Distributed Version Control System (DVCS)**

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

### Information Displayed

* Current branch
* Modified files
* Staged files
* Untracked files

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

### Example Output

```text
commit 4f3a9b2
Author: John Doe
Date: Tue Jun 16

Added login functionality
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

# Quick Reference

| Command      | Description                  |
| ------------ | ---------------------------- |
| `git init`   | Initialize a new repository  |
| `git clone`  | Clone an existing repository |
| `git add`    | Stage files for commit       |
| `git commit` | Save changes permanently     |
| `git status` | Check repository status      |
| `git log`    | View commit history          |

---

## Conclusion

Git is a powerful distributed version control system that enables developers to track changes, collaborate effectively, and manage project history. Understanding commands such as `git init`, `git clone`, `git add`, `git commit`, `git status`, and `git log` forms the foundation of Git usage in software development.
