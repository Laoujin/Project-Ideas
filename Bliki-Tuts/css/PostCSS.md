PostCSS
=======
Other Plugins
-------------
**autoprefixer**: Add vendor prefixes powered by Can I Use

CssNext
-------
**Variables and `calc()`**
```
:root {
  --fontSize: 1rem;
}

h1 {
  font-size: calc(var(--fontSize) * 2);
}
```

**Media Query Ranges**
```
@media (width >= 500px) and (width <= 1200px) {}
```
or
```
@custom-media --only-medium-screen (width >= 500px) and (width <= 1200px);
@media (--only-medium-screen) {}
```

**Custom selectors**
```
@custom-selector :--button button, .button;
@custom-selector :--enter :hover, :focus;

:--button {}
:--button:--enter {}
```

**Colors**
```
a { color: color(red alpha(-10%)) }
a { color: gray(255)}
a { color: gray(10%, 50%)}
a { color: #fffc } /* #rrggbbaa */
```

**Pseudo Classess**
```
nav :any-link {}
p:matches(:first-child, .special) {}
p:not(:first-child, .special) {}
```

**Other**  
`font-size: 1.5rem`: 
`@import './variables.css'`: inline local file or module
```

PostCSS Nested
--------------
```
.phone {
    &_title {
        width: 500px;
        @media (max-width: 500px) {
            width: auto;
        }
        body.is_dark & {
            color: white;
        }
    }
    img {
        display: block;
    }
}
```
becomes
```
.phone_title {
    width: 500px;
}
@media (max-width: 500px) {
    .phone_title {
        width: auto;
    }
}
body.is_dark .phone_title {
    color: white;
}
.phone img {
    display: block;
}
```

PostCSS Simple Vars
-------------------
```
$dir:    top;
$blue:   #056ef0;
$column: 200px;

.menu_link {
    background: $blue;
    width: $column;
}
.menu {
    width: calc(4 * $column);
    margin-$(dir): 10px;
}
```
becomes
```
.menu_link {
    background: #056ef0;
    width: 200px;
}
.menu {
    width: calc(4 * 200px);
    margin-top: 10px;
}
```