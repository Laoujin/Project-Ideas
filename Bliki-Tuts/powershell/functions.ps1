PowerShell Functions & Scripts
==============================
Paramaterized script:
---------------------
param (
	$computerName = 'Server1'
)
. .\includeScript.ps1
Write-Host $computerName

# Call with
.\scriptName.ps1 -computerName Server2
.\scriptName.ps1 Server2


Full Script
-----------
<#
.SYNOPSIS
Blah blah
.DESCRIPTION
Desc
.PARAMETER ComputerName
Da name
.EXAMPLE
Get-Stuff -ComputerName DaServer
#>
[CmdletBinding()] # Attribute to add capabilities like -WhatIf, -Confirm
param(
	[Parameter(Mandatory=$True)]
	[Alias('cn')]
	[string]$ComputerName,
	[ValidateSet(1,2,3)]
	[int]$Times = 3,
	[switch]$Confirm = $False
)

Functions
---------
function New-Website {}
function New-Website([string]name, [int]port) {}
function New-Website() {
	[CmdletBinding()]
	param (
		[Parameter(ValueFromPipeline=$true, Mandatory=$true)]
		[string]$name
	)
}