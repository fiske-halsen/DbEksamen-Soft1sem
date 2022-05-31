#!/bin/bash

function f {
cd .. 
cd ..
cd ..
cd ..
}

cd Docker/Postgres-docker
docker-compose up -d
sleep 3
cd ..
cd Neo-docker
docker-compose up -d
sleep 3
cd ..
cd Redis-docker
docker-compose up -d
sleep 3
cd ..

cd Mongo-docker
docker-compose up -d
sleep 15
winpty docker-compose exec configsvr01 sh -c "mongo < /scripts/init-configserver.js"
sleep 5
winpty docker-compose exec shard01-a sh -c "mongo < /scripts/init-shard01.js"
sleep 5
winpty docker-compose exec shard02-a sh -c "mongo < /scripts/init-shard02.js"
sleep 5
winpty docker-compose exec shard03-a sh -c "mongo < /scripts/init-shard03.js"
sleep 5
winpty docker-compose exec router01 sh -c "mongo < /scripts/init-router.js"

cd ..
cd ..
sleep 5

cd Application/PostgresAPI/bin/Debug/net6.0

start PostgresAPI.exe

sleep 5
f

cd MongoAPI/bin/debug/net6.0
start MongoAPI.exe
sleep 5
f
cd Neo4JAPI/bin/debug/net6.0

start Neo4JAPI.exe
sleep 5
f

cd ApiGateway/bin/debug/net6.0

start ApiGateway.exe
sleep 5
f

cd IdentityServer/bin/Debug/net6.0

start IdentityServer.exe



