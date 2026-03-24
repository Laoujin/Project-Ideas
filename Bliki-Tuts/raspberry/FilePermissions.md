Synology blog posts:
- FilePermissions
- Https, Traefik, custom domain names (heimdall, pi-hole, portainer)
- VPN




file permissions linux

https://www.linux.com/learn/understanding-linux-file-permissions
chmod 644 /etc/sudoers
-rw-r--r--

r = 4
w = 2
x = 1

chown -R username:group directory
-R recursive
https://askubuntu.com/questions/6723/change-folder-permissions-and-ownership

chmod

ls -> see, interpret, change


groups
adduser
addgroup
users


Basic Linux CLI Survival
blog post: basic linux survival
cd / ls / pwd
id, chown, chmod
sudo -s !!
touch, echo "" >> file
rm, mv, ...

Learn Bash: awk + grep + sed = all the power in the universe
http://www.theunixschool.com/p/awk-sed.html





drwxrwxrwx+ 1 1000 users      3712 Jul 20 17:08 jenkins




Add user to the docker group

```
sudo synogroup --add docker $USER
sudo chown root:docker /var/run/docker.sock

# https://forum.synology.com/enu/viewtopic.php?t=135680
# --> TODO: Not sure if this will survive a reboot?


# DSM doesn't have usermod
sudo usermod -a -G docker $USER
```

usermod -u 1031 jenkins
groupmod -g 65537 jenkins
