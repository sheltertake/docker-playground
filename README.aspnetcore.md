# Dotnetcore MVC:
<pre>
dotnet new mvc --no-https=true --auth=none
docker pull mcr.microsoft.com/dotnet/core/aspnet:2.2
dotnet publish --configuration Release --output dist
</pre>

# Dockerfile

<pre>
FROM mcr.microsoft.com/dotnet/core/aspnet
COPY dist /app
WORKDIR /app
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "mvc.dll"]
</pre>

# Create image

<pre>
docker build . -t maxbnet/mvc -f Dockerfile
</pre>

list images:

<pre>
PS C:\Users\Max\Documenti\GIT\docker-playground> docker images
REPOSITORY                             TAG                 IMAGE ID            CREATED             SIZE
maxbnet/mvc                            latest              72955c0778fb        15 seconds ago      265MB
mcr.microsoft.com/dotnet/core/aspnet   2.2                 f6d51449c477        4 days ago          260MB
mcr.microsoft.com/dotnet/core/aspnet   latest              f6d51449c477        4 days ago          260MB
</pre>

# Create Container 1

<pre>
docker run --rm -p 3000:80 --name mvc3000 maxbnet/mvc
</pre>

If:
docker.exe: Error response from daemon: driver failed programming external connectivity on endpoint mvc3000

Restart docker

# Create Container 2

<pre>
docker run --rm -p 4000:80 --name mvc4000 maxbnet/mvc
</pre>

listing images and containers

<pre>
PS C:\Users\Max> docker images
REPOSITORY                             TAG                 IMAGE ID            CREATED             SIZE
maxbnet/mvc                            latest              72955c0778fb        10 minutes ago      265MB
mcr.microsoft.com/dotnet/core/aspnet   2.2                 f6d51449c477        4 days ago          260MB
mcr.microsoft.com/dotnet/core/aspnet   latest              f6d51449c477        4 days ago          260MB
docker4w/nsenter-dockerd               latest              2f1c802f322f        7 months ago        187kB
PS C:\Users\Max> docker ps
CONTAINER ID        IMAGE               COMMAND             CREATED              STATUS              PORTS                  NAMES
8b75d5b93b8a        maxbnet/mvc         "dotnet mvc.dll"    About a minute ago   Up 58 seconds       0.0.0.0:4000->80/tcp   mvc4000
e1649522ba22        maxbnet/mvc         "dotnet mvc.dll"    3 minutes ago        Up 3 minutes        0.0.0.0:3000->80/tcp   mvc3000
</pre>

# Removing first mvc impl

<pre>
PS C:\Users\Max> docker stop mvc3000
mvc3000
PS C:\Users\Max> docker stop mvc4000
mvc4000
PS C:\Users\Max> docker rmi -f $(docker images -q)
</pre>   

# Rebuild docker

<pre>
dotnet publish --configuration Release --output dist
docker build . -t maxbnet/mvc -f Dockerfile
docker run --rm -p 3000:80 --name mvc3000 maxbnet/mvc
docker run --rm -p 4000:80 --name mvc4000 maxbnet/mvc
</pre>