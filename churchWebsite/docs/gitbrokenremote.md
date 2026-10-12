
1
USER@superkingselyPC MINGW64 ~/Desktop/my-work-remote/churchWebsite (main)
$ rm -f "$(git rev-parse --git-path refs/remotes/origin/main)"
2
USER@superkingselyPC MINGW64 ~/Desktop/my-work-remote/churchWebsite (main)
$ git fetch origin
From https://github.com/superkingsely/my-work-remote
 * [new branch]      main       -> origin/main
3
 git branch --set-upstream-to=origin/main main
 4
 Then verify:
git branch -vv
git status -sb