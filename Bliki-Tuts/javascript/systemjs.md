SystemJS
========
If Promise is not available, will load system-polyfills.js

<script src="system.js"></script>

Configuration
-------------
System.config({
  baseURL: '/modules', // --> Provide dependencies in this directory
  map: { // --> Or provide specific mapping for dependencies not present in baseURL
    app: '/src/app/',
    jquery: 'https://code.jquery.com/jquery.js'
  }
});

System.import('./relative-url.js');
System.import('https://code.jquery.com/jquery.js');

// loads /modules/some-dep.js (baseUrl)
System.import('some-dep.js').then($ => console.log.bind(console));

// loads /src/app/file.js (map.app replacement)
System.import('app/file.js');

Other Config
------------
Babel:
https://babeljs.io/docs/usage/options/
System.config({
  transpiler: 'babel', // default=traceur (traceurOptions)
  babelOptions: {
    presets: ['es2015']
  },
});

defaultJSExtensions: Deprecated
paths: Use map instead
typescriptOptions: https://www.typescriptlang.org/docs/handbook/compiler-options.html

To study:
https://github.com/systemjs/systemjs/blob/master/docs/config-api.md#meta
https://github.com/systemjs/systemjs/blob/master/docs/config-api.md#packages

depCache
--------
System.config({
  depCache: {
    moduleA: ['moduleB'], // moduleA depends on moduleB
    moduleB: ['moduleC'] // moduleB depends on moduleC
  }
});

// when we do this import, depCache knows we also need moduleB and moduleC,
// it then directly requests those modules as well as soon as we request moduleA
System.import('moduleA')

Bundles
-------
System.config({
  bundles: {
    bundleA: ['dependencyA', 'dependencyB']
  }
});

Plugins
-------
Plugin: https://github.com/systemjs/plugin-text
Install: jspm install text

Config:
System.config({
  // locate the plugin via map configuration
  // (alternatively have it in the baseURL)
  map: {
    text: '/path/to/text-plugin.js'
  },
  // use meta configuration to reference which modules
  // should use the plugin loader
  meta: {
    'templates/*.html': {
      loader: 'text'
    }
  }
});

Usage:
import myText from './mytext.html!text'; // No !text --> use extension loader (ie: in this case, html)

JSPM
====
npm install jspm --save-dev
jspm init

jspm install npm:lodash-node
jspm install github:components/jquery
jspm install jquery
jspm install myname=npm:underscore