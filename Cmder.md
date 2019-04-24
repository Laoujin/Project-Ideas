# Cmder


Move dotfiles\prompt_readline to separate files...


Shortcut to move the splitter more than one

F7 Command history window: Out-GridView doesn't work
--> It's not in PowerShell Core...

.. dir\bla
--> 1 terug en dan naar dir\bla -> met


Ctrl+Shift+j to mark the current directory
Ctrl+j will change back to that directory

## PSReadLine

implement Ctrl+Z after Ctrl+V‏
Update PSReadLine to latest version



## PowerShell JumpLocation


Shortcut to go back to previous path?

I've got installed:  
https://github.com/tkellogg/Jump-Location

Don't just take the amount of time spent on a filesystem location but also:  
- long amounts of time without any command... don't count
- more recent events are more important
- command to easily delete directories with a grep
- move no longer existing directories to an archive
- don't automatically store root directories
- direct shortcut for d:\ h:\ ... ctrl+alt+win+d ?
- favorite locations
- blacklist locations


## Mklink

```powershell
function mklink { cmd /c mklink $args }
{ cmd /c mklink /D "toDir" fromDir }
/H for a hard link
```

Native PowerShell wrapper for MKLINK:  
https://gist.github.com/jpoehls/2891103
