using System;
using System.Collections.Generic;

namespace Cobo.Templates.Messages.Impl.Messages
{
    public sealed class LinkedListMessage : IMessage
    {
        private readonly LinkedList<Action> actions;

        #region IMessage members

        event Action IMessage.Receive
        {
            add
            {
                if (value != null)
                {
                    actions.AddLast(value);
                }
            }
            remove
            {
                while (actions.Remove(value))
                {
                }
            }
        }

        void IMessage.Send()
        {
            var node = actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    action();
                }
                else
                {
                    actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion

        #region Constructors

        public LinkedListMessage()
        {
            actions = new LinkedList<Action>();
        }

        public LinkedListMessage(IEnumerable<Action> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            this.actions = new LinkedList<Action>(actions);
        }

        #endregion
    }

    public sealed class LinkedListMessage<T> : IMessage<T>
    {
        private readonly LinkedList<Action<T>> actions;

        #region IMessage<T> members

        event Action<T> IMessage<T>.Receive
        {
            add
            {
                if (value != null)
                {
                    actions.AddLast(value);
                }
            }
            remove
            {
                var removed = false;
                do
                {
                    removed = actions.Remove(value);
                } while (removed);
            }
        }

        void IMessage<T>.Send(T arg)
        {
            var node = actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    action(arg);
                }
                else
                {
                    actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion

        #region Constructors

        public LinkedListMessage()
        {
            actions = new LinkedList<Action<T>>();
        }

        public LinkedListMessage(IEnumerable<Action<T>> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            this.actions = new LinkedList<Action<T>>(actions);
        }

        #endregion
    }

    public sealed class LinkedListMessage<T0, T1> : IMessage<T0, T1>
    {
        private readonly LinkedList<Action<T0, T1>> actions;

        #region IMessage<T0, T1> members

        event Action<T0, T1> IMessage<T0, T1>.Receive
        {
            add
            {
                if (value != null)
                {
                    actions.AddLast(value);
                }
            }
            remove
            {
                Boolean removed;
                do
                {
                    removed = actions.Remove(value);
                } while (removed);
            }
        }

        void IMessage<T0, T1>.Send(T0 arg0, T1 arg1)
        {
            var node = actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    action(arg0, arg1);
                }
                else
                {
                    actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion

        #region Constructors

        public LinkedListMessage()
        {
            actions = new LinkedList<Action<T0, T1>>();
        }

        public LinkedListMessage(IEnumerable<Action<T0, T1>> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            this.actions = new LinkedList<Action<T0, T1>>(actions);
        }

        #endregion
    }

    public sealed class LinkedListMessage<T0, T1, T2> : IMessage<T0, T1, T2>
    {
        private readonly LinkedList<Action<T0, T1, T2>> actions;

        #region IMessage<T0, T1, T2> members

        event Action<T0, T1, T2> IMessage<T0, T1, T2>.Receive
        {
            add
            {
                if (value != null)
                {
                    actions.AddLast(value);
                }
            }
            remove
            {
                Boolean removed;
                do
                {
                    removed = actions.Remove(value);
                } while (removed);
            }
        }

        void IMessage<T0, T1, T2>.Send(T0 arg0, T1 arg1, T2 arg2)
        {
            var node = actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    action(arg0, arg1, arg2);
                }
                else
                {
                    actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion

        #region Constructors

        public LinkedListMessage()
        {
            actions = new LinkedList<Action<T0, T1, T2>>();
        }

        public LinkedListMessage(IEnumerable<Action<T0, T1, T2>> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            this.actions = new LinkedList<Action<T0, T1, T2>>(actions);
        }

        #endregion
    }

    public sealed class LinkedListMessage<T0, T1, T2, T3> : IMessage<T0, T1, T2, T3>
    {
        private readonly LinkedList<Action<T0, T1, T2, T3>> actions;

        #region IMessage<T0, T1, T2, T3> members

        event Action<T0, T1, T2, T3> IMessage<T0, T1, T2, T3>.Receive
        {
            add
            {
                if (value != null)
                {
                    actions.AddLast(value);
                }
            }
            remove
            {
                Boolean removed;
                do
                {
                    removed = actions.Remove(value);
                } while (removed);
            }
        }

        void IMessage<T0, T1, T2, T3>.Send(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            var node = actions.First;

            while (node != null)
            {
                var next = node.Next;
                var action = node.Value;

                if (action != null)
                {
                    action(arg0, arg1, arg2, arg3);
                }
                else
                {
                    actions.Remove(node);
                }

                node = next;
            }
        }

        #endregion

        #region Constructors

        public LinkedListMessage()
        {
            actions = new LinkedList<Action<T0, T1, T2, T3>>();
        }

        public LinkedListMessage(IEnumerable<Action<T0, T1, T2, T3>> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            this.actions = new LinkedList<Action<T0, T1, T2, T3>>(actions);
        }

        #endregion
    }
}