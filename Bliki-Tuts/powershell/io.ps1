[System.IO]::File.ReadAllText('filename')

$path = [System.IO.Path]::Combine('c:\', 'temp')
if (-not (Test-Path $path)) {
	New-Item -ItemType Directory $path
}

ConvertTo-HTML
ConvertFrom-JSon
Export-CSV


# After download from internet
Unblock-File

Get-Content servers.txt

Split-Path $MyInvocation.PSCommandPath -Leaf