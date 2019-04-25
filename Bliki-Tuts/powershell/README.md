PowerShell
==========
TODO: learnxinyminutes or own article-series like this?


Set-ExecutionPolicy
help about_Execution_Policies

Providers
---------
`Get-PSProvider`  
**Capabilities**:  
ShouldProcess: Supports `-WhatIf` and `Confirm` parameters  
Filter: SUpports `-Filter`  
Credentials  
Transactions

powershell.exe -NoExit -Command Import-Module ActiveDirectory  
Get-PSSnapin -Registered  
Add-PSSnapin xxx

`Get-PSDrive` 
PSDrive can use many: `Get-Command -Noun *item*`  
Items: ex Folders and Files for the FileSystem provider  
Item Properties: ex Creation date, ...  

**Changing PSProvider**:  
```
Set-Location -Path HKCU: # HKEY_CURRENT_USER
# cd HKLM: # HKEY_LOCAL_MACHINE
Set-Location ./Software/Microsoft/Windows
Set-ItemProperty -Path dwm -PSProperty EnableAeroPeek -Value 0
```

Pipeline
--------
ByValue and ByPropertyName
```
Get-Process | Out-Default # Default formatter and default Out-
Get-Process | Out-Host # Send to environment
Get-Process | Out-Null # Do nothing
Get-Process | Out-GridView # GUI grid
Get-Process | Out-File filename.txt # Out-Printer
Get-Process | Export-CSV filename.txt
Get-Process | ConvertTo-HTML | Out-File filename.txt
Get-Process -Name Notepad | Stop-Process -WhatIf

Get-Process | Select-Object -First 10 | Sort-Object -Property VM,ID -Descending | Select-Object Name,ID,VM
```

ps | ForEach-Object {$_.Name}
"a","b","c" | Foreach-Object `
	-Begin { "Starting"; $counter = 0 } `
	-Process { "Processing $_"; $counter++ } `
	-End { "Finishing: $counter" }

Specific Shells
---------------
Export-Console myshell.psc
powershell.exe -NoExit -PSConsoleFile myshell.psc

Formatting
----------
ps | select -fi 10 | format-table -prop ID,NAme,Responding -autoSize
Also: Format-List, Format-Wide -Col 4

Filtering
---------
-eq, -ne, -lt, -gt, -not  
-ceq # case-sensitive equals
-like # use wildcards *. -notlike, -cnotlike
-contains # list filtering

'input' -match '^input$'
'input','other' | Select-String -Pattern 'in'
ps | Select-Object -ExpandProperty Name | Select-String -Pattern 'win(?!init)'

Get-Date -lt '2012-10-05'

ps | Where-Object {$_.Status -eq 'Running'}
ps | ? {$_.Status -eq 'Running'}
ps | Measure-Object -prop VM -sum -average -max -min
ps | Group-Object Name

.NET Framework
--------------
'string'.ToUpper().Replace('G', 'ggg')
[void][System.Reflection.Assembly]::LoadWithPartialName('Microsoft.VisualBasic')

$writer = New-Object System.IO.StreamWriter($path, $true)
$writer.Write([Environment]::NewLine)

Remoting
--------
Enter-PSSession -computerName Server1
Exit-PSSession

Invoke-Command -computerName Server1 -command { Get-EventLog Security -newest 100 }

Variables
---------
$emptyValue = $NULL
$aNumber = 5 -as [double]
$aBoolean = $true -and $aNumber -is [DateTime]
$aString = "amount: $aNumber`nThis on a new line with `$ sign" # Use '' for strings without variable interpolation
$stringConcat = 'str1' + 'str2'
# Use ` for line continuations. Or enter after a |
# Also `t
# Also see: help about_Escape

Lists:  
Get-EventLog Security -ComputerName Server1,Server2  
Get-EventLog Security -ComputerName (Get-Content servers.txt) # file where each line is one ComputerName

$servers = 'Server1','Server2'
"first server: $($servers[0] -replace '1','x')"
$servers -join '|' # -split

Objects:  
ps | select -first 10 | Format-Table ID,Name,@{n='VM(MB)';e={'{0:n2}' -f ($_.VM / 1MB)}} -autoSize  
@{name='label';expression={$_}}

$o = New-Object System.Management.Automation.PSObject
$o | Add-Member -Value 'Notepad' -Name 'Name' -MemberType NoteProperty

$var = @{ID=1; Name='MyName'; LastLogon=Get-Date}

Control Flow
------------
if (5 -eq 3) {}
elseif (5 -eq 4) {}
else {}

$temperature = 20
switch($temperature) {
  { $_ -lt 32 }   { "Below Freezing"; break }
  32              { "Exactly Freezing"; break }
  { $_ -le 50 }   { "Cold"; break }
  { $_ -le 70 }   { "Warm"; break }
  default         { "Hot" }
}

for($i = 1; $i -le 10; $i++) {
  "Loop number $i"
}
1..10 | % { "Loop number $_" }

foreach ($var in $collection) {}
while () {}
do {} while ()
do {} until ()

# No conditional, but fake it with: 
$result = if(Get-Process -Name notepad) { "Running" } else { "Not running" }

try {} catch {} finally {}
try {} catch [System.NullReferenceException] {
	echo $_.Exception | Format-List -Force
}
