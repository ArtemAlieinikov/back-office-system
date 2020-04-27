To start application there are two options:

- How to run via Kestrel:
	0. Update connection string and paths to the tsv files in appsettings.json (tsv files are placed in data folder)
	1. Open CMD in current (where readme is located) folder
	2. Run command "dotnet restore ./BackOfficeSystem/BackOfficeSystem.csproj"
	3. Run command "dotnet build" (npm i command will take some time, depends on the internet connection)
	4. Run command "dotnet run --project ./BackOfficeSystem/BackOfficeSystem.csproj"
	5. Go to the browser with HTTP route (can be find in CMD message)

- How to run via IIS forward proxy:
	1. Open Solution in Visual Studio
	2. Press F5

If app was not launched, refresh page or try command again

- Extras:
	1. Swagger enpoint as usual /swagger
	2. Client app is integrated into backend application (see client-app folder)
	3. Was implemented custom TSV reading library