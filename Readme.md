


# Getting Started
## Building
In Visual Studio 2017 or greater, you can open up the the main flughafen.sln and build the solution directly from within.

##### ToolSet
Framework: Visual Studio 2017 - .NET Framework 4.6.1 - Language C#

##### Dependencies
All project dependencies should be resolved automatically by nuget. The only external library used is NEWTOWNSOFT's json library.

## Limitations/ Criticisms 

# Design Rational
The project uses .NET's Web API libraries to expose a RESTful(lish) (see criticisms) experience to potential clients. A set of Controllers and Models are used to expose the requested set of functions.

Database: A small set of fake databases (in memory/static) are used to mock a set of users and airports.

# API

### Get a LIST of users via name
```
HTTP Verb:	GET 

URL:		flughafen/api/v1/users/names/{name}
param:		{name} is name of user desired; case mATterS
yields:		LIST of User objects matching that name (including userIds)
Errors:		500 + json packet with message + stacktrace on error
example:	flughafen/api/v1/users/names/lord voldemort -> list of user models, with an entry for lord voldemort's profile
```


### Get a user's profile via userId
```
HTTP Verb:	GET 
URL:		flughafen/api/v1/users/{userId}
param:		{userId} is unique numeric identifier of user desired; you can find this via names func (see next)
yields:		json model of User object matching that id
Errors:		500 + json packet with message + stacktrace on error

example:	flughafen/api/v1/users/1 -> model with user profile for martin schluss
```

### Get a LIST of a user's favourite airports (which contain location data)
```
HTTP Verb:	GET 
URL:		flughafen/api/v1/users/{userId}/favs
param:		{userId} is unique numeric identifier of user desired
yields:		LIST of Airport objects favourited by the user
Errors:		500 + json packet with message + stacktrace on error

example:	flughafen/api/v1/users/2/favs -> list favourite airports for user with uid 2
```

### Walk through a user's favorites by its 0 based index number (0-9)
```
HTTP Verb:	GET 
URL:		flughafen/api/v1/users/{userId}/favs/{favnum}
param:		{userId} is unique numeric identifier of user desired
		{favnum} is 0 based index of favourites, from 0-9
		
yields:		Favorited Airport object
Errors:		500 + json packet with message + stacktrace on error
			index not found exception on out of bounds error

example:	flughafen/api/v1/users/2/favs/0 ->  favourite airport # 0 for user with uid 2
```

### Add an airport to a user's favorites list
```
HTTP Verb:	POST 
URL:		flughafen/api/v1/users/{userId}/{airportCode}
param:		{userId} is unique numeric identifier of user desired
			{airportCode} is the Code assigned by FAA to airports (ex: IAD for Dulles International) 
yields:		HTTP 201 on success
Errors:		500 + json packet with message + stacktrace on error

example:	flughafen/api/v1/users/2/iad -> Add airport IAD to user 2's profile as a favourite
```

## Weather

**Weather comes in two flavours; a simple version containing just current conditions:**
```
HTTP Verb:	GET 
URL:		flughafen/api/v1/weather/{airportCode}
param:		{airportCode} is the Code assigned by FAA to airports (ex: IAD for Dulles International)
yields:		WeatherReport object containing current weather conditions
Errors:		500 + json packet with message + stacktrace on error

example:	flughafen/api/v1/weather/iad-> get simple weather for Dulles International
```

**or a more opinionated one:**
```
HTTP Verb:	GET 
URL:		flughafen/api/v1/weather/{airportCode}/detailed
param:		{airportCode} is the Code assigned by FAA to airports (ex: IAD for Dulles International)
yields:		OpinionatedWeatherReport object containing current weather conditions
Errors:		500 + json packet with message + stacktrace on error

example:	flughafen/api/v1/weather/iad/detailed-> get advanced weather for Dulles International
```

**You can also directly get the weather from the user's favs list:**

```
HTTP Verb:	GET 
URL:		flughafen/api/v1/users/{userId}/favs/{favnum}/weather
param:		{userId} is unique numeric identifier of user desired
			{favnum} is 0 based index of favourites, from 0-9
yields:		WeatherReport object containing current weather conditions
Errors:		500 + json packet with message + stacktrace on error
			index not found exception on favs out of bounds error

example:	flughafen/api/v1/users/2/favs/0/weather -> simple weather for favourited airport # 0 for user with uid 2
```

*If you want the opinionated version, simply swap 'weather' with 'advanceWeather':*
```
flughafen/api/v1/users/2/favs/0/advanceWeather
```
