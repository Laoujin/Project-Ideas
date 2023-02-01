PowerShell AD:
Download: https://www.microsoft.com/en-us/download/details.aspx?id=39296

```ps1
Install-Module -Name WindowsCompatibility
Import-Module -Name WindowsCompatibility
Enable-PSRemoting
Import-WinModule -Name ActiveDirectory

Get-ADUser -Filter {Emailaddress -eq 'user@domain.be'}
```
