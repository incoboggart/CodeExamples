using System;

namespace Cobo.Templates.Messages.Impl.Exceptions
{
    public sealed class SupressExceptionsHandler : IExceptionsHandler
    {
        private static SupressExceptionsHandler _instance;

        public static SupressExceptionsHandler Instance
        {
            get { return _instance ?? (_instance = new SupressExceptionsHandler()); }
        }

        void IExceptionsHandler.ExceptionCatched(IMessage message, Exception exception)
        {
        }
    }

    public sealed class SupressExceptionsHandler<T> : IExceptionsHandler<T>
    {
        private static SupressExceptionsHandler<T> _instance;

        public static SupressExceptionsHandler<T> Instance
        {
            get { return _instance ?? (_instance = new SupressExceptionsHandler<T>()); }
        }

        void IExceptionsHandler<T>.ExceptionCatched(IMessage<T> message, T arg, Exception exception)
        {
        }
    }

    public sealed class SupressExceptionsHandler<T0, T1> : IExceptionsHandler<T0, T1>
    {
        private static SupressExceptionsHandler<T0, T1> _instance;

        public static SupressExceptionsHandler<T0, T1> Instance
        {
            get { return _instance ?? (_instance = new SupressExceptionsHandler<T0, T1>()); }
        }

        void IExceptionsHandler<T0, T1>.ExceptionCatched(IMessage<T0, T1> message, T0 arg, T1 arg1, Exception exception)
        {
        }
    }

    public sealed class SupressExceptionsHandler<T0, T1, T2> : IExceptionsHandler<T0, T1, T2>
    {
        private static SupressExceptionsHandler<T0, T1, T2> _instance;

        public static SupressExceptionsHandler<T0, T1, T2> Instance
        {
            get { return _instance ?? (_instance = new SupressExceptionsHandler<T0, T1, T2>()); }
        }

        void IExceptionsHandler<T0, T1, T2>.ExceptionCatched(IMessage<T0, T1, T2> message, T0 arg, T1 arg1, T2 arg2,
            Exception exception)
        {
        }
    }

    public sealed class SupressExceptionsHandler<T0, T1, T2, T3> : IExceptionsHandler<T0, T1, T2, T3>
    {
        private static SupressExceptionsHandler<T0, T1, T2, T3> _instance;

        public static SupressExceptionsHandler<T0, T1, T2, T3> Instance
        {
            get { return _instance ?? (_instance = new SupressExceptionsHandler<T0, T1, T2, T3>()); }
        }

        void IExceptionsHandler<T0, T1, T2, T3>.ExceptionCatched(IMessage<T0, T1, T2, T3> message, T0 arg, T1 arg1,
            T2 arg2, T3 arg3,
            Exception exception)
        {
        }
    }
}