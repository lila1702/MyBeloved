# ⚠️ ATTENTION❗ THIS PAGE IS IN WORK IN PROGRESS ⚠️
<!--<img src="./src/img/MyBeloved-Logo.svg"/>-->
# MyBeloved ❤️

MyBeloved is a web application where you can create notebooks that will have prompts for things you should write to your beloved partner as a romantic gesture, and when you finish it, you can share it with them, and they'll be able to read one page per day, depending on how they're feeling that day, and the prompt the page was made for ❤️

## Table of Contents
- [Motivation](#Motivation)
- [About](#About)
- [Contributing](#Contributing)

## Motivation

I've personally made this app because I wanted to make a handmade gift to My Own Beloved, but I'm not particularly skilled with hand crafts and such, so I tried to use my actual skills to build something special for them. I was originally going to keep the repository private, but I was getting pretty proud of what I was doing by myself, so I decided I wanted to share.

## About

The app (so far) is made with .NET 8.0, with a quickstart thanks to the ASP.NET Core Web API template, without the use of Minimal APIs. PostgreSQL for the database, and Entity Framework for Commands and Queries, following a Code-First approach.

## Contributing

### Tools Needed
- An IDE capable of running .NET ([VS Code](https://code.visualstudio.com/download), [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/), [Rider](https://www.jetbrains.com/pt-br/rider/), etc)
- [.NET 8.0](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Installation

Make sure to have git installed in your computer.

```bash
git clone https://github.com/lila1702/MyBeloved.git
```

### Configure your enviroment

In the file "appsettings.Development", make sure to change the connection string to your own host of Postgres
```c#
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=[your-port];Username=[your-user];Password=[your-password];Database=[Your-Database-Name-Choice];Trust Server Certificate=true"
  }
}
```
