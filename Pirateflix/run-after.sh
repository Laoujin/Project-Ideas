#!/bin/bash
# Restart Docker containers after backup
#
# Configure in Duplicati:
# --run-script-after=/htpc/duplicati-scripts/run-after.sh

OPERATIONNAME=$DUPLICATI__OPERATIONNAME

if [ "$OPERATIONNAME" != "Backup" ]; then
    exit 0
fi


echo "docker-compose up -d"
exit 0




# SLACK_WEBHOOK_URL=https://hooks.slack.com/services/OBFUSCATED
# SLACK_CHANNEL="#backups"
# SLACK_MSG="Backup performed for ${DUPLICATI__backup_name}"

# curl -s -X POST --data-urlencode "payload={\"channel\": \"${SLACK_CHANNEL}\", \"username\": \"duplicati\", \"text\": \"${SLACK_MSG}\", \"icon_emoji\": \":information_source:\"}" "${SLACK_WEBHOOK_URL}"



# DUPLICATI__EVENTNAME = when script was triggered such as “BEFORE” or “AFTER”
# DUPLICATI__OPERATIONNAME = operation, such as “Backup”, “Cleanup”, “Restore”, etc.
# DUPLICATI__RESULTFILE = path to file in which result data is stored
# DUPLICATI__REMOTEURL = “URL” target backend
# DUPLICATI__LOCALPATH = path to folders being backed up or restored
# DUPLICATI__PARSED_RESULT = run result such as “Unknown”, “Success”, “Warning”, “Error”, or “Fatal”
