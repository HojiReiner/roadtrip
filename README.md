# Roadtrip
 A simple API that connects to Google Maps **(Google API Key and Maps API Active are needed to run)**

|Operation|Address|Description|
|---------|-------|-----------|
|GET| /api/highlight?lat=&lng=| Get the closest highlight to the given coordinates|
|GET| /api/route?lat0=&lng0=&lat1=&lng1=| Gets the highlights for multiple routes between the given coordinates|

## Useful Commands

```pwsh
#Run project (.NET6 Needed)
dotnet run
```