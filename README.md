# gRPC-NetCore

As the world of microservices evolved, the approach and tools around it also evolved. One of the most important aspects of microservices is communication between different services.

One of the approaches for communication that are used is remote procedure call, and gRPC provides a sophisticated framework for it.

gRPC means Google remote procedure call, so it is evident from the name. It was the framework being used by Google before they opened it up to the open-source community. It uses HTTP2 protocol.

It provides a few benefits, such as.

Lightweight messages.
It is Fast.
It provides Full duplex communication.
gRPC is mostly used for internal service communication, but it does have web gRPC that can work on browsers.

Unlike the RESTful services, the client and server both need to be aware of the service signature and message attribute.

It provides flexibility. The client and server can both be implemented in different technology stacks and still be able to communicate seamlessly.

Now, start implementing the gRPC in .Net Core, but before starting the implementation, do remember that the .Net API project can have Rest API and gRPC service together, and in this article, we will add gRPC in the already existing RestFull API Project. 

I am using Mediator and CQRS architecture for Rest API, but you can use any approach.

Follow the Complete tutorial https://www.c-sharpcorner.com/article/implementing-grpc-in-net-core/
