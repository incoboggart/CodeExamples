using System;
using System.Collections.Generic;

namespace Cobo.Templates.Messages.Impl.Messages
{
    public sealed class WeakReferenceMessage : IMessage
    {
        private readonly LinkedList<WeakReference> references;

        #region IMessage members

        event Action IMessage.Receive
        {
            add { references.AddLast(new WeakReference(value)); }
            remove
            {
                var node = references.First;

                while (node != null)
                {
                    var reference = node.Value;

                    if (!reference.IsAlive)
                    {
                        references.Remove(node);
                    }
                    else
                    {
                        var other = reference.Target as Action;

                        if (other != null && other == value)
                        {
                            references.Remove(node);
                        }
                    }
                }
            }
        }

        void IMessage.Send()
        {
            var node = references.First;

            while (node != null)
            {
                var reference = node.Value;
                var nextNode = node.Next;

                if (reference.IsAlive)
                {
                    var action = reference.Target as Action;

                    if (action != null)
                    {
                        action();
                    }
                    else
                    {
                        references.Remove(node);
                    }
                }
                else
                {
                    references.Remove(node);
                }

                node = nextNode;
            }
        }

        #endregion

        #region Constructors

        public WeakReferenceMessage()
        {
            references = new LinkedList<WeakReference>();
        }

        public WeakReferenceMessage(IEnumerable<Action> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            references = new LinkedList<WeakReference>();

            foreach (var action in actions)
            {
                if (action != null)
                {
                    references.AddLast(new WeakReference(action));
                }
            }
        }

        #endregion
    }

    public sealed class WeakReferenceMessage<T> : IMessage<T>
    {
        private readonly LinkedList<WeakReference> references;

        #region IMessage<T> members

        event Action<T> IMessage<T>.Receive
        {
            add
            {
                if (value != null)
                {
                    references.AddLast(new WeakReference(value));
                }
            }
            remove
            {
                var node = references.First;

                while (node != null)
                {
                    var reference = node.Value;

                    if (!reference.IsAlive)
                    {
                        references.Remove(node);
                    }
                    else
                    {
                        var other = reference.Target as Action<T>;

                        if (other != null && other == value)
                        {
                            references.Remove(node);
                        }
                    }

                    node = node.Next;
                }
            }
        }

        void IMessage<T>.Send(T arg)
        {
            var node = references.First;

            while (node != null)
            {
                var reference = node.Value;
                var nextNode = node.Next;

                if (reference.IsAlive)
                {
                    var action = reference.Target as Action;

                    if (action != null)
                    {
                        action();
                    }
                    else
                    {
                        references.Remove(node);
                    }
                }
                else
                {
                    references.Remove(node);
                }

                node = nextNode;
            }
        }

        #endregion

        #region Constructors

        public WeakReferenceMessage()
        {
            references = new LinkedList<WeakReference>();
        }

        public WeakReferenceMessage(IEnumerable<Action<T>> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            references = new LinkedList<WeakReference>();

            foreach (var action in actions)
            {
                if (action != null)
                {
                    references.AddLast(new WeakReference(action));
                }
            }
        }

        #endregion
    }

    public sealed class WeakReferenceMessage<T0, T1> : IMessage<T0, T1>
    {
        private readonly LinkedList<WeakReference> references;

        #region IMessage<T0, T1> members

        event Action<T0, T1> IMessage<T0, T1>.Receive
        {
            add
            {
                if (value != null)
                {
                    references.AddLast(new WeakReference(value));
                }
            }
            remove
            {
                var node = references.First;

                while (node != null)
                {
                    var reference = node.Value;

                    if (!reference.IsAlive)
                    {
                        references.Remove(node);
                    }
                    else
                    {
                        var other = reference.Target as Action<T0, T1>;

                        if (other != null && other == value)
                        {
                            references.Remove(node);
                        }
                    }

                    node = node.Next;
                }
            }
        }

        void IMessage<T0, T1>.Send(T0 arg0, T1 arg1)
        {
            var node = references.First;

            while (node != null)
            {
                var reference = node.Value;
                var nextNode = node.Next;

                if (reference.IsAlive)
                {
                    var action = reference.Target as Action<T0, T1>;

                    if (action != null)
                    {
                        action(arg0, arg1);
                    }
                    else
                    {
                        references.Remove(node);
                    }
                }
                else
                {
                    references.Remove(node);
                }

                node = nextNode;
            }
        }

        #endregion

        #region Constructors

        public WeakReferenceMessage()
        {
            references = new LinkedList<WeakReference>();
        }

        public WeakReferenceMessage(IEnumerable<Action<T0, T1>> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            references = new LinkedList<WeakReference>();

            foreach (var action in actions)
            {
                if (action != null)
                {
                    references.AddLast(new WeakReference(action));
                }
            }
        }

        #endregion
    }

    public sealed class WeakReferenceMessage<T0, T1, T2> : IMessage<T0, T1, T2>
    {
        private readonly LinkedList<WeakReference> references;

        #region IMessage<T0, T1, T2> members

        event Action<T0, T1, T2> IMessage<T0, T1, T2>.Receive
        {
            add
            {
                if (value != null)
                {
                    references.AddLast(new WeakReference(value));
                }
            }
            remove
            {
                var node = references.First;

                while (node != null)
                {
                    var reference = node.Value;

                    if (!reference.IsAlive)
                    {
                        references.Remove(node);
                    }
                    else
                    {
                        var other = reference.Target as Action<T0, T1, T2>;

                        if (other != null && other == value)
                        {
                            references.Remove(node);
                        }
                    }

                    node = node.Next;
                }
            }
        }

        void IMessage<T0, T1, T2>.Send(T0 arg0, T1 arg1, T2 arg2)
        {
            var node = references.First;

            while (node != null)
            {
                var reference = node.Value;
                var nextNode = node.Next;

                if (reference.IsAlive)
                {
                    var action = reference.Target as Action<T0, T1, T2>;

                    if (action != null)
                    {
                        action(arg0, arg1, arg2);
                    }
                    else
                    {
                        references.Remove(node);
                    }
                }
                else
                {
                    references.Remove(node);
                }

                node = nextNode;
            }
        }

        #endregion

        #region Constructors

        public WeakReferenceMessage()
        {
            references = new LinkedList<WeakReference>();
        }

        public WeakReferenceMessage(IEnumerable<Action<T0, T1, T2>> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            references = new LinkedList<WeakReference>();

            foreach (var action in actions)
            {
                if (action != null)
                {
                    references.AddLast(new WeakReference(action));
                }
            }
        }

        #endregion
    }

    public sealed class WeakReferenceMessage<T0, T1, T2, T3> : IMessage<T0, T1, T2, T3>
    {
        private readonly LinkedList<WeakReference> _references;

        #region IMessage<T0, T1, T2, T3> members

        event Action<T0, T1, T2, T3> IMessage<T0, T1, T2, T3>.Receive
        {
            add
            {
                if (value != null)
                {
                    _references.AddLast(new WeakReference(value));
                }
            }
            remove
            {
                var node = _references.First;

                while (node != null)
                {
                    var reference = node.Value;

                    if (!reference.IsAlive)
                    {
                        _references.Remove(node);
                    }
                    else
                    {
                        var other = reference.Target as Action<T0, T1, T2, T3>;

                        if (other != null && other == value)
                        {
                            _references.Remove(node);
                        }
                    }

                    node = node.Next;
                }
            }
        }

        void IMessage<T0, T1, T2, T3>.Send(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            var node = _references.First;

            while (node != null)
            {
                var reference = node.Value;
                var nextNode = node.Next;

                if (reference.IsAlive)
                {
                    var action = reference.Target as Action<T0, T1, T2, T3>;

                    if (action != null)
                    {
                        action(arg0, arg1, arg2, arg3);
                    }
                    else
                    {
                        _references.Remove(node);
                    }
                }
                else
                {
                    _references.Remove(node);
                }

                node = nextNode;
            }
        }

        #endregion

        #region Constructors

        public WeakReferenceMessage()
        {
            _references = new LinkedList<WeakReference>();
        }

        public WeakReferenceMessage(IEnumerable<Action<T0, T1, T2, T3>> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            _references = new LinkedList<WeakReference>();

            foreach (var action in actions)
            {
                if (action != null)
                {
                    _references.AddLast(new WeakReference(action));
                }
            }
        }

        #endregion
    }
}