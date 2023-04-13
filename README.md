# AdorableCats
Cats are cute, and many people love them. The world, especially now, could use more positivity, so we want to create a smooth, endless feed of adorable cat pictures.

# Running the Web API

## Docker

Make sure you have [installed](https://docs.docker.com/docker-for-windows/install/) docker in your environment. After that, you can run the below commands from the **/AdorableCats** directory and get started with the `AdorableCats Web API` immediately.

```powershell
docker-compose build
docker-compose up
```

You can reach the Web API's full (swagger) documentation here: 
```powershell
http://localhost:5000/swagger/index.html
```
Get a random Cat Image
```powershell
http://localhost:5000/api/v1/Images/random
```
Get 10 random Cat Image
```powershell
http://localhost:5000/api/v1/Images/random10
```

## Dotnet

1. Type in command line:
```powershell
    git clone https://github.com/Jaswir/AdorableCats.git
```
2. Open terminal and change directory to AdorableCats/AdorableCats 
3. Install dotnet SDK 6.0 latest version in link below. 
   Install the x64 version using the installer. 
    ```powershell
    https://dotnet.microsoft.com/en-us/download/dotnet/6.0
    ```
4. Now type: 
```powershell
dotnet run AdorableCats.csproj
```
5. Go to following url in your webbrowser:
```powershell
https://localhost:7263/swagger/
```


