# Cmder
ConEmuC -GuiMacro Rename 0 "WtmApp"
http://conemu.github.io/en/GuiMacro.html

& .\scriptName.exe # invoke operator

cd c:\Program` Files
cd "c:\Program Files"
Push-Location ~ # home
Pop-Location

## Open Windows Explorer (in current path)
ii .

## Input-Output
[int]$number = Read-Host "enter a number"
[single], [double], [string], [char], [xml], [adsi] # Active Directory Service Interface

Write-Host $number -Fore yellow -Back Magenta
Write-Verbose # for tracing, ... Also Write-Debug, Write-Error, Write-Warning
# $VerbosePreference, $DebugPreference: "Continue" (do output), "SilentlyContinue" (supress)
Write-Output
pause

# Any key (to exit?)
$host.UI.RawUI.ReadKey()

### PsReadLine
Install-Module PsReadLine
# start typing + up = startsWith filter

# start search in history
Ctrl + R
# or use F7 to open a history grid

# PossibleCompletions
[PsConsoleUtilities.PSConsoleReadLine]::
Ctrl + Space

# ATTN: Windows 10 includes PSConsoleReadLine and moved it to namespace Microsoft.PowerShell

# See all KeyHandlers
[PsConsoleUtilities.PSConsoleReadLine]::GetKeyHandlers($true, $false)

# See all keyhandlers
Ctrl + Alt + Oem2

# Update - didn't work?
cmd
powershell -noprofile
Update-Module PSReadLine

# Configure
Get-PSReadlineKeyHandler
Set-PSReadlineKeyHandler -Key Tab -Function "Complete"



### Jump.Location
Install-Module Jump.Location
jumpstat
jumpstat -scan . # Add all subdirs
j loc
j - # = popd = Pop-Location