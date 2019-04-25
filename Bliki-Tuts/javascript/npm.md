NPM
===
"You probably got npm because you want to install stuff."

To Check
--------
https://www.npmjs.com/package/slow-deps
https://nodesource.com/blog/eleven-npm-tricks-that-will-knock-your-wombat-socks-off/

On npm-update:
As of npm@2.6.1, the npm update will only inspect top-level packages. Prior versions of npm would also recursively inspect all dependencies. To get the old behavior, use `npm --depth 9999 update`, but be warned that simultaneous asynchronous update of all packages, including npm itself and packages that npm depends on, often causes problems up to and including the uninstallation of npm itself.
file:///C:/Users/Wouter/AppData/Roaming/npm/node_modules/npm/html/doc/cli/npm-update.html

To a good start on NPM!

Basics
------
```
npm init

npm install --save # -S
npm i --save-dev # -D
npm i --global # -g
npm update
npm uninstall # rm

# Bleeding edge
npm i npm-thingie@latest
npm i npm-thingie@next

# Specific
npm i npm-thingie@2.0.1

# Find em
npm search # ... Takes ages, opening a browser is probably faster

# Update em
npm outdated
npm update --dev # will update devDependencies also
```

Dependencies
------------
semver: major.minor.patch
```
dependencies: {
  update_includes_minor_and_patch: "^1.0.5",
  update_includes_patch_only: "~1.1.1",
  same_as_above: "1.1.x",
  exactly_this_version: "1.1.1",
  equal_or_higher: ">=1.1.1",
  latest: "latest",
  any_version: "*"
}
```

Configuration
-------------
node-gyp on Windows fun...  
https://github.com/nodejs/node-gyp  

npm config set python c:\bin\Python2\python.exe --global
npm config set msvs_version 2015 --global

npm rebuild node-sass

# If Python2 is not in $env:PATH
$env:PYTHON = "c:\bin\python2\python.exe"

# Passing Python Path on install:
# npm install --python=c:\bin\python2

**nvm**:  
Use https://github.com/coreybutler/nvm-windows for Windows  
As admin in %AppData%\Roaming\nvm:
```
nvm list [available]
nvm install 4.2.2
nvm use 4.2.2
```


npm gets its config settings from the command line, environment variables, npmrc files, and in some cases, the package.json file.
```
# List some config
npm get
```

More Commands
-------------
```
# List dependencies
npm list --depth=0 --long # or ll or la instead of --long
npm ls --prod # or --dev

# Get a package.json
npm view licenser
npm view licenser versions
npm view licenser@0.8.0 repository.url

# Get local info
npm owner ls
```

Package Development
-------------------
```
cd dependency-name
npm link
cd app
npm link dependency-name
npm unlink dependency-name
```

Publishing
----------
```
# Clean excess packages
npm prune
# Also clean the --save-dev packages
npm prune --production

# Commit, create tag
npm version 1.2.3
```

Scripts
-------
Defined in package.json
```
npm install --production
npm start # restart, stop
npm test
npm run custom-task
```
Force 0 Ok Exit Code: "jasmine; true"


Fun Stuff
---------
```
# Go to nearest package.json dir
npm prefix | cd
```

Collaboration
-------------
```
npm adduser
npm whoami
npm publish
```

To check:
npm shrinkwrap
npm version


.npmrc
------