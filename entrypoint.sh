#!/bin/bash

echo "Db migration start:" `date`
until dotnet ef database update; do
>&2 echo "SQL Server is starting up"
sleep 1
done

echo "Hera app start:" `date`
dotnet /app/Hera.WebApi.dll



