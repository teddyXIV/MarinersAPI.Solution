# Mariners.Solution

####  An ASP.NET web API for offensive statistics for the 2023 Seattle Mariners.

#### By Teddy Peterschmidt

## Technologies Used

* C#
* .NET 6 SDK
* Entity Framework Core
* RestSharp
* JWT Authentication

## Description

This API allows the user to:

* Create an account and sign in and out. 
* Make GET requests to view player statistics, and filter the results based on the player's name
* Once a user has signed in to an account they can:
    * Make a POST request to create a new player 
    * Make a PUT request to update an existing player's statistics
    * Make a DELETE request to remove players from the database 

## Setup/Installation Requirements

* Clone this repository.
* If needed, download and configure MySQL Workbench for your operating system by following the instructions in [this lesson.](https://full-time.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql) 
* Navigate to the production directory "MarinersApi".
* Within the production directory "MarinersApi", create two new files: `appsettings.json` and `appsettings.Development.json`.
* Within `appsettings.json`, add the following code":
```json 
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR_DATABASE-NAME];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  },
  "JWT": {
    "ValidAudience": "[YOUR-AUDIENCE]",
    "ValidIssuer": "[YOUR-ISSUER]",
    "Secret": "[YOUR-SECRET]"
  }
}
```
* Make the following changes to the above code snippet: 
    * Replace the `database`, `uid`, and `pwd` values for the `DefaultConnection` value with your own username and password for MySQL. 
    * Replace the values of `ValidAudience`, `ValidIssuer` and `Secret` with the values you would like to use. The value of `Secret` must be at least 16 characters long.
* Withing `appsettings.Development.json`, add the following code:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```
* In the command line, run "dotnet restore" to download and install packages.
* If needed, add `dotnet-ef` to your device by running "dotnet tool install --global dotnet-ef --version 6.0.0"
* In the command line run "dotnet ef database update" to update your database.
* In the command line, run the command "dotnet run" to compile and execute the application.
* Optionally, you can run "dotnet build" to compile this application without running it.

## Endpoints

To test the endpoints of this API, use [Postman](https://www.postman.com/) to send requests.

### Using the JSON Web Token

To make POST, PUT, and DELETE requests, you must be authenticated. 

To autheticate yourself via postman, follow these steps:
* Open Postman and create a POST request to `http://localhost:5000/api/accounts/register`.
    * Add the following query to the request as raw data in the Body tab:
```json
{
    "Email": "test@test.test",
    "Password": "Testing123!"
}
```
* Create another POST request to `http://localhost:5000/api/accounts/signIn`.
    * In the Body tab, add the same raw data as the above code snippet.
* The token will be generated in the response. Copy and paste the token as the Token parameter in the Authorization tab after selcting the type "Bearer Token".

### Available Endpoints

```
GET http://localhost:5000/api/Players/
POST http://localhost:5000/api/Players/
GET http://localhost:5000/api/Players/{id}
PUT http://localhost:5000/api/Players/{id}
DELETE http://localhost:5000/api/Players/{id}

```
Note: Int he above endpoints, `{id}` is a variable and should be replaced with the id value of a specific player. 

### Optional Query String Parameters for GET Requests

GET requests to `http://localhost:5000/api/Players/` can optionally include query strings to filter or search players.

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| name        | string      | not required | Returns players with names containing the "name" value |
| pageNumber  | Integer     | not required | Returns players from the page specified by the "pageNumber" value  |
| pageSize    | Integer     | not required | Returns the number of players specified by the "pageSize" value per page  |

### Examples

The following query will return all players with a name value that contains "Julio":

```
GET http://localhost:5000/api/Players?name=Julio
```

The following query will return all players on the second page of results:

```
GET http://localhost:5000/api/Players?pageNumber=2
```

The following query will return a page with 3 players:

```
GET http://localhost:5000/api/Players?pageSize=3
```

You can include multiple query strings by separating them with an `&`:

```
GET http://localhost:5000/api/Players?name=Julio&pageSize=3
```

### Requirments for POST requests

When making a POST request to `http://localhost:5000/api/Players/`, **body** must be included. Here is an example body in JSON:

```json
{
  "Name": "Eugenio Suarez",
  "Number": 28,
  "Average": 0.232,
  "OnBase": 0.323,
  "Slug": 0.391,
  "Homerun": 22,
  "CreatorId": "Example123" 
}
```

### Requirments for PUT requests

When making a PUT request to `http://localhost:5000/api/Players/{id}`, you need to include a **body** that includes the player's `PlayerId` property. Here's an example body in JSON for a put request sent to `http://localhost:5000/api/Playerss/1`:

```json
{
  "PlayerId": 1,  
  "Name": "Julio Rodriguez",
  "Number": 44,
  "Average": 0.275,
  "OnBase": 0.333,
  "Slug": 0.485,
  "Homerun": 100,
  "CreatorId": "Example123" 
}
```

Note: the value of `PlayerId` needs to match the `{id}` in the URL. In this example, they are both 1.

## Known Bugs

* Unknown at this time. 

## License

[MIT License](./LICENSE)