#!/bin/bash


cd Postgres-docker
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







