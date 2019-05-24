dotfiles
========

Desired State configuration  
https://gallery.technet.microsoft.com/scriptcenter/DSC-Resource-Kit-All-c449312d


PowerShell Scripts:
How the hell are the functions called for "Find-EnvironmentVariables",  what are the aliases
and which functions are available?
--> Add a -Help or something per module for more discoverability?
--> Perhaps need to be put into modules after all so that we can make use of the builtin powershell mecanism?
--> Printing some usage/availability instructions to the console quickly is recommended

Add some sort of automated docs for ps functions?


Install-PS-Modules needs to be converted to official registry

Add new module: Install-VSExtension

Shortcuts to Add to visual studio:
- toggle bottom/right panes -> just use ctrl alt enter?




## Doing manually...

### Windows Explorer Context Menus

https://stackoverflow.com/questions/20449316/how-add-context-menu-item-to-windows-explorer-for-folders

UIs: https://www.nirsoft.net/utils/shell_menu_view.html

Registry:  
- HKEY_CLASSES_ROOT\*\shell
- HKEY_CLASSES_ROOT\*\shellex\ContextMenuHandlers
- HKEY_CLASSES_ROOT\AllFileSystemObjects\ShellEx
- HKEY_CLASSES_ROOT\Directory\shell
- HKEY_CLASSES_ROOT\Directory\shellex\ContextMenuHandlers

**Foxit Reader**  
Remove from context menu.
```
regsvr32 /u "C:\Program Files (x86)\Foxit Software\Foxit Reader\plugins\ConvertToPDFShellExtension_x64.dll"
```

**7zip**  
In program Extra > Options > 7-zip


## Initial bootstrap troubles

Says "Symlink already exists" while it should: rename the existing file, create symlink  
ie: check if symlink already exists or that destination file already exists  
“The system cannot find the path specified” à Provide context: which link were we trying to create  
Check if the file, if it already exists, is really a symlink à if not: rename existing and create link + inform user  

- bootstrap args: call with only executing a certain program
- Split config from source
