#!/bin/sh

# Script copied from "Device Manager from webOS"
# > Info > Dev Mode > Renew Automatically...

# TODO: Replace YOUR-TV-IP-HERE with well... your TV IP :)

cat > /tmp/webos_privkey_tv << END_OF_PRIVKEY
-----BEGIN RSA PRIVATE KEY-----
-----END RSA PRIVATE KEY-----
END_OF_PRIVKEY

chmod 600 /tmp/webos_privkey_tv

sessionToken=$(ssh -i /tmp/webos_privkey_tv \
 -o ConnectTimeout=3 -o StrictHostKeyChecking=no \
 -p 9922 prisoner@192.168.1.113 \
 cat /var/luna/preferences/devmode_enabled)
if [ -z "$sessionToken" ]; then
  sessionToken=$(cat /tmp/webos_devmode_token_tv.txt)
else
  echo $sessionToken > /tmp/webos_devmode_token_tv.txt
fi

if [ -z "$sessionToken" ]; then
  echo "Unable to get token" >&2
  exit 1
fi

checkSession=$(curl --max-time 3 -s "https://developer.lge.com/secure/ResetDevModeSession.dev?sessionToken=$sessionToken")

echo $checkSession
