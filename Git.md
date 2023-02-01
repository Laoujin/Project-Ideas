Git
===

dotfiles: if .gitconfig doesn't exist, create it with correct includes


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
