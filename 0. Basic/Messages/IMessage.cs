using System;

namespace Cobo.Templates.Messages
{
    public interface IMessage
    {
        event Action Receive;
        void Send();
    }

    public interface IMessage<T>
    {
        event Action<T> Receive;
        void Send(T arg);
    }

    public interface IMessage<T0, T1>
    {
        event Action<T0, T1> Receive;
        void Send(T0 arg0, T1 arg1);
    }

    public interface IMessage<T0, T1, T2>
    {
        event Action<T0, T1, T2> Receive;
        void Send(T0 arg0, T1 arg1, T2 arg2);
    }

    public interface IMessage<T0, T1, T2, T3>
    {
        event Action<T0, T1, T2, T3> Receive;
        void Send(T0 arg0, T1 arg1, T2 arg2, T3 arg3);
    }
}