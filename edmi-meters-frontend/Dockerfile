FROM node:14.15.5 as builder

RUN mkdir /usr/src/app 
 
WORKDIR /usr/src/app

RUN npm install -g @angular/cli

COPY . . 