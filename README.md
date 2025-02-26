# AzServiceBusEmulator


## Introduction

Testing Azure Service Bus is a pain. 

***"The Azure Service Bus emulator offers a local development experience for the Service bus service. You can use the emulator to develop and test code against the service in isolation, free from cloud interference." (by MS)***

In this Project we will see how to use the Azure Service Bus Emulator to test messaging.

See also: 
- [Azure Service Bus Emulator](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messaging-overview)
- [Nick Chapsas - Azure Service Bus Emulator](https://www.youtube.com/watch?v=NPF4iF58P-c)]


## Start the Azure Service Bus Emulator

``` bash
# build and start the docker container
docker-compose up -d
```