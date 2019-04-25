Docker
======

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

find /var/jenkins_home -group 1000 -exec chgrp -h jenkins {} \;
find /var/jenkins_home -user 1000 -exec chown -h jenkins {} \;

Setup
-----

```
# Synology cannot create user with specific uid:
sudo synouser --add jenkins 1 "jenkins" 0 jenkins@pongit.be 0
sudo synouser --get jenkins | grep uid

sudo synogroup --add jenkins jenkins
sudo synogroup --member docker jenkins # TODO: Test that this allows Docker without sudo?

# sudo synogroup --add groupname username1 username2
# sudo synogroup --member groupname username1 username2

sudo chown -R jenkins:jenkins /volume1/Code/Synology/Jenkins/jenkins_home
sudo chown -R laoujin:users /volume1/Code/Synology/Jenkins/jenkins_home

sudo vi /etc/passwd
```
