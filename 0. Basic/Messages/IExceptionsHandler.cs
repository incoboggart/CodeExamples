using System;

namespace Cobo.Templates.Messages
{
    public interface IExceptionsHandler
    {
        void ExceptionCatched(IMessage message, Exception exception);
    }

    public interface IExceptionsHandler<TArg0>
    {
        void ExceptionCatched(IMessage<TArg0> message, TArg0 arg, Exception exception);
    }

    public interface IExceptionsHandler<TArg0, TArg1>
    {
        void ExceptionCatched(IMessage<TArg0, TArg1> message, TArg0 arg, TArg1 arg1, Exception exception);
    }

    public interface IExceptionsHandler<TArg0, TArg1, TArg2>
    {
        void ExceptionCatched(IMessage<TArg0, TArg1, TArg2> message, TArg0 arg, TArg1 arg1, TArg2 arg2,
            Exception exception);
    }

    public interface IExceptionsHandler<TArg0, TArg1, TArg2, TArg3>
    {
        void ExceptionCatched(IMessage<TArg0, TArg1, TArg2, TArg3> message, TArg0 arg, TArg1 arg1, TArg2 arg2,
            TArg3 arg3, Exception exception);
    }
}