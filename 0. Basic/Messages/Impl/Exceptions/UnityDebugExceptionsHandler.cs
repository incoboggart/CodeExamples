using System;
using System.Text;

using UnityEngine;

namespace Cobo.Templates.Messages.Impl.Exceptions
{
    public sealed class UnityDebugExceptionsHandler : IExceptionsHandler
    {
        private const String Format = "Catched exception sending message {0}()";

        void IExceptionsHandler.ExceptionCatched(IMessage message, Exception exception)
        {
            Debug.LogError(new StringBuilder().AppendFormat(Format, message).ToString());
            Debug.LogException(exception);
        }
    }

    public sealed class UnityDebugExceptionsHandler<T> : IExceptionsHandler<T>
    {
        private const String Format = "Catched exception sending message {0}({1})";

        void IExceptionsHandler<T>.ExceptionCatched(IMessage<T> message, T arg, Exception exception)
        {
            Debug.LogError(new StringBuilder().AppendFormat(Format, message, arg).ToString());
            Debug.LogException(exception);
        }
    }

    public sealed class UnityDebugExceptionsHandler<T0, T1> : IExceptionsHandler<T0, T1>
    {
        private const String Format = "Catched exception sending message {0}({1}, {2})";

        void IExceptionsHandler<T0, T1>.ExceptionCatched(IMessage<T0, T1> message, T0 arg, T1 arg1, Exception exception)
        {
            Debug.LogError(new StringBuilder().AppendFormat(Format, message, arg, arg1).ToString());
            Debug.LogException(exception);
        }
    }

    public sealed class UnityDebugExceptionsHandler<T0, T1, T2> : IExceptionsHandler<T0, T1, T2>
    {
        private const String Format = "Catched exception sending message {0}({1}, {2}, {3})";

        void IExceptionsHandler<T0, T1, T2>.ExceptionCatched(IMessage<T0, T1, T2> message, T0 arg, T1 arg1, T2 arg2,
            Exception exception)
        {
            Debug.LogError(new StringBuilder().AppendFormat(Format, message, arg, arg1, arg2).ToString());
            Debug.LogException(exception);
        }
    }

    public sealed class UnityDebugExceptionsHandler<T0, T1, T2, T3> : IExceptionsHandler<T0, T1, T2, T3>
    {
        private const String Format = "Catched exception sending message {0}({1}, {2}, {3}, {4})";

        void IExceptionsHandler<T0, T1, T2, T3>.ExceptionCatched(IMessage<T0, T1, T2, T3> message, T0 arg, T1 arg1,
            T2 arg2, T3 arg3, Exception exception)
        {
            Debug.LogError(new StringBuilder().AppendFormat(Format, message, arg, arg1, arg2, arg3).ToString());
            Debug.LogException(exception);
        }
    }
}