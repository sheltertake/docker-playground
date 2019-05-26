# Download image

docker pull mysql

docker inspect mysql

<pre>
"Volumes": {
    "/var/lib/mysql": {}
}
</pre>

docker volume create --name productdata

<pre>
PS C:\Users\Max\Documents\GIT\docker-playground\dotnet\mvc> docker volume create --name productdata
productdata
PS C:\Users\Max\Documents\GIT\docker-playground\dotnet\mvc> docker volume ls
DRIVER              VOLUME NAME
local               productdata
local               testdata
</pre>

docker run -d --name mysql -v productdata:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=mysecret -e bind-address=0.0.0.0 mysql:8.0.0

<pre>
PS C:\Users\Max\Documents\GIT\docker-playground\dotnet\mvc> docker logs mysql
Initializing database
2019-05-26T19:40:56.045359Z 0 [Warning] TIMESTAMP with implicit DEFAULT value is deprecated. Please use --explicit_defaults_for_timestamp server option (see documentation for more details).
libnuma: Warning: /sys not mounted or invalid. Assuming one node: No such file or directory
mbind: Operation not permitted
mbind: Operation not permitted
2019-05-26T19:40:56.776170Z 1 [Warning] InnoDB: New log files created, LSN=49311
2019-05-26T19:40:57.050763Z 1 [Warning] InnoDB: Creating foreign key constraint system tables.
2019-05-26T19:41:01.612324Z 0 [Warning] No existing UUID has been found, so we assume that this is the first time that this server has been started. Generating a new UUID: 3136b1ea-7fee-11e9-9075-0242ac110002.
2019-05-26T19:41:01.623846Z 0 [Warning] Gtid table is not ready to be used. Table 'mysql.gtid_executed' cannot be opened.
2019-05-26T19:41:01.626761Z 4 [Warning] root@localhost is created with an empty password ! Please consider switching off the --initialize-insecure option.
</pre>