Vagrant
=======
vagrant global-status



Creating a Box
==============
Tutorial: [how-to-create-a-vagrant-base-box-from-an-existing-one](https://scotch.io/tutorials/how-to-create-a-vagrant-base-box-from-an-existing-one)

**Creating**
```
# Create a box file in current directory
vagrant package --output dabox.box

# Adds 'dabox' to ~/.vagrant.d/boxes
vagrant box add dabox dabox.box
```

**Vagrantfile**
```
config.vm.box = "dabox"
```

**Partially downloaded boxes**:  
%USERPROFILE%\.vagrant.d\tmp