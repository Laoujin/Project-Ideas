dotfiles
========

Desired State configuration  
https://gallery.technet.microsoft.com/scriptcenter/DSC-Resource-Kit-All-c449312d


Add some sort of automated docs for ps functions?


Install-PS-Modules needs to be converted to official registry



Check out: https://github.com/jayharris/dotfiles-windows


### Code

Says "Symlink already exists" while it should: rename the existing file, create symlink  
ie: check if symlink already exists or that destination file already exists  
“The system cannot find the path specified” à Provide context: which link were we trying to create  
Check if the file, if it already exists, is really a symlink à if not: rename existing and create link + inform user  

- bootstrap args: call with only executing a certain program
- Split config from source
