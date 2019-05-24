Project Ideas
=============

But who has the time for all that.

console.log() & console.table() & console.assert(condition, msg)?
console.log() // Placeholders: https://stackoverflow.com/a/42037057/540352

console.time() & timeEnd(), timeStamp()?
console.log() / warn, error, info, trace, debug
console.count, context, group/End/Collapsed, dir, dirxml, clear
memory, profile, profileEnd()


OneNote migration
-----------------
http://www.codinghorror.com/blog/2005/05/welcome-to-the-tribe.html
Paul Graham: http://www.paulgraham.com/articles.html
Eric Raymond: http://www.catb.org/~esr/writings/

big O explained: http://stackoverflow.com/questions/487258/plain-english-explanation-of-big-o

http://lifehacker.com/5965536/how-do-i-pitch-an-idea-that-actually-gets-heard

DZone Cheat Sheets:
https://dzone.com/refcardz


Funny JavaScript
----------------

```js
new Boolean(true) === false

[] + [] === ''
typeof([] + {}) === '[object Object]'
{} + [] === 0
{} + {} === NaN
Array(16).join('wat' - 1) + ' Batman' === 'NaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaNNaN Batman'
```



Things to do
------------

Some random stuff:  

- Jenkins: have a gem check all urls for 404s?
- licenser issues + easier update of many projects?

Learn Bash: awk + grep + sed = all the power in the universe
http://www.theunixschool.com/p/awk-sed.html

### Check software

- NimbleText



Stackoverflow
How do you crash the .NET runtime
--> From The Passionate Programmer


Blog post: build Chrome with different margin/padding colors



pongit.be
Speel pong (multiplayer?)
Pong thais bord met IT in mspaint?


TODO
====
need to check my list of starred repos...
--> master the command lint
--> git tips & hints
--> free developer books
--> lots of interesting stuff....


Pomperom
========
Series te checken:
Jordskott

Time travel movies:
The thirtheenth floor
Jacobs ladder
Stay

Weird movies?
Pinokio 946

To buy: Suikerwater en pisco (Wereldwinkel)


Reis Karel & Michael:
https://www.facebook.com/groups/1224924537524979/?fref=ts




# Megalomania

Like mega big projects that won't ever be done probably:  

- A WPF app to edit registry, environment variables, ..
- VacationApp? Check: relive.cc en Strava
- International Phonetic Alphabet (IPA)


## How does a computer work

http://cs.stackexchange.com/questions/3390/how-does-a-computer-work
http://softwareengineering.stackexchange.com/questions/81624/how-do-computers-work
https://www.youtube.com/watch?v=IlPj5Rg1y2w



# Agile

Scrum, Misapplied
It's not entirely Scrum's fault. Agile development isn't just about good engineering practices. It's also about acknowledging the importance of people in software development, forming cross-functional teams, obtaining high-bandwidth communication, constantly reflecting and improving, delivering value, and changing plans to take advantage of opportunities.
Scrum includes these other points. It says that the team should be cross-functional and recommends collocating the team in a shared workspace. It says the team should deliver a valuable, shippable product at the end of every Sprint, and that the team should self-organize, discover impediments, and remove them.
Oh, and it also has a few mechanical things about a monthly Sprint and daily Scrum. Trivial stuff compared to the rest. But guess which part people adopt? That's right--Sprints and Scrums. Rapid cycles, but none of the good stuff that makes rapid cycles sustainable.

Pasted from <http://www.jamesshore.com/Blog/The-Decline-and-Fall-of-Agile.html> 


# Design

API Design:
http://lcsd05.cs.tamu.edu/slides/keynote.pdf

Why is API Design Important to You?
• If you program, you are an API designer
_ Good code is modular–each module has an API
• Useful modules tend to get reused
_ Once module has users, can’t change API at will
_ Good reusable modules are corporate assets
• Thinking in terms of APIs improves code quality


# Why Excel/Word

I'm using Notepad++ (PHP, XML, CSV, …) and Visual Studio (.NET)

But for every project you almost always also need Excel and Word
(Technical Specs, Functional analysis, …) For this blog I also started using Windows Live Writer.
Especially those "non-tech" editors are the ones that developers traditionally just don't want to use.
But fact is, we have to spend considerable time using those tools so learning those editors (really)
well does pay off. The faster you finish the boring (?) Word tasks, the faster you can move on to
the cooler things.


# Pragmatic

## Always Design for Concurrency

“Allow for concurrency, and you'll design cleaner interfaces with fewer assumptions.”
I’m not sure if I already mentioned it but I am a big fan of Joe Duffy and he had to say about concurrency.
--> Opzoeken: ik dacht dat ze zeiden om net niet speciaal voor concurrency te gaan schrijven: meer complexe code en als je dan geen async nodig hebt…


## Put Abstractions in Code, Details in Metadata

Enum PersonType
	Billing
	Shipping
End Enum
Framework Design Guidelines: Don’t use Enums that will grow.
Solutions?
--> Use configuration



# A Case for Goto

Code Complete on “goto”: Is it evil (xkcd link)? Perhaps. I’ve never used a goto in production code but if – and in this case, only if – it turns out it is the best way to solve a problem, then I would feel no remorse using it. It’s there for a reason, if it was truly bad, your language designers wouldn’t have made it available. (and in some languages, like Java, they did decide to take it out) 

Perhaps you’ve got a bug and your production environment is down. You can use the evil goto and have it fixed in 10 minutes or you can write a new UnitTest TDD-style and refactor to make it pass… and have your program or website down for several hours. When confronted with these options, I would always go for getting the system back up and running as fast as possible, even with less than optimal code over making your users angry for several hours. Even if it means writing the forbidden keyword.
I’ve seen GoTo being used in the .NET framework. (check where). Linus Torvals also used it for UNIX?
