// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/animals.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ZooAnimals {
  public static partial class GrpcAnimals
  {
    static readonly string __ServiceName = "GrpcAnimals";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::ZooAnimals.GetAllRequest> __Marshaller_GetAllRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ZooAnimals.GetAllRequest.Parser));
    static readonly grpc::Marshaller<global::ZooAnimals.AnimalsResponse> __Marshaller_AnimalsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ZooAnimals.AnimalsResponse.Parser));

    static readonly grpc::Method<global::ZooAnimals.GetAllRequest, global::ZooAnimals.AnimalsResponse> __Method_GetAllAnimals = new grpc::Method<global::ZooAnimals.GetAllRequest, global::ZooAnimals.AnimalsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllAnimals",
        __Marshaller_GetAllRequest,
        __Marshaller_AnimalsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ZooAnimals.AnimalsReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of GrpcAnimals</summary>
    [grpc::BindServiceMethod(typeof(GrpcAnimals), "BindService")]
    public abstract partial class GrpcAnimalsBase
    {
      public virtual global::System.Threading.Tasks.Task<global::ZooAnimals.AnimalsResponse> GetAllAnimals(global::ZooAnimals.GetAllRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GrpcAnimalsBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAllAnimals, serviceImpl.GetAllAnimals).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GrpcAnimalsBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAllAnimals, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ZooAnimals.GetAllRequest, global::ZooAnimals.AnimalsResponse>(serviceImpl.GetAllAnimals));
    }

  }
}
#endregion
