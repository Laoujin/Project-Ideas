MongoDb
=======
.NET
----
Install-Package MongoDB.Driver

https://github.com/mongolab/mongodb-driver-examples/blob/master/c%23/CSharpSimpleExample.cs

```
MongoDB.Bson.ObjectId Id = ObjectId.GenerateNewId();

var conventionPack = new ConventionPack {new CamelCaseElementNameConvention()};
ConventionRegistry.Register("camelCase", conventionPack, t => true);

string uri = "mongodb://localhost:27019/db";
var client = new MongoClient(uri);
var db = client.GetDatabase("db");
var col = db.GetCollection<Entity>("entities");
await catsDb.InsertManyAsync(someCol);
```

Querying
--------
db.getCollection('products').find({$where: "this.options.length > 1"})
col.find({"propName": {$gt: 1} });


Debian Installation
-------------------
http://www.ifdattic.com/how-to-mongodb-nodejs-docker/

**Debian:**  
Config: `sudo vim /etc/mongod.conf`  
Data: `/var/lib/mongodb/`  
Logs: `tail -50 /var/log/mongodb/mongod.log`  

Restart: sudo service mongod restart  

Permissions data directory:  
```
sudo chown mongodb:mongodb /vol/db/
sudo chmod 777 /vol/db/
```

Installation:

```
#!/bin/sh
# sudo su -

# http://docs.mongodb.org/manual/tutorial/install-mongodb-on-ubuntu/
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv 7F0CEB10
echo 'deb http://downloads-distro.mongodb.org/repo/ubuntu-upstart dist 10gen' | sudo tee /etc/apt/sources.list.d/mongodb.list

# general dependencies
sudo apt-get -y update
sudo apt-get -y install nodejs nodejs-legacy npm mongodb-org git

# configuration
sudo sed -i "s/bind_ip = 127.0.0.1/# bind_ip = 127.0.0.1/g" /etc/mongod.conf

sudo service mongod restart
```

Shell
-----


> show dbs
> use new_or_existing_db
> show collections
> db.colName.find()
> db.colName.insert({"name": "whee"})

// Connect using environment variables
MongoClient.connect('mongodb://'+process.env.MONGO_PORT_27017_TCP_ADDR+':'+process.env.MONGO_PORT_27017_TCP_PORT+'/blog', function(err, db) {
    // ...
});

