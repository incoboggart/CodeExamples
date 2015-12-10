using Cobo.Templates.Messages.Impl.Exceptions;

namespace Cobo.Templates.Messages.Extensions
{
    public static class ExceptionsHandlingExtensions
    {
        public static IMessage HandleExceptions(this IMessage message, IExceptionsHandler exceptionsHandler)
        {
            return new TryCatchMessage(message, exceptionsHandler);
        }

        public static IMessage<T> HandleExceptions<T>(this IMessage<T> message, IExceptionsHandler<T> exceptionsHandler)
        {
            return new TryCatchMessage<T>(message, exceptionsHandler);
        }

        public static IMessage<T0, T1> HandleExceptions<T0, T1>(this IMessage<T0, T1> message,
            IExceptionsHandler<T0, T1> exceptionsHandler)
        {
            return new TryCatchMessage<T0, T1>(message, exceptionsHandler);
        }

        public static IMessage<T0, T1, T2> HandleExceptions<T0, T1, T2>(this IMessage<T0, T1, T2> message,
            IExceptionsHandler<T0, T1, T2> exceptionsHandler)
        {
            return new TryCatchMessage<T0, T1, T2>(message, exceptionsHandler);
        }

        public static IMessage<T0, T1, T2, T3> HandleExceptions<T0, T1, T2, T3>(this IMessage<T0, T1, T2, T3> message,
            IExceptionsHandler<T0, T1, T2, T3> exceptionsHandler)
        {
            return new TryCatchMessage<T0, T1, T2, T3>(message, exceptionsHandler);
        }

        public static IMessage SupressExceptions(this IMessage message)
        {
            return message.HandleExceptions(new SupressExceptionsHandler());
        }

        public static IMessage<T> SupressExceptions<T>(this IMessage<T> message)
        {
            return message.HandleExceptions(new SupressExceptionsHandler<T>());
        }

        public static IMessage<T0, T1> SupressExceptions<T0, T1>(this IMessage<T0, T1> message)
        {
            return message.HandleExceptions(new SupressExceptionsHandler<T0, T1>());
        }

        public static IMessage<T0, T1, T2> SupressExceptions<T0, T1, T2>(this IMessage<T0, T1, T2> message)
        {
            return message.HandleExceptions(new SupressExceptionsHandler<T0, T1, T2>());
        }

        public static IMessage<T0, T1, T2, T3> SupressExceptions<T0, T1, T2, T3>(this IMessage<T0, T1, T2, T3> message)
        {
            return message.HandleExceptions(new SupressExceptionsHandler<T0, T1, T2, T3>());
        }
    }
}