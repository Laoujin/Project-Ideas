Synology
--------

- reset the crazy vim bindings (or perhaps just stick to vi?)
- .bashrc file etc should be in synology repo -> check how .dotfiles do it, symlinks?
- better prompt: ctrl+arrows don't work; multiline copy-pasting doesn't work,
- bash: search in history (also refresh what is it in ConEmu?)


.dotfiles  
```
clear

source ~/bash_aliases.sh

PS1='\n\[\033[33m\]\w$(__git_ps1)\n\[\033[1;33m\]$\[\033[0m\] '

alias ..="cd .."
alias ...="cd ../.."
alias ....="cd ../../.."
alias .....="cd ../../../.."
alias ......="cd ../../../../.."
alias ..2="cd ../.."
alias ..3="cd ../../.."
alias ..4="cd ../../../.."
alias ..5="cd ../../../../.."

alias mike="cd /c/code/Autohotkey/Mi-Ke"
```


# DokuWiki

https://github.com/istepanov/docker-dokuwiki  
```
docker run --rm --volumes-from dokuwiki -v $(pwd):/backup ubuntu tar zcvf /backup/dokuwiki-backup.tar.gz /var/dokuwiki-storage
```
