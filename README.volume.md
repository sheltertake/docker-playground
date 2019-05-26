
# Docker volumes

Dockerfile-Volumes

<pre>
FROM alpine:latest
WORKDIR /data
ENTRYPOINT (test -e message.txt && echo "File Exists" \
|| (echo "Creating File..." \
&& echo Hello, Docker $(date '+%X') > message.txt)) && cat message.txt
</pre>

Starting from Alpine base image, set the working dir /data, and set as entrypoint of image the linux command that write a file if not exists.
The file message.txt will contain the current timestamp at the moment of the first run.

<pre>
docker build . -t maxbnet/vtest -f .\Dockerfile-Volumes
docker run --name vtest maxbnet/vtest
</pre>

the first line build the image using the current directory (.) and  setting the name maxbnet/vtest (-t organization/name) using the docker file (-f) 

the second line will run the image builded setting the --name vtest using the image maxbnet/vtest

<pre>
PS C:\Users\Max\Documents\GIT\docker-playground\alpine> docker images
REPOSITORY          TAG                 IMAGE ID            CREATED             SIZE
maxbnet/vtest       latest              65b28c7375bb        4 minutes ago       5.53MB
alpine              3.9                 055936d39205        2 weeks ago         5.53MB
alpine              latest              055936d39205        2 weeks ago         5.53MB
hello-world         latest              fce289e99eb9        4 months ago        1.84kB
</pre>

The run command produce this output
<pre>
PS C:\Users\Max\Documenti\GIT\docker-playground\alpine> docker run --name vtest maxbnet/vtest
Creating File...
Hello, Docker 09:17:44
</pre>

The container exit. But is persistent until its deletion. Rerun the image

<pre>
PS C:\Users\Max\Documents\GIT\docker-playground\alpine> docker start -a vtest
File Exists
Hello, Docker 09:17:44
</pre>

Delete container
<pre>
docker rm -f vtest
</pre>

Re run the image
<pre>
PS C:\Users\Max\Documenti\GIT\docker-playground\alpine> docker run --name vtest maxbnet/vtest
Creating File...
Hello, Docker 09:30:23
</pre>

Create a copy of DockerFile adding after the first line the command:

<pre>
VOLUME /data
</pre>

Create a new image (maxbnet/vtest1) using the file with the volume command
<pre>
docker build . -t maxbnet/vtest1 -f .\Dockerfile-Volumes.1
</pre>

Create the volume using docker volume create command
<pre>
PS C:\Users\Max\Documenti\GIT\docker-playground\alpine> docker volume create --name testdata
testdata
</pre>

Run the container using the volume
<pre>
docker run --name vtest1 -v testdata:/data maxbnet/vtest1
</pre>


# Create a volume:

docker volume create testdata

# List volumes:

docker volume ls

# Inspect volume:

docker volume inspect testdata

<pre>
PS C:\Users\Max\Documenti\GIT\docker-playground\alpine> docker volume inspect testdata
[
    {
        "CreatedAt": "2019-05-26T09:37:30Z",
        "Driver": "local",
        "Labels": {},
        "Mountpoint": "/var/lib/docker/volumes/testdata/_data",
        "Name": "testdata",
        "Options": {},
        "Scope": "local"
    }
]
</pre>

The path /var/lib/docker/volumes in windows is:
C:\Users\Public\Documents\Hyper-V\Virtual hard disks

In order to read files you can run an alpine mounting the volume into /data and then ls the folder
<pre>
PS C:\Users\Max\Documenti\GIT\docker-playground\alpine> docker run --rm -v testdata:/data alpine ls /data
message.txt
</pre>

In order to write files in local disk we have to share disk on Docker settings.
We must have a user with password

After remotion and rerun the image with volume setted 
<pre>
docker ps -a
docker rm vtest1
docker run --name vtest1 -v testdata:/data maxbnet/vtest1
</pre>

will print:
<pre>
PS C:\Users\Max\Documenti\GIT\docker-playground\alpine> docker run --name vtest1 -v testdata:/data maxbnet/vtest1
File Exists
Hello, Docker 09:37:30
</pre>

If I use the docker image without volume:
<pre>
PS C:\Users\Max\Documenti\GIT\docker-playground\alpine> docker rm vtest
vtest
PS C:\Users\Max\Documenti\GIT\docker-playground\alpine> docker run --name vtest maxbnet/vtest
Creating File...
Hello, Docker 10:15:17
</pre>

# Write local disk

Create/Run alpine container with --rm flag and -it option mounting c:/docker (notice the /) on /data
and launching /bin/ash the shell installed in the alpine image
<pre>
PS C:\Users\Max\Documenti\GIT\docker-playground\alpine> docker run --rm -it  -v c:/docker:/data alpine /bin/ash
</pre>

Inside
<pre>
/ # ls
bin    data   dev    etc    home   lib    media  mnt    opt    proc   root   run    sbin   srv    sys    tmp    usr    var
/ # cd data
/data # ls
mysql
/data # echo 'test' > test.txt
</pre>