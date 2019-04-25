Babel
=====
https://github.com/lukehoban/es6features

Polyfills:
https://polyfill.io/v2/docs/features/
https://polyfill.io/v2/docs/examples
<script src="https://cdn.polyfill.io/v2/polyfill.min.js?features=default,Array.prototype.find,Array.prototype.includes"></script>

Babel-Doctor
------------
```
$ npm install -g babel-cli@^6.1.0
$ babel-doctor
```

SublimeText
-----------
ST3 package: Babel, 
--> https://github.com/babel/babel-sublime-snippets REVIEW+LEARN THESE...

Set Babel as default syntax for a particular extension:
* Open a file with that extension,
* Select `View` from the menu,
* Then `Syntax` `->` `Open all with current extension as...` `->` `Babel` `->` `JavaScript (Babel)`.
* Repeat this for each extension (e.g.: .js and .jsx).

Linting
=======
ST3 packages: Sublime-linter, SublimeLinter-contrib-eslint_d
NPM packages: eslint@latest, babel-eslint@latest, eslint-plugin-react