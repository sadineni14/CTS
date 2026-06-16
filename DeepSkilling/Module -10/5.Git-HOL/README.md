# Git HOL 5 - Clean Up and Push to Remote Repository

## Objective

* Verify repository status before synchronization.
* Pull the latest changes from the remote repository.
* Push local changes to the remote repository.
* Ensure local and remote repositories remain synchronized.

---

## Prerequisites

* Git installed and configured.
* Local repository available.
* Remote repository created on GitHub/GitLab.
* Previous Git HOL exercises completed.

---

## Step 1: Verify Repository Status

Check whether the repository is in a clean state.

```bash
git status
```

Expected Output:

```text
On branch master
nothing to commit, working tree clean
```

---

## Step 2: List Available Branches

Display all local branches.

```bash
git branch
```

Example Output:

```text
* master
```

---

## Step 3: Verify Remote Repository

Display configured remote repositories.

```bash
git remote -v
```

Example Output:

```text
origin  https://github.com/username/GitDemo.git (fetch)
origin  https://github.com/username/GitDemo.git (push)
```

---

## Step 4: Add Remote Repository

If no remote repository is configured:

```bash
git remote add origin https://github.com/username/GitDemo.git
```

Verify configuration:

```bash
git remote -v
```

---

## Step 5: Pull Latest Changes

Download and merge changes from the remote repository.

```bash
git pull origin master
```

or

```bash
git pull origin main
```

---

## Step 6: Push Local Changes

Upload local commits to the remote repository.

```bash
git push -u origin master
```

Example Output:

```text
[new branch] master -> master
branch 'master' set up to track 'origin/master'
```

Subsequent pushes:

```text
Everything up-to-date
```

---

## Step 7: Verify Remote Repository

Open the GitHub/GitLab repository and verify:

* Files are uploaded successfully.
* Commit history is available.
* Latest changes are reflected.

---

## Commands Used

| Command                 | Description                 |
| ----------------------- | --------------------------- |
| `git status`            | Check repository status     |
| `git branch`            | List branches               |
| `git remote -v`         | Display remote repositories |
| `git remote add origin` | Add remote repository       |
| `git pull`              | Download latest changes     |
| `git push`              | Upload local commits        |

---

## Result

The local repository was successfully connected to the remote GitHub repository. All commits were pushed successfully, and the local branch was configured to track the remote branch.

---

## Conclusion

This Hands-On Lab demonstrated repository cleanup, remote repository configuration, pulling updates from a remote repository, and pushing local changes to GitHub. These operations ensure synchronization between local and remote repositories and complete the Git workflow.
