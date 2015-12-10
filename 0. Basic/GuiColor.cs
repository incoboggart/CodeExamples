// Alexander Bogomoletz
// Code examples, 2015

using System;

using UnityEngine;

namespace UnityExtensions.GUIUsings.Disposable
{
    /// <summary>
    /// Matches <see cref="GUI.color"/> change and restore
    /// </summary>
    public struct GuiColor : IDisposable
    {
        private readonly Color _color;

        /// <summary>
        /// <see cref="GUI.color"/>
        /// </summary>
        /// <param name="color"><see cref="GUI.color"/></param>
        public GuiColor(Color color)
        {
            _color = GUI.color;
            GUI.color = color;
        }

        void IDisposable.Dispose()
        {
            GUI.color = _color;
        }

        public static implicit operator Color(GuiColor c)
        {
            return c._color;
        }
    }
}