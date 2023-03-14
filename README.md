# gRPC for .NET Examples

Examples of basic gRPC scenarios with gRPC for .NET.

If you are brand new to gRPC on .NET a good place to start is the getting started tutorial: [Create a gRPC client and server in ASP.NET Core](https://docs.microsoft.com/aspnet/core/tutorials/grpc/grpc-start)

**NOTE:** The example projects use version numbers from [dependencies.props](../build/dependencies.props) when referencing packages. For example: `<PackageReference Include="Grpc.Net.Client" Version="$(GrpcDotNetPackageVersion)" />`. Example projects that are copied outside of the repository must update package versions to run correctly.

## [Greeter](./Greeter)

The greeter shows how to create unary (non-streaming) gRPC methods in ASP.NET Core, and call them from a client.

##### Scenarios:

* Unary call

## [Counter](./Counter)

The counter shows how to create unary (non-streaming), client streaming and server streaming gRPC methods in ASP.NET Core, and call them from a client.

##### Scenarios:

* Unary call
* Client streaming call
* Server streaming call

## [Mailer](./Mailer)

The mailer shows how to create a bi-directional streaming gRPC method in ASP.NET Core and call it from a client. The server reacts to messages sent from the client.

##### Scenarios:

* Bi-directional streaming call

## [Interceptor](./Interceptor)

The interceptor shows how to use gRPC interceptors on the client and server. The client interceptor adds additional metadata to each call and the server interceptor logs that metadata on the server.

##### Scenarios:

* Creating a client interceptor
* Using a client interceptor
* Creating a server interceptor
* Using a server interceptor

## [Racer](./Racer)

The racer shows how to create a bi-directional streaming gRPC method in ASP.NET Core and call it from a client. The client and the server each send messages as quickly as possible.

##### Scenarios:

* Bi-directional streaming call

## [Ticketer](./Ticketer)

The ticketer shows how to use gRPC with [authentication and authorization in ASP.NET Core](https://docs.microsoft.com/aspnet/core/security). This example has a gRPC method marked with an `[Authorize]` attribute. The client can only call the method if it has been authenticated by the server and passes a valid JWT token with the gRPC call.

##### Scenarios:

* JSON web token authentication
* Send JWT token with call
* Authorization with `[Authorize]` on service

## [Reflector](./Reflector)

The reflector shows how to host the [gRPC Server Reflection Protocol](https://github.com/grpc/grpc/blob/master/doc/server-reflection.md) service and call its methods from a client.

##### Scenarios:

* Hosting gRPC Server Reflection Protocol service
* Calling service with `Grpc.Reflection` client

## [Certifier](./Certifier)

The certifier shows how to configure the client and the server to use a [TLS client certificate](https://blogs.msdn.microsoft.com/kaushal/2015/05/27/client-certificate-authentication-part-1/) with a gRPC call. The server is configured to require a client certificate using [ASP.NET Core client certificate authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/certauth).

> **NOTE:** client.pfx is a self-signed certificate. When running the client you may get an error that the certificate is not trusted: `The certificate chain was issued by an authority that is not trusted`. [Add the certificate](https://www.thesslstore.com/knowledgebase/ssl-install/how-to-import-intermediate-root-certificates-using-mmc/) to your computer's trusted root cert store to fix this error. Don't use this certificate in production environments.

##### Scenarios:

* Client certificate authentication
* Send client certificate with call
* Receive client certificate in a service
* Authorization with `[Authorize]` on service

## [Worker](./Worker)

The worker shows how to use call a gRPC server with a [.NET worker service](https://docs.microsoft.com/aspnet/core/fundamentals/host/hosted-services). The client uses the worker service to make a gRPC call on a timed internal. The gRPC client factory is used to create a client, which is injected into the service using dependency injection.

The server is configured as a normal .NET web app, which uses the same [generic host](https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host) as a worker service to host its web server.

The client or server can be run as a [Windows service](https://en.wikipedia.org/wiki/Windows_service) or [systemd service](https://www.freedesktop.org/wiki/Software/systemd/) with some minor changes to the project file and startup logic:

* [.NET Core Workers as Windows Services](https://devblogs.microsoft.com/aspnet/net-core-workers-as-windows-services/)
* [.NET Core and systemd](https://devblogs.microsoft.com/dotnet/net-core-and-systemd/)

##### Scenarios:

* Worker service
* Client factory

## [Aggregator](./Aggregator)

The aggregator shows how a to make nested gRPC calls (a gRPC service calling another gRPC service). The gRPC client factory is used in ASP.NET Core to inject a client into services. The gRPC client factory is configured to propagate the context from the original call to the nested call. In this example the cancellation from the client will automatically propagate through to nested gRPC calls.

The aggregator can optionally be run with [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet) enabled. OpenTelemetry is configured to capture tracing information and send it to [Zipkin](https://zipkin.io), a distributed tracing system. A Zipkin server needs to be running to receive traces. The simplest way to do that is [run the Zipkin Docker image](https://zipkin.io/pages/quickstart.html).

To run the aggregator server with OpenTelemetry enabled:

```console
dotnet run --EnableOpenTelemetry=true
```

##### Scenarios:

* Client factory
* Client canceling a call
* Cancellation propagation
* Capture tracing with [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet) (optional)

## [Tester](./Tester)

The tester shows how to test gRPC services. The unit tests create and test a gRPC service directly. The functional tests show how to use [Microsoft.AspNetCore.TestHost](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost/) (version 3.1.2 or greater required) to host a gRPC service with an in-memory test server and call it using a gRPC client. The functional tests write client and server logs to the test output.

The tests also show how to mock a gRPC client when testing gRPC client apps.

##### Scenarios:

* Unit testing
* Functional testing
* Mocking gRPC client

## [Progressor](./Progressor)

The progressor shows how to use server streaming to notify the caller about progress on the server.

##### Scenarios:

* Server streaming
* Using [`Progress<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.progress-1) to notify progress on the client

## [Vigor](./Vigor)

The vigor example shows how to integrate [ASP.NET Core health checks](https://docs.microsoft.com/aspnet/core/host-and-deploy/health-checks) with the [gRPC Health Checking Protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md) service, and call its methods from a client.

##### Scenarios:

* Hosting gRPC Health Checking Protocol service
* Integrate [ASP.NET Core health checks](https://docs.microsoft.com/aspnet/core/host-and-deploy/health-checks) with gRPC health checks
* Calling service with `Grpc.HealthCheck` client

## [Compressor](./Compressor)

The compressor example shows how to enable compression of gRPC request and response messages using gzip.

> **IMPORTANT:** Using compression with dynamically generated content can lead to security problems such as the [CRIME](https://wikipedia.org/wiki/CRIME_(security_exploit)) and [BREACH](https://wikipedia.org/wiki/BREACH_(security_exploit)) attacks.

##### Scenarios:

* Compression of request messages. gRPC clients should use the `grpc-internal-encoding-request` metadata value.
* Compression of response messages. gRPC services should configure the `ResponseCompressionAlgorithm` setting.

## [Liber](./Liber)

The liber example shows how to add Protobuf messages to a shared .NET project. Sharing generated messages is an alternative to each project generating their own copy. Protobuf messages in a shared project makes it easier to write reusable libraries that use messages.

This example has two proto files:

* *common.proto* contains a common `Name` message type.
* *greet.proto* has a service definition. It imports *common.proto* and uses the `Name` message.

The `Name` .NET type is generated from *common.proto* in the common project and is shared throughout the solution:

* *Common.csproj* uses Grpc.Tools to generate messages contained in *common.proto*.
* *Client.csproj* uses Grpc.Tools to generate the gRPC client for *greet.proto*. There is no `<Protobuf>` reference for *common.proto* because we don't want its messages generated in this project. Instead the .NET types for its messages are referenced from the common project.
* *Server.csproj* uses Grpc.Tools to generate the gRPC service for *greet.proto*. It also references the common project.

##### Scenarios:

* Add Protobuf messages to shared .NET projects
* Use shared messages in gRPC services

## [Browser](./Browser)

The browser example shows how to use [gRPC-Web](https://github.com/grpc/grpc-web) with ASP.NET Core to call a gRPC service from a browser. Browser apps have limited HTTP/2 features and need to use gRPC-Web instead. This example requires [npm and NodeJS](https://nodejs.org/) to be installed on your computer.

The gRPC-Web JavaScript client was generated from *greet.proto* using [`protoc`](https://github.com/protocolbuffers/protobuf/releases) with the [`protoc-gen-grpc-web`](https://github.com/grpc/grpc-web/releases) plugin.

##### Scenarios:

* Configure ASP.NET Core server to support `grpc-web` and `grpc-web-text` content types
* Call gRPC services with JavaScript from a browser

## [Blazor](./Blazor)

The blazor example shows how to call a gRPC service from a Blazor WebAssembly app. Because Blazor WebAssembly is hosted in the browser it has limited HTTP/2 features and needs to use gRPC-Web instead.

##### Scenarios:

* Configure ASP.NET Core server to support `grpc-web` and `grpc-web-text` content types
* Configure .NET gRPC client in Blazor to use gRPC-Web
* Get service address using `IConfiguration` and `appsettings.json`
* Call gRPC services with Blazor WebAssembly from a browser

## [Spar](./Spar)

The spar example shows how to call a gRPC service from a single page application (SPA) and make cross-origin gRPC-Web requests. The SPA uses [Vue.js](https://vuejs.org/) and [gRPC-Web](https://github.com/grpc/grpc-web). The server is configured to support [Cross Origin Resource Sharing (CORS)](https://docs.microsoft.com/aspnet/core/security/cors). This example requires [npm and NodeJS](https://nodejs.org/) to be installed on your computer.

The gRPC-Web JavaScript client was generated from *greet.proto* using [`protoc`](https://github.com/protocolbuffers/protobuf/releases) with the [`protoc-gen-grpc-web`](https://github.com/grpc/grpc-web/releases) plugin.

##### Scenarios:

* Configure ASP.NET Core server to support `grpc-web` and `grpc-web-text` content types
* Configure ASP.NET Core server to enable gRPC-Web cross-origin requests (CORS)
* Call gRPC services with JavaScript from a SPA

## [Transcoder](./Transcoder)

The transcoder shows how to use [gRPC JSON transcoding](https://docs.microsoft.com/aspnet/core/grpc/httpapi) to generate RESTful APIs from gRPC services.

##### Scenarios:

* gRPC JSON transcoding

## [Transporter](./Transporter)

**Requirements:**
* .NET 5 or later
* Linux, MacOS or a [modern version of Windows](https://devblogs.microsoft.com/commandline/af_unix-comes-to-windows/)

The transporter example shows how to use gRPC over non-TCP transports. This example uses a [Unix domain socket (UDS)](https://en.wikipedia.org/wiki/Unix_domain_socket) to send gRPC messages between the client and server.

To use gRPC with UDS:

1. The client creates a channel with a `ConnectCallback`. The callback connects to a specified UDS endpoint.
2. The server configures a UDS endpoint with [KestrelServerOptions.ListenUnixSocket](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.server.kestrel.core.kestrelserveroptions.listenunixsocket) in *Program.cs*.

##### Scenarios:

* Unix domain sockets
* SocketsHttpHandler.ConnectCallback
* [KestrelServerOptions.ListenUnixSocket](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.server.kestrel.core.kestrelserveroptions.listenunixsocket)

## [Coder](./Coder)

The coder example shows how to create a code-first gRPC service and client. This example uses [protobuf-net.Grpc](https://github.com/protobuf-net/protobuf-net.Grpc), a community project that adds code-first support to `Grpc.AspNetCore` and `Grpc.Net.Client`.

Code-first is a good choice if an app is written entirely in .NET. Code contracts can't be used by other languages and cross-platform apps should use *.proto* contracts.

##### Scenarios:

* Configure [protobuf-net.Grpc](https://github.com/protobuf-net/protobuf-net.Grpc)
* Create a code-first gRPC service
* Create a code-first gRPC client

## [Retrier](./Retrier)

The retrier example shows how to configure a client to use gRPC retries to retry failed calls. gRPC retries enables resilient, fault tolerant gRPC apps in .NET.

##### Scenarios:

* Configure [gRPC retries](https://docs.microsoft.com/aspnet/core/grpc/retries)

## [Container](./Container)

The container example shows how to create a gRPC Kubernetes app. There are two containers in the example: a Blazor Server frontend, and a gRPC server backend with multiple replicas. The frontend uses gRPC client-side load balancing to call backend instances.

##### Scenarios:

* [Kubernetes](https://kubernetes.io/)
* Configure [gRPC client-side load balancing](https://docs.microsoft.com/aspnet/core/grpc/loadbalancing)

## [Uploader](./Uploader)

The uploader shows how to upload a file in chunks using a client streaming gRPC method.

##### Scenarios:

* Client streaming call
* Binary payload

## [Downloader](./Downloader)

The downloader shows how to download a file in chunks using a server streaming gRPC method.

##### Scenarios:

* Server streaming
* Binary payload

## [Locator](./Locator)

The locator shows how to add host constraints to gRPC services. This example adds two services:

* Internal gRPC service is only accessible over port 5001.
* External gRPC service is only accessible over port 5000.

##### Scenarios:

* [`RequireHost`](https://docs.microsoft.com/aspnet/core/fundamentals/routing#host-matching-in-routes-with-requirehost)

## [Channeler](./Channeler)

The channeler shows how to use `System.Threading.Channels` to safely read and write gRPC messages from multiple background tasks.

##### Scenarios:

* [`System.Threading.Channels`](https://docs.microsoft.com/dotnet/core/extensions/channels)
* Multi-threaded gRPC methods
* Server streaming
* Client streaming

## [Frameworker](./Frameworker)

The frameworker shows how to call gRPC services from a .NET Framework client using `WinHttpHandler`.

##### Scenarios:

* .NET Framework
* [`WinHttpHandler`](https://docs.microsoft.com/dotnet/api/system.net.http.winhttphandler)


# gRPC for .NET

gRPC is a modern, open source, high-performance remote procedure call (RPC) framework that can run anywhere. gRPC enables client and server applications to communicate transparently, and simplifies the building of connected systems.

gRPC functionality for .NET Core 3.0 or later includes:

* [Grpc.AspNetCore](https://www.nuget.org/packages/Grpc.AspNetCore) &ndash; An ASP.NET Core framework for hosting gRPC services. gRPC on ASP.NET Core integrates with standard ASP.NET Core features like logging, dependency injection (DI), authentication and authorization.
* [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) &ndash; A gRPC client for .NET Core that builds upon the familiar `HttpClient`. The client uses new HTTP/2 functionality in .NET Core.
* [Grpc.Net.ClientFactory](https://www.nuget.org/packages/Grpc.Net.ClientFactory) &ndash; gRPC client integration with `HttpClientFactory`. The client factory allows gRPC clients to be centrally configured and injected into your app with DI.

For more information, see [An introduction to gRPC on .NET](https://docs.microsoft.com/aspnet/core/grpc/).

## gRPC for .NET is now the recommended implementation!

Starting from May 2021, gRPC for .NET is the recommended implemention of gRPC for C#. The original [gRPC for C#](https://github.com/grpc/grpc/tree/master/src/csharp) implementation (distributed as the `Grpc.Core` nuget package) is now in maintenance mode and will be deprecated in the future.
See [blogpost](https://grpc.io/blog/grpc-csharp-future/) for more details.

## To start using gRPC for .NET

The best place to start using gRPC for .NET is the gRPC template that comes with .NET Core 3.0 or later. Use the template to [create a gRPC service website and client](https://docs.microsoft.com/aspnet/core/tutorials/grpc/grpc-start).

For additional examples of using gRPC in .NET refer to https://github.com/grpc/grpc-dotnet/tree/master/examples.

## gRPC NuGet feed

Official versions of gRPC are published to [NuGet.org](https://www.nuget.org/profiles/grpc-packages). This is the recommended place for most developers to get gRPC packages.

Nightly versions of gRPC for ASP.NET Core are published to the gRPC NuGet repository at https://grpc.jfrog.io/grpc/api/nuget/v3/grpc-nuget-dev. It is recommended to use a nightly gRPC package if you are using a nightly version of .NET Core, and vice-versa. There may be incompatibilities between .NET Core and gRPC for ASP.NET Core if a newer version of one is used with an older version of the other.

To use the gRPC NuGet repository and get the latest packages from it, place a `NuGet.config` file with the gRPC repository setup in your solution folder:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <!-- Add this repository to the list of available repositories -->
        <add key="gRPC repository" value="https://grpc.jfrog.io/grpc/api/nuget/v3/grpc-nuget-dev" />
    </packageSources>
</configuration>
```

Additional instructions for configuring a project to use a custom NuGet repository are available at [Changing NuGet configuration settings](https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior#changing-config-settings).

## To develop gRPC for ASP.NET Core

Installing .NET Core SDK:
```
# Run this script before building the project.
./build/get-dotnet.sh or ./build/get-dotnet.ps1
```

Set up the development environment to use the installed .NET Core SDK:
```
# Source this script to use the installed .NET Core SDK.
source ./activate.sh or . ./activate.ps1
```
To launch Visual Studio with the installed SDK:
```
# activate.sh or activate.ps1 must be sourced first, see previous step
startvs.cmd
```

To build from the command line:
```
dotnet build Grpc.DotNet.sln
```

To run tests from the command line:
```
dotnet test Grpc.DotNet.sln
```

## To contribute

Contributions are welcome!

General rules for [contributing to the gRPC project](https://github.com/grpc/grpc/blob/master/CONTRIBUTING.md) apply for this repository.
