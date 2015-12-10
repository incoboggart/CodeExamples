using System;

namespace Cobo.Templates.Messages.Impl.Exceptions
{
    public sealed class TryCatchMessage : IMessage
    {
        private readonly IExceptionsHandler _exceptionsHandler;
        private readonly IMessage _message;

        public TryCatchMessage(IMessage message, IExceptionsHandler exceptionsHandler)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }
            this._message = message;
            this._exceptionsHandler = exceptionsHandler;
        }

        #region IMessage members

        event Action IMessage.Receive
        {
            add { _message.Receive += value; }
            remove { _message.Receive -= value; }
        }

        void IMessage.Send()
        {
            try
            {
                _message.Send();
            }
            catch (Exception exception)
            {
                _exceptionsHandler.ExceptionCatched(_message, exception);
            }
        }

        #endregion
    }

    public sealed class TryCatchMessage<T> : IMessage<T>
    {
        private readonly IExceptionsHandler<T> _exceptionsHandler;
        private readonly IMessage<T> _message;

        public TryCatchMessage(IMessage<T> message, IExceptionsHandler<T> exceptionsHandler)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }
            this._message = message;
            this._exceptionsHandler = exceptionsHandler;
        }

        #region IMessage<TArg> members

        event Action<T> IMessage<T>.Receive
        {
            add { _message.Receive += value; }
            remove { _message.Receive -= value; }
        }

        public void Send(T arg)
        {
            try
            {
                _message.Send(arg);
            }
            catch (Exception exception)
            {
                _exceptionsHandler.ExceptionCatched(_message, arg, exception);
            }
        }

        #endregion
    }

    public sealed class TryCatchMessage<TArg0, TArg1> : IMessage<TArg0, TArg1>
    {
        private readonly IExceptionsHandler<TArg0, TArg1> _exceptionsHandler;
        private readonly IMessage<TArg0, TArg1> _message;

        public TryCatchMessage(IMessage<TArg0, TArg1> message, IExceptionsHandler<TArg0, TArg1> exceptionsHandler)
        {
            this._message = message;
            this._exceptionsHandler = exceptionsHandler;
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }
        }

        #region IMessage<TArg0, TArg1> members

        event Action<TArg0, TArg1> IMessage<TArg0, TArg1>.Receive
        {
            add { _message.Receive += value; }
            remove { _message.Receive -= value; }
        }

        void IMessage<TArg0, TArg1>.Send(TArg0 arg0, TArg1 arg1)
        {
            try
            {
                _message.Send(arg0, arg1);
            }
            catch (Exception exception)
            {
                _exceptionsHandler.ExceptionCatched(_message, arg0, arg1, exception);
            }
        }

        #endregion
    }

    public sealed class TryCatchMessage<TArg0, TArg1, TArg2> : IMessage<TArg0, TArg1, TArg2>
    {
        private readonly IExceptionsHandler<TArg0, TArg1, TArg2> _exceptionsHandler;
        private readonly IMessage<TArg0, TArg1, TArg2> _message;

        public TryCatchMessage(IMessage<TArg0, TArg1, TArg2> message,
            IExceptionsHandler<TArg0, TArg1, TArg2> exceptionsHandler)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }
            this._message = message;
            this._exceptionsHandler = exceptionsHandler;
        }

        #region IMessage<TArg0, TArg1, TArg2> members

        event Action<TArg0, TArg1, TArg2> IMessage<TArg0, TArg1, TArg2>.Receive
        {
            add { _message.Receive += value; }
            remove { _message.Receive -= value; }
        }

        void IMessage<TArg0, TArg1, TArg2>.Send(TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            try
            {
                _message.Send(arg0, arg1, arg2);
            }
            catch (Exception exception)
            {
                _exceptionsHandler.ExceptionCatched(_message, arg0, arg1, arg2, exception);
            }
        }

        #endregion
    }

    public sealed class TryCatchMessage<T0, T1, T2, T3> : IMessage<T0, T1, T2, T3>
    {
        private readonly IExceptionsHandler<T0, T1, T2, T3> _exceptionsHandler;
        private readonly IMessage<T0, T1, T2, T3> _message;

        public TryCatchMessage(IMessage<T0, T1, T2, T3> message,
            IExceptionsHandler<T0, T1, T2, T3> exceptionsHandler)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }
            this._message = message;
            this._exceptionsHandler = exceptionsHandler;
        }

        #region IMessage<TArg0, TArg1, TArg2, TArg3> 

        event Action<T0, T1, T2, T3> IMessage<T0, T1, T2, T3>.Receive
        {
            add { _message.Receive += value; }
            remove { _message.Receive -= value; }
        }

        void IMessage<T0, T1, T2, T3>.Send(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            try
            {
                _message.Send(arg0, arg1, arg2, arg3);
            }
            catch (Exception exception)
            {
                _exceptionsHandler.ExceptionCatched(_message, arg0, arg1, arg2, arg3, exception);
            }
        }

        #endregion
    }
}