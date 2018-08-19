Synology
--------

- reset the crazy vim bindings (or perhaps just stick to vi?)
- .bashrc file etc should be in synology repo -> check how .dotfiles do it, symlinks?
- better prompt: ctrl+arrows don't work; multiline copy-pasting doesn't work,
- bash: search in history (also refresh what is it in ConEmu?)


# DokuWiki

Might need to move Tuts to there...?

TODO: Should move DokuWiki under source control  
https://github.com/istepanov/docker-dokuwiki  
```
docker run --rm --volumes-from dokuwiki -v $(pwd):/backup ubuntu tar zcvf /backup/dokuwiki-backup.tar.gz /var/dokuwiki-storage
```
