Docker
======
& "C:\Program Files\Docker Toolbox\docker-machine.exe" env default | Invoke-Expression

# Docker run
# https://docs.docker.com/engine/reference/run
docker run --name mongo2 -p 27017:27017 -d mongo:3.1 /bin/bash
--restart=always
-d --detached
-i # Keep STDIN open
-t # Allocate psuedo-tty
--name
-p  host:container
-v /host:/container
--rm # remove container on exit

When not detached, detach with: Ctrl + pq


# confac
docker build -t confac1 .
chown 1000:1000 /volume1/docker/confac
docker run -it -p 9000:9000 -v /volume1/docker/confac-test:/home confac-test

# Bash into container
docker exec -u jenkins -it jenkins-prd2 sh
docker exec -it confac-tst sh

# Have 

Start
-----
cd %USERPROFILE%\.docker\machines\default
if .docker\machines\default does not exist, run "Docker Quickstart Terminal".

docker-machine restart default
docker-machine rm default
docker-machine create default --driver virtualbox

$ docker-machine env --shell=powershell | Invoke-Expression
$ docker run hello-world

# List machines
$ docker-machine ls

$ docker-machine ip

# Bash
$ docker run -it debian /bin/bash

# Delete machine
$ docker-machine rm some-mach

Volumes
-------

docker volume rm jenkins_home
docker volume create jenkins_home
docker volume inspect jenkins_home

Mongo & Node
------------
$ docker pull mongo:latest
$ docker run -v "$(pwd)":/data --name mongo -d mongo mongod --smallfiles


$ docker run --name mongo2 -p 27017:27017 -d mongo


# Open mongo shell
$ docker run -it --link mongo:mongo --rm mongo sh -c 'exec mongo "192.168.99.100:27017/confac"'

# Mongo data dump
$ mongodump --db test --out /data/test-backup
$ mongorestore --db test-restored /data/test-backup/test

# Open bash shell
$ docker exec -it mongo bash


# Node
$ docker pull node:latest
$ docker run -it --rm node

Toolbox
-------
cd "C:\Program Files\Docker Toolbox"

Troubleshooting
---------------
docker ps
# --> An error occurred trying to connect: Get http://%2F%2F.%2Fpipe%2Fdocker_engine/v1.24/containers/json: open //./pipe/docker_engine: The system cannot find the file specified.

set DOCKER_CERT_PATH=%USERPROFILE%\.docker\machine\machines\default
set DOCKER_HOST=tcp://192.168.99.100:2376
set DOCKER_MACHINE_NAME=default
set DOCKER_TLS_VERIFY=1



docker-machine env


docker run


Dockerfile
----------
docker build .

```
FROM debian

RUN apt-get update
RUN apt-get install -y curl
RUN curl -sL https://deb.nodesource.com/setup_6.x | bash
RUN apt-get install -y nodejs build-essential

#ENV PATH /usr/local/nginx/bin:$PATH
#ENV PG_MAJOR 9.3

COPY dist /home
VOLUME /home

EXPOSE 9000

WORKDIR /home
CMD ["bash"]
#CMD ["node", "./server.js"]
```
