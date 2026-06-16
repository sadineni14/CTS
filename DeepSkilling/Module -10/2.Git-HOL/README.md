# Git HOL 2 - Using .gitignore

## Objective

* Understand the purpose of `.gitignore`.
* Learn how to ignore unwanted files and folders in Git.
* Prevent temporary and log files from being tracked by the repository.

---

## Prerequisites

* Git installed and configured.
* Local Git repository available.
* GitHub/GitLab account (optional for remote operations).
* Basic knowledge of Git commands.

---

## Introduction

The `.gitignore` file is used to specify files and directories that Git should ignore. Ignored files are not tracked by Git and do not appear in staging operations.

Common examples include:

* Log files (`*.log`)
* Temporary files
* Cache files
* Build directories
* Environment configuration files

---

## Step 1: Create Log File

Create a log file in the repository.

```bash id="jlwmh7"
echo Test Log > app.log
```

---

## Step 2: Create Log Directory

Create a folder named `log`.

```bash id="w0mj0q"
mkdir log
```

Create a log file inside the folder.

```bash id="67h3r5"
echo Error Log > log/error.log
```

---

## Step 3: Create .gitignore File

Create and open `.gitignore`.

```bash id="mjlwmq"
notepad .gitignore
```

Add the following entries:

```text id="5vhzdu"
*.log
log/
```

### Explanation

| Entry   | Description                            |
| ------- | -------------------------------------- |
| `*.log` | Ignore all files with `.log` extension |
| `log/`  | Ignore the entire `log` directory      |

Save and close the file.

---

## Step 4: Verify Git Ignore

Check repository status.

```bash id="jku24j"
git status
```

Expected output:

```text id="l5f9c8"
On branch master

Untracked files:
    .gitignore

nothing added to commit but untracked files present
```

The following items should NOT appear:

* app.log
* error.log
* log folder

This confirms that Git is ignoring them successfully.

---

## Step 5: Add .gitignore to Repository

```bash id="0n7vv8"
git add .gitignore
```

Commit the changes:

```bash id="r12y5i"
git commit -m "Added gitignore file"
```

---

## Step 6: Verify Repository Status

```bash id="zj87bz"
git status
```

Expected output:

```text id="2j8svh"
On branch master
nothing to commit, working tree clean
```

---

## Benefits of .gitignore

* Keeps repositories clean.
* Prevents unnecessary files from being committed.
* Reduces repository size.
* Improves project organization.
* Protects sensitive and temporary files.

---

## Common .gitignore Examples

```text id="7mty4e"
*.log
*.tmp
*.cache
node_modules/
bin/
build/
dist/
```

---

## Conclusion

In this Hands-On Lab, `.gitignore` was used to prevent Git from tracking log files and log directories. The repository successfully ignored `*.log` files and the `log/` folder, demonstrating how Git can manage unwanted files effectively.

