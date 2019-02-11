# Infotem-Tuifly
Cette application est une simple application pour la simulation de gestion des vols entre aéreroports et estimation des distance, et charges.

développé avec Asp.net core 2.1.1 et les composant suivant  :

### Sqlite 
`Microsoft.EntityFrameworkCore.SQLite`
[![Nuget version](https://badge.fury.io/nu/Microsoft.EntityFrameworkCore.SQLite.svg)](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/)

J'ai choisi SQLite comme un SGBD  (moteur de gestion de base de données),simple à utiliser, déjà implimenté dans entityframework, et qui ne naissite aucun installation

### GeoCoordinate.NetCore

[![Nuget version](https://badge.fury.io/nu/GeoCoordinate.NetCore.svg)](https://www.nuget.org/packages/GeoCoordinate.NetCore/)


Une bibliothèque .NET(Nuget package) qui permet de calculer des distances à partir des coordonnées gps de deux points

### Nsubstitute
http://nsubstitute.github.io/

[![Nuget version](https://badge.fury.io/nu/NSubstitute.svg)](https://www.nuget.org/packages/NSubstitute/)

Une bibliothèque .NET(Nuget package) qui permet le test d'indépendance des couche d'une application en moquant les appels aux autre couches

### Instructions d'utilisation:
- `dotnet restore`
- `dotnet build` 
- `dotnet  run InfoTemTuiFly/InfoTemTuiFly.csproj`

Sinon utiliser visual studio 
