Osrm.Client
==========
A Http client for OSRM for 5x API

Forked from https://github.com/JubilsoftTechnologies/Osrm.Client - version 3.5.0.1

## Changes from forked version:
- resolved switched waypoint latitude/longitude bug
- moved from using double to decimal for distance,duration,latitude,longitude
- added annotations for RouteRequest (in order to get time/distance info along geometry)
- added annotations for TableRequest (in order to get distance matrix as well)
- use of polyline6 default format for geometry response decoding

## Usage Summary (from forked repo): 
  (see also OSRM documentation - http://project-osrm.org/docs/v5.22.0/api)
#### Route
```csharp
using HttpClient client = new HttpClient();
var osrm5x = new Osrm5x(client, "http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.503033, 13.420526),
    new Location(52.516582, 13.429290),
};

var result = await osrm.Route(locations);

var result2 = await osrm.Route(new RouteRequest()
{
    Coordinates = locations,
    Steps = true
});
var result3 = await osrm.Route(new RouteRequest()
{
    Coordinates = locations,
    SendCoordinatesAsPolyline = true
});
```

#### Table
```csharp
using HttpClient client = new HttpClient();
var osrm5x = new Osrm5x(client, "http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.517037, 13.388860),
    new Location(52.529407, 13.397634),
    new Location(52.523219, 13.428555)
};

//Returns a 3x3 matrix:
var result = await osrm.Table(locations);

//Returns a 1x3 matrix:
var result2 = await osrm.Table(new Osrm.Client.Models.Requests.TableRequest()
{
    Coordinates = locations,
    Sources = new uint[] { 0 }
});

//Returns a asymmetric 3x2 matrix with from the polyline encoded locations qikdcB}~dpXkkHz:
var result3 = await osrm.Table(new Osrm.Client.Models.Requests.TableRequest()
{
    Coordinates = locations,
    SendCoordinatesAsPolyline = true,
    Sources = new uint[] { 0, 1, 3 },
    Destinations = new uint[] { 2, 4 }
});
```

#### Match
```csharp
using HttpClient client = new HttpClient();
var osrm5x = new Osrm5x(client, "http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.517037, 13.388860),
    new Location(52.529407, 13.397634),
    new Location(52.523219, 13.428555)
};

var request = new Osrm.Client.Models.Requests.MatchRequest()
{
    Coordinates = locations
};

var result = await osrm.Match(request);
```

#### Nearest
```csharp
using HttpClient client = new HttpClient();
var osrm5x = new Osrm5x(client, "http://router.project-osrm.org/");
var result = await osrm.Nearest(new Location(52.4224, 13.333086));
```

#### Trip
```csharp
using HttpClient client = new HttpClient();
var osrm5x = new Osrm5x(client, "http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.503033, 13.420526),
    new Location(52.516582, 13.429290),
};

var result = await osrm.Trip(locations);
```
