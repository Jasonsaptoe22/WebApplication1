# Korsten Lutheran Church

A church website for Korsten Lutheran Church in Gqeberha, South Africa. Built with ASP.NET Core Razor Pages, it introduces the congregation, shares sermon summaries, and highlights the soup kitchen ministry.

## Features

- **Home:** welcome message, service information, and ministry highlights.
- **About:** information about the congregation and its beliefs.
- **Soup Kitchen:** ministry information, schedules, photo gallery, volunteering opportunities, and donation details.
- **Sermon Archive:** dated sermon summaries with speakers, Scripture references, series, and tags, displayed newest first.
- Shared navigation and footer, custom styling, and church photography.

Sermon and soup kitchen content is stored in JSON files. No database or admin dashboard is required; updates are made directly in the project files. The sermon archive currently displays text summaries, with no audio or video playback implemented.

## Technology

- C# and .NET 8
- ASP.NET Core Razor Pages
- HTML, CSS, and JavaScript
- Bundled Bootstrap and jQuery assets
- JSON content loaded with `System.Text.Json`

## Run locally

Install the .NET 8 SDK and Git. Run these commands from a terminal:

```sh
git clone https://github.com/Jasonsaptoe22/WebApplication1.git
cd WebApplication1
dotnet restore WebApplication1.sln
dotnet run --project WebApplication1/KLP.csproj --launch-profile http
```

Open `http://localhost:5145` in your browser. Access to the repository is required to clone it while it is private.

For local HTTPS, trust the development certificate and use the HTTPS profile:

```sh
dotnet dev-certs https --trust
dotnet run --project WebApplication1/KLP.csproj --launch-profile https
```

Then open `https://localhost:7079`. You can also open `WebApplication1.sln` in Visual Studio with the ASP.NET and web development workload installed.

## Project structure

```text
WebApplication1.sln
WebApplication1/
  KLP.csproj                  .NET project definition
  Program.cs                  Application startup and request pipeline
  Data/
    sermons.json              Sermon archive entries
    soup-kitchen.json         Soup kitchen content
  Pages/
    Index.cshtml              Home page
    About.cshtml              About page
    Sermons.cshtml            Sermon archive
    SoupKitchen.cshtml        Soup kitchen page
    Shared/_Layout.cshtml     Shared navigation and footer
  Properties/
    launchSettings.json       Local launch profiles and ports
  wwwroot/
    Images/                   Church photos and graphics
    css/site.css              Main stylesheet
    js/site.js                Site JavaScript
    lib/                      Bundled frontend libraries
  appsettings.json            Application configuration
```

## Update content

### Sermons

Add an object to the array in `WebApplication1/Data/sermons.json`, using this format:

```json
{
  "date": "2026-09-20",
  "title": "Example sermon title",
  "series": "Example series",
  "speaker": "Speaker name",
  "scripture": "John 3:16",
  "summary": "A short summary of the message.",
  "tags": ["Faith", "Grace"]
}
```

Use dates in `YYYY-MM-DD` format and keep the file valid JSON. Entries without a title are omitted, and the page sorts entries by date automatically.

### Soup kitchen

Edit `WebApplication1/Data/soup-kitchen.json` to change the introduction, schedule, impact statistics, gallery, involvement options, donation instructions, and contact information. Keep the existing property names and structure.

### Pages, images, and styles

Edit the corresponding `.cshtml` files for home and about content. Navigation, footer contact details, and footer service times are in `Pages/Shared/_Layout.cshtml`. Add images under `wwwroot/Images` and reference them using paths such as `/Images/photo.jpeg`. Match filename and directory capitalization exactly for case-sensitive hosts.

Make visual changes in `wwwroot/css/site.css`. Some links currently use `href="#"`; replace these with their intended destinations as those pages or social profiles become available.

## Build and publish

Run commands from the repository root:

```sh
dotnet build WebApplication1.sln --configuration Release
dotnet publish WebApplication1/KLP.csproj --configuration Release --output publish
```

The `publish` directory contains the deployment output. Before deployment, confirm it includes `Data/sermons.json`, `Data/soup-kitchen.json`, and the `wwwroot` assets. Run the published application from that directory with `dotnet KLP.dll` on a host with the ASP.NET Core 8 runtime installed, and configure the host's HTTPS and port settings.

This is a server-rendered ASP.NET Core application and needs a host capable of running it. Uploading the source to GitHub does not deploy a running website.

## Verification

There is currently no automated test project. After editing, build the solution and open `/`, `/About`, `/Sermons`, and `/SoupKitchen` locally. Check navigation, images, content, and the layout at desktop and mobile widths.

Generated build output and Visual Studio workspace files are excluded through `.gitignore`.
