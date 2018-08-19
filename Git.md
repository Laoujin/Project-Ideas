Git
===

Many a interesting snippet:  
https://github.com/git-tips/tips


dotfiles: if .gitconfig doesn't exist, create it with correct includes

Aliases
-------
```
git add 0 --> add the first file from git status
git status-0 --> get the filename of the first file in git status
--> then add these shortcuts for multiple commands?

git diff SOME_FILE
git add “whatever file was selected in the previous command”
git add 0
=== git add the first file of git status (take into account that files might already have been staged)


Shortcuts for interfacing with GitHub:
https://hub.github.com/
git pr -> pull-request = git po + check out the pull-request url + start url - check ruby gem for stash pull requests

wipe = !git add -A && git commit -qm 'WIPE SAVEPOINT' && git reset HEAD~1 --hard
http://haacked.com/archive/2014/07/28/github-flow-aliases/

On undoing, fixing, or removing commits in git‏:
https://sethrobertson.github.io/GitFixUm/fixup.html

For more interesting aliases:
Git Bash/cygwin: https://github.com/tj/git-extras/blob/master/Commands.md
Check out these: https://gist.github.com/robmiller/6018582
https://git.wiki.kernel.org/index.php/Aliases

Checkout ours/theirs
http://stackoverflow.com/a/11843922/540352

https://github.com/AlexZeitler/posh-git-alias
```


Config
------
```
[difftool "vs"]
cmd = 'C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Enterprise\\Common7\\IDE\\CommonExtensions\\Microsoft\\TeamFoundation\\Team Explorer\\vsdiffmerge.exe' $LOCAL $REMOTE Source Target //t
```


Clone And Enter
---------------
```
# TODO: clone & enter attempt x?
# clone and enter directory
# --> use powershell function for this
#ce = "!f() { git clone $1 $2; cd $2; }; f"
#ce = "!f() { Invoke-GitClone $1 $2; }; f"

#http://stackoverflow.com/questions/32539250/how-to-do-a-git-clone-and-enter-the-created-directory/32539370#32539370
# function Invoke-GitClone($url) {
#   $name = $url.Split('/')[-1].Replace('.git', '')
#   & git clone $url $name | Out-Null
#   cd $name
# }
# -> Doesn't work...
```
