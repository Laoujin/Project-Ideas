
jade/layout.jade
----------------
Inheritance with `extends`  
Include files with `include`

jade/index.jade
---------------
Basics:  
- div is default
- #id
- .class

Attributes:  
- class: Assign with array, object {"pull-right": true} and/or string
- style: Assign with object or string
- Commas optional

Variables:  
- Can do JavaScript after -
- #{var} = escaped
- !{var} = unescaped

Not Covered
-----------
Filters: JSTransformers :coffee-script, :babel, :uglify-js, :less, and :markdown-it
