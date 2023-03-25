Project Ideas
=============

I guess we need to start getting rid of this repository...
Doing it, or moving it to a more relevant place...




- C# Pipelines
- PowerShell: Find out what process is locking a file

```ps1
# Uses handle.exe... Native solution?
function Find-LockedFileProcess {     param(         [Parameter(Mandatory)]         [string]$FileName,         [Parameter()]         [string]$HandleFilePath = 'C:\Handle\handle.exe'     )     $splitter = '------------------------------------------------------------------------------'     $handleProcess = ((& $HandleFilePath) -join "`n") -split $splitter | Where-Object {$_ -match [regex]::Escape($FileName) }     (($handleProcess -split "`n")[2] -split ' ')[0] }
```

OneNote migration
-----------------
http://www.codinghorror.com/blog/2005/05/welcome-to-the-tribe.html
Paul Graham: http://www.paulgraham.com/articles.html
Eric Raymond: http://www.catb.org/~esr/writings/

big O explained: http://stackoverflow.com/questions/487258/plain-english-explanation-of-big-o

http://lifehacker.com/5965536/how-do-i-pitch-an-idea-that-actually-gets-heard

DZone Cheat Sheets:
https://dzone.com/refcardz




Things to do
------------

Some random stuff:  

- Jenkins: have a gem check all urls for 404s?
- licenser issues + easier update of many projects?


### Check software

- NimbleText


pongit.be
Speel pong (multiplayer?)
Pong thais bord met IT in mspaint?


TODO
====
need to check my list of starred repos...
--> master the command lint
--> git tips & hints
--> free developer books
--> lots of interesting stuff....


Pomperom
========
Series te checken:
Jordskott

Time travel movies:
The thirtheenth floor
Jacobs ladder
Stay

Weird movies?
Pinokio 946


# Megalomania

Like mega big projects that won't ever be done probably:  

- A WPF app to edit registry, environment variables, ..
- International Phonetic Alphabet (IPA)


## How does a computer work

http://cs.stackexchange.com/questions/3390/how-does-a-computer-work
http://softwareengineering.stackexchange.com/questions/81624/how-do-computers-work
https://www.youtube.com/watch?v=IlPj5Rg1y2w
