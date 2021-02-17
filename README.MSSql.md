https://docs.microsoft.com/it-it/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash

docker pull mcr.microsoft.com/mssql/server:2019-GA-ubuntu-16.04

docker volume create mssql 

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" -p 1433:1433 -v mssql:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2019-GA-ubuntu-16.04