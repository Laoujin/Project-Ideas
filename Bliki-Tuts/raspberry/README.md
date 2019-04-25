Raspberry playground
====================
Hostnames:  
rasp-you-know

Default login: pi / raspberry

ssh rasp-you-know -l pi  
ssh 192.168.1.41 -l pi

http://x.cygwin.com/docs/ug/using-remote-apps.html

HDMI Settings etc: `/boot/config.txt`

sudo raspi-config
-----------------
Boot options, set hostname, change pi password

Start GUI: sudo startx  
Allow XServer:  
/etc/X11/Xwrapper.config  
allowed_users= root / anybody / console

Stop GUI: sudo raspi-config

Wifi
----
Your IP: sudo ifconfig
Scan: sudo iwlist wlan0 scan

sudo nano /etc/network/interfaces
```
auto lo
iface lo inet loopback
iface eth0 inet dhcp

auto wlan0
allow-hotplug wlan0
iface wlan0 inet dhcp
    wpa-ssid "PwdIs_12345678"
    wpa-psk "12345678"
```


sudo nano /etc/wpa_supplicant/wpa_supplicant.conf # old?

sudo ifdown wlan0
sudo ifup -a


sensor
------
https://learn.adafruit.com/adafruits-raspberry-pi-lesson-11-ds18b20-temperature-sensing/overview

/boot/config.txt  
Enable: dtoverlay=w1-gpio

Test:  

```
sudo modprobe w1-gpio  
sudo modprobe w1-therm  
cd /sys/bus/w1/devices  
ls  
cd 28-xxxx (change this to match what serial number pops up)  
cat w1_slave
```

git-credential-winstore
-----------------------
sudo apt-get install libgnome-keyring-dev  
cd /usr/share/doc/git/contrib/credential/gnome-keyring  
sudo make  
git config --global credential.helper /usr/share/doc/git/contrib/credential/gnome-keyring/git-credential-gnome-keyring


git config --global credential.helper "cache --timeout=3600"