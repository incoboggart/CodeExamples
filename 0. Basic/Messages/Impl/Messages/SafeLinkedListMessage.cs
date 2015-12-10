using System;
using System.Collections.Generic;

using Cobo.Templates.Messages.Impl.Exceptions;

namespace Cobo.Templates.Messages.Impl.Messages
{
    public sealed class SafeLinkedListMessage : IMessage
    {
        private readonly LinkedList<Action> _actions;
        private readonly IExceptionsHandler _exceptionsHandler;

        #region Constructors

        public SafeLinkedListMessage() :
            this(new LinkedList<Action>(), SupressExceptionsHandler.Instance)
        {
        }

        public SafeLinkedListMessage(IExceptionsHandler exceptionsHandler) :
            this(new LinkedList<Action>(), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(IEnumerable<Action> actions, IExceptionsHandler exceptionsHandler)
            : this(new LinkedList<Action>(actions), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(LinkedList<Action> actions, IExceptionsHandler exceptionsHandler)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }
            _actions = actions;
            _exceptionsHandler = exceptionsHandler;
        }

        #endregion Constructors

        #region IMessage members

        event Action IMessage.Receive
        {
            add
            {
                if (value != null)
                {
                    _actions.AddLast(value);
                }
            }
            remove { _actions.Remove(value); }
        }

        void IMessage.Send()
        {
            var node = _actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    try
                    {
                        action();
                    }
                    catch (Exception e)
                    {
                        _exceptionsHandler.ExceptionCatched(this, e);
                    }
                }
                else
                {
                    _actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion
    }

    public sealed class SafeLinkedListMessage<T> : IMessage<T>
    {
        private readonly LinkedList<Action<T>> _actions;
        private readonly IExceptionsHandler<T> _exceptionsHandler;

        #region Constructors

        public SafeLinkedListMessage() : this(new LinkedList<Action<T>>(), SupressExceptionsHandler<T>.Instance)
        {
        }

        public SafeLinkedListMessage(IExceptionsHandler<T> exceptionsHandler)
            : this(new LinkedList<Action<T>>(), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(IEnumerable<Action<T>> actions, IExceptionsHandler<T> exceptionsHandler)
            : this(new LinkedList<Action<T>>(actions), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(LinkedList<Action<T>> actions, IExceptionsHandler<T> exceptionsHandler)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }

            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }

            _actions = actions;
            _exceptionsHandler = exceptionsHandler;
        }

        #endregion

        #region IMessage<T> members

        event Action<T> IMessage<T>.Receive
        {
            add
            {
                if (value != null)
                {
                    _actions.AddLast(value);
                }
            }
            remove { _actions.Remove(value); }
        }

        void IMessage<T>.Send(T arg)
        {
            var node = _actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    try
                    {
                        action(arg);
                    }
                    catch (Exception e)
                    {
                        _exceptionsHandler.ExceptionCatched(this, arg, e);
                    }
                }
                else
                {
                    _actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion
    }

    public sealed class SafeLinkedListMessage<T0, T1> : IMessage<T0, T1>
    {
        private readonly LinkedList<Action<T0, T1>> _actions;
        private readonly IExceptionsHandler<T0, T1> _exceptionsHandler;

        #region Constructors

        public SafeLinkedListMessage()
            : this(new LinkedList<Action<T0, T1>>(), SupressExceptionsHandler<T0, T1>.Instance)
        {
        }

        public SafeLinkedListMessage(IExceptionsHandler<T0, T1> exceptionsHandler)
            : this(new LinkedList<Action<T0, T1>>(), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(IEnumerable<Action<T0, T1>> actions, IExceptionsHandler<T0, T1> exceptionsHandler)
            : this(new LinkedList<Action<T0, T1>>(actions), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(LinkedList<Action<T0, T1>> actions, IExceptionsHandler<T0, T1> exceptionsHandler)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }

            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }

            _actions = actions;
            _exceptionsHandler = exceptionsHandler;
        }

        #endregion

        #region IMessage<T1, T2> members

        event Action<T0, T1> IMessage<T0, T1>.Receive
        {
            add
            {
                if (value != null)
                {
                    _actions.AddLast(value);
                }
            }
            remove { _actions.Remove(value); }
        }

        void IMessage<T0, T1>.Send(T0 arg0, T1 arg1)
        {
            var node = _actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    try
                    {
                        action(arg0, arg1);
                    }
                    catch (Exception e)
                    {
                        _exceptionsHandler.ExceptionCatched(this, arg0, arg1, e);
                    }
                }
                else
                {
                    _actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion
    }

    public sealed class SafeLinkedListMessage<T0, T1, T2> : IMessage<T0, T1, T2>
    {
        private readonly LinkedList<Action<T0, T1, T2>> _actions;
        private readonly IExceptionsHandler<T0, T1, T2> _exceptionsHandler;

        #region Constructors

        public SafeLinkedListMessage()
            : this(new LinkedList<Action<T0, T1, T2>>(), SupressExceptionsHandler<T0, T1, T2>.Instance)
        {
        }

        public SafeLinkedListMessage(IExceptionsHandler<T0, T1, T2> exceptionsHandler)
            : this(new LinkedList<Action<T0, T1, T2>>(), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(IEnumerable<Action<T0, T1, T2>> actions,
            IExceptionsHandler<T0, T1, T2> exceptionsHandler)
            : this(new LinkedList<Action<T0, T1, T2>>(actions), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(LinkedList<Action<T0, T1, T2>> actions,
            IExceptionsHandler<T0, T1, T2> exceptionsHandler)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }

            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }

            _actions = actions;
            _exceptionsHandler = exceptionsHandler;
        }

        #endregion

        #region IMessage<T0, T1, T2> members

        event Action<T0, T1, T2> IMessage<T0, T1, T2>.Receive
        {
            add
            {
                if (value != null)
                {
                    _actions.AddLast(value);
                }
            }
            remove { _actions.Remove(value); }
        }

        void IMessage<T0, T1, T2>.Send(T0 arg0, T1 arg1, T2 arg2)
        {
            var node = _actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    try
                    {
                        action(arg0, arg1, arg2);
                    }
                    catch (Exception e)
                    {
                        _exceptionsHandler.ExceptionCatched(this, arg0, arg1, arg2, e);
                    }
                }
                else
                {
                    _actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion
    }

    public sealed class SafeLinkedListMessage<T0, T1, T2, T3> : IMessage<T0, T1, T2, T3>
    {
        private readonly LinkedList<Action<T0, T1, T2, T3>> _actions;
        private readonly IExceptionsHandler<T0, T1, T2, T3> _exceptionsHandler;

        #region Constructors

        public SafeLinkedListMessage()
            : this(new LinkedList<Action<T0, T1, T2, T3>>(), SupressExceptionsHandler<T0, T1, T2, T3>.Instance)
        {
        }

        public SafeLinkedListMessage(IExceptionsHandler<T0, T1, T2, T3> exceptionsHandler)
            : this(new LinkedList<Action<T0, T1, T2, T3>>(), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(IEnumerable<Action<T0, T1, T2, T3>> actions,
            IExceptionsHandler<T0, T1, T2, T3> exceptionsHandler)
            : this(new LinkedList<Action<T0, T1, T2, T3>>(actions), exceptionsHandler)
        {
        }

        public SafeLinkedListMessage(LinkedList<Action<T0, T1, T2, T3>> actions,
            IExceptionsHandler<T0, T1, T2, T3> exceptionsHandler)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }

            if (exceptionsHandler == null)
            {
                throw new ArgumentNullException("exceptionsHandler");
            }

            _actions = actions;
            _exceptionsHandler = exceptionsHandler;
        }

        #endregion

        #region IMessage<T0, T1, T2, T3> members

        event Action<T0, T1, T2, T3> IMessage<T0, T1, T2, T3>.Receive
        {
            add
            {
                if (value != null)
                {
                    _actions.AddLast(value);
                }
            }
            remove { _actions.Remove(value); }
        }

        void IMessage<T0, T1, T2, T3>.Send(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            var node = _actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    try
                    {
                        action(arg0, arg1, arg2, arg3);
                    }
                    catch (Exception e)
                    {
                        _exceptionsHandler.ExceptionCatched(this, arg0, arg1, arg2, arg3, e);
                    }
                }
                else
                {
                    _actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion
    }
}