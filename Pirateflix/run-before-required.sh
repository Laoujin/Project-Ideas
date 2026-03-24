#!/bin/bash
# Stop Docker containers to avoid backing up corrupt databases
#
# Configure in Duplicati:
# --run-script-before-required=/htpc/duplicati-scripts/run-before-required.sh

OPERATIONNAME=$DUPLICATI__OPERATIONNAME

if [ "$OPERATIONNAME" != "Backup" ]; then
    exit 0
fi

# cd /htpc
# containers=$(docker-compose ps | tail -n +3 | grep -oP --regexp="^[^ ]+")

# while IFS= read -r container; do
#     if echo $container | grep -ivqF duplicati; then
#         echo "docker stop $container"
#         docker stop $container
#     fi
# done <<< "$containers"

exit 0


# TODO: new approach:
# -> Delete docker-compose variable
# -> Search in the docker-compose.yml file for "(?:container_name:\s*).*$"

