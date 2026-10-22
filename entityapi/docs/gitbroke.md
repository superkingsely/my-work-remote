rm -f .git/refs/remotes/origin/main
git pack-refs --all
git fetch origin


git status
git show-ref


Step 2: Remove the corrupted reference
Run these commands one at a time:
rm -f "$(git rev-parse --git-path refs/remotes/origin/main)"


Then remove its local reflog if present:
rm -f "$(git rev-parse --git-path logs/refs/remotes/origin/main)"

git fetch --prune origin