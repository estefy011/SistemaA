#!/usr/bin/env bash
docker build -t auth0-aspnetcore-mvc-03-user-profile .
docker run -it -p 8081:8081 auth0-aspnetcore-mvc-03-user-profile
