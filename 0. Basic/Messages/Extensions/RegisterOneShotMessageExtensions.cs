using System;

namespace Cobo.Templates.Messages.Extensions
{
    public static class RegisterOneShotMessageExtensions
    {
        public static void RegisterOneShot(this IMessage message,
            Action action)
        {
            if (message == null)
            {
                return;
            }

            if (action == null)
            {
                return;
            }

            action += delegate { message.Receive -= action; };

            message.Receive += action;
        }

        public static void RegisterOneShot<T>(this IMessage<T> message,
            Action<T> action)
        {
            if (message == null)
            {
                return;
            }

            if (action == null)
            {
                return;
            }

            action += delegate { message.Receive -= action; };

            message.Receive += action;
        }

        public static void RegisterOneShot<T0, T1>(this IMessage<T0, T1> message,
            Action<T0, T1> action)
        {
            if (message == null)
            {
                return;
            }

            if (action == null)
            {
                return;
            }

            action += delegate { message.Receive -= action; };

            message.Receive += action;
        }

        public static void RegisterOneShot<T0, T1, T2>(this IMessage<T0, T1, T2> message,
            Action<T0, T1, T2> action)
        {
            if (message == null)
            {
                return;
            }

            if (action == null)
            {
                return;
            }

            action += delegate { message.Receive -= action; };

            message.Receive += action;
        }

        public static void RegisterOneShot<T0, T1, T2, T3>(this IMessage<T0, T1, T2, T3> message,
            Action<T0, T1, T2, T3> action)
        {
            if (message == null)
            {
                return;
            }

            if (action == null)
            {
                return;
            }

            action += delegate { message.Receive -= action; };

            message.Receive += action;
        }
    }
}