# docker-playground

# list docker images

docker images

# download image

docker pull hello-world

# run and remove automatically 

docker run --rm hello-world

# download linux alpine image

docker pull alpine

# browse versions alpine image (current 3.9)

https://hub.docker.com/_/alpine

# download specific version (latest)
<code>
docker pull alpine:3.9
</code>

### the image id is the same
<pre>
PS C:\Users\Max> docker images
REPOSITORY          TAG                 IMAGE ID            CREATED             SIZE
alpine              3.9                 055936d39205        2 weeks ago         5.53MB
alpine              latest              055936d39205        2 weeks ago         5.53MB
hello-world         latest              fce289e99eb9        4 months ago        1.84kB
</pre>

Remove all images
<pre>
docker rmi -f $(docker images -q)
</pre>

Create container

<pre>
docker create --rm --name name org/image
</pre>

Start container

<pre>
docker start name
</pre>