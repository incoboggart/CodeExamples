// Alexander Bogomoletz
// Code examples, 2015

using System;

namespace Cobo.Extensions
{
    public static class ActionExtensions
    {
        public static void Call(this Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public static void Call<TArg0>(this Action<TArg0> action, TArg0 arg0)
        {
            if (action != null)
            {
                action(arg0);
            }
        }

        public static void Call<TArg0, TArg1>(this Action<TArg0, TArg1> action, TArg0 arg0, TArg1 arg1)
        {
            if (action != null)
            {
                action(arg0, arg1);
            }
        }

        public static void Call<TArg0, TArg1, TArg2>(this Action<TArg0, TArg1, TArg2> action, TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            if (action != null)
            {
                action(arg0, arg1, arg2);
            }
        }

        public static void Call<TArg0, TArg1, TArg2, TArg3>(this Action<TArg0, TArg1, TArg2, TArg3> action, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            if (action != null)
            {
                action(arg0, arg1, arg2, arg3);
            }
        }
    }
}
