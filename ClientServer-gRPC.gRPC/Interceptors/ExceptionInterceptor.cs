using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Interceptors;

/// <summary>
///     Interceptor to handle exceptions for gRPC methods.
/// </summary>
public class ExceptionInterceptor : Interceptor
{
    /// <inheritdoc />
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (Exception ex)
        {
            ExceptionHandle<TRequest, TResponse>(ex);
            throw;
        }
    }

    /// <inheritdoc />
    public override async Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(
        IAsyncStreamReader<TRequest> requestStream,
        ServerCallContext context,
        ClientStreamingServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(requestStream, context);
        }
        catch (Exception ex)
        {
            ExceptionHandle<TRequest, TResponse>(ex);
            throw;
        }
    }

    /// <inheritdoc />
    public override async Task ServerStreamingServerHandler<TRequest, TResponse>(
        TRequest request,
        IServerStreamWriter<TResponse> responseStream,
        ServerCallContext context,
        ServerStreamingServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            await continuation(request, responseStream, context);
        }
        catch (Exception ex)
        {
            ExceptionHandle<TRequest, TResponse>(ex);
            throw;
        }
    }

    /// <inheritdoc />
    public override async Task DuplexStreamingServerHandler<TRequest, TResponse>(
        IAsyncStreamReader<TRequest> requestStream,
        IServerStreamWriter<TResponse> responseStream,
        ServerCallContext context,
        DuplexStreamingServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            await continuation(requestStream, responseStream, context);
        }
        catch (Exception ex)
        {
            ExceptionHandle<TRequest, TResponse>(ex);
            throw;
        }
    }

    /// <summary>
    ///     Handles exceptions by adding metadata and throwing an RpcException.
    /// </summary>
    /// <typeparam name="TRequest">The type of the gRPC request.</typeparam>
    /// <typeparam name="TResponse">The type of the gRPC response.</typeparam>
    /// <param name="ex">The exception to handle.</param>
    private static void ExceptionHandle<TRequest, TResponse>(Exception ex)
    {
        var correlationId = Guid.NewGuid().ToString();
        Metadata trailers = new Metadata
        {
            { "CorrelationId", correlationId },
            { "Interceptor", "True" }
        };
        throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Server Side Error");
    }
}   