Find all: "set" in cmd

`help set` for other cmd variables

Examples:
%USERPROFILE% -> C:\Users\Wouter\
%APPDATA% -> C:\Users\Wouter\AppData\Roaming
%USERNAME% -> Wouter
...

diskpart
--------
Administrative prompt: diskpart

Create bootable disk:
```
list disk
select disk X
clean
create part pri
select part 1
format fs=fat32
active
exit
```