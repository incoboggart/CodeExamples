using System;

namespace Cobo.Templates.Messages.Impl.Messages
{
    public sealed class EventMessage : IMessage
    {
        private event Action action;

        #region IMessage members

        event Action IMessage.Receive
        {
            add { action += value; }
            remove { action -= value; }
        }

        void IMessage.Send()
        {
            var e = action;
            if (e != null)
            {
                e();
            }
        }

        #endregion
    }

    public sealed class EventMessage<T> : IMessage<T>
    {
        private event Action<T> action;

        #region IMessage<T> members

        event Action<T> IMessage<T>.Receive
        {
            add { action += value; }
            remove { action -= value; }
        }

        void IMessage<T>.Send(T arg)
        {
            var e = action;

            if (e != null)
            {
                e(arg);
            }
        }

        #endregion
    }

    public sealed class EventMessage<T0, T1> : IMessage<T0, T1>
    {
        private event Action<T0, T1> action;

        #region IMessage<T0, T1> members

        event Action<T0, T1> IMessage<T0, T1>.Receive
        {
            add { action += value; }
            remove { action -= value; }
        }

        void IMessage<T0, T1>.Send(T0 arg0, T1 arg1)
        {
            var e = action;

            if (e != null)
            {
                e(arg0, arg1);
            }
        }

        #endregion
    }

    public sealed class EventMessage<T0, T1, T2> : IMessage<T0, T1, T2>
    {
        private event Action<T0, T1, T2> action;

        #region IMessage<T0, T1, T2> members

        event Action<T0, T1, T2> IMessage<T0, T1, T2>.Receive
        {
            add { action += value; }
            remove { action -= value; }
        }

        void IMessage<T0, T1, T2>.Send(T0 arg0, T1 arg1, T2 arg2)
        {
            var e = action;

            if (e != null)
            {
                e(arg0, arg1, arg2);
            }
        }

        #endregion
    }

    public sealed class EventMessage<T0, T1, T2, T3> : IMessage<T0, T1, T2, T3>
    {
        private event Action<T0, T1, T2, T3> action;

        #region IMessage<T0, T1, T2, T3> members

        event Action<T0, T1, T2, T3> IMessage<T0, T1, T2, T3>.Receive
        {
            add { action += value; }
            remove { action -= value; }
        }

        void IMessage<T0, T1, T2, T3>.Send(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            var e = action;

            if (e != null)
            {
                e(arg0, arg1, arg2, arg3);
            }
        }

        #endregion
    }
}