Babel
=====
Projects: Babili (babel-minify)


package.json:

```
  "scripts": {
    "start": "babel-node --presets es2015 app.js"
  },
  "dependencies": {
    "babel-cli": "^6.18.0",
    "babel-preset-es2015": "^6.18.0"
  }
```

.babelrc

```
{
  "presets": ["es2015"],
  "plugins": ["transform-object-rest-spread"]
}
```
