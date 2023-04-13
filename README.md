# AdorableCats
Cats are cute, and many people love them. The world, especially now, could use more positivity, so we want to create a smooth, endless feed of adorable cat pictures.

# Running the Web API

## Starting up the API with Docker

Make sure you have [installed](https://docs.docker.com/docker-for-windows/install/) docker in your environment. After that, you can run the below commands from the **/AdorableCats** directory and get started with the `AdorableCats Web API` immediately.

```powershell
docker-compose build
docker-compose up
```

## Now you can use the AdorableCats Web API

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


