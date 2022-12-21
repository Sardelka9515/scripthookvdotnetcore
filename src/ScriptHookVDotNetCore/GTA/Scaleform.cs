//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

using System.Drawing;
using GTA.Math;
using GTA.UI;

namespace GTA
{
    /// <summary>
    /// A class which handles rendering of Scaleform elements.
    /// </summary>
    public sealed class Scaleform : IDisposable, INativeValue
    {
        public Scaleform(string scaleformID)
        {
            Handle = Call<int>(Hash.REQUEST_SCALEFORM_MOVIE, scaleformID);
        }

        public void Dispose()
        {
            if (IsLoaded)
            {
                unsafe
                {
                    int handle = Handle;
                    Call(Hash.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED, &handle);
                }
            }

            GC.SuppressFinalize(this);
        }

        public int Handle { get; private set; }

        public ulong NativeValue
        {
            get { return (ulong)Handle; }
            set { Handle = unchecked((int)value); }
        }

        public bool IsValid => Handle != 0;
        public bool IsLoaded => Call<bool>(Hash.HAS_SCALEFORM_MOVIE_LOADED, Handle);

        void CallFunctionHead(string function, params object[] arguments)
        {
            Call(Hash.BEGIN_SCALEFORM_MOVIE_METHOD, Handle, function);

            foreach (var argument in arguments)
            {
                if (argument is int argInt)
                {
                    Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT, argInt);
                }
                else if (argument is string argString)
                {
                    Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, StringString);
                    Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argString);
                    Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
                }
                else if (argument is char argChar)
                {
                    Function.Call(Hash.BEGIN_TEXT_COMMAND_SCALEFORM_STRING, StringString);
                    Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, argChar.ToString());
                    Call(Hash.END_TEXT_COMMAND_SCALEFORM_STRING);
                }
                else if (argument is float argFloat)
                {
                    Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, argFloat);
                }
                else if (argument is double argDouble)
                {
                    Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT, (float)argDouble);
                }
                else if (argument is bool argBool)
                {
                    Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL, (bool)argBool);
                }
                else if (argument is ScaleformArgumentTXD argTxd)
                {
                    Call(Hash.SCALEFORM_MOVIE_METHOD_ADD_PARAM_TEXTURE_NAME_STRING, argTxd.txd);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format("Unknown argument type {0} passed to scaleform with handle {1}.",
                            argument.GetType().Name, Handle), "arguments");
                }
            }
        }

        public void CallFunction(string function, params object[] arguments)
        {
            CallFunctionHead(function, arguments);
            Call(Hash.END_SCALEFORM_MOVIE_METHOD);
        }

        public int CallFunctionReturn(string function, params object[] arguments)
        {
            CallFunctionHead(function, arguments);
            return Call<int>(Hash.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE);
        }

        public void Render2D()
        {
            Call(Hash.DRAW_SCALEFORM_MOVIE_FULLSCREEN, Handle, 255, 255, 255, 255, 0);
        }

        public void Render2DScreenSpace(PointF location, PointF size)
        {
            float x = location.X / Screen.Width;
            float y = location.Y / Screen.Height;
            float width = size.X / Screen.Width;
            float height = size.Y / Screen.Height;

            Call(Hash.DRAW_SCALEFORM_MOVIE, Handle, x + (width / 2.0f), y + (height / 2.0f), width, height, 255, 255,
                255, 255);
        }

        public void Render3D(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Call(Hash.DRAW_SCALEFORM_MOVIE_3D_SOLID, Handle, position.X, position.Y, position.Z, rotation.X, rotation.Y,
                rotation.Z, 2.0f, 2.0f, 1.0f, scale.X, scale.Y, scale.Z, 2);
        }

        public void Render3DAdditive(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Call(Hash.DRAW_SCALEFORM_MOVIE_3D, Handle, position.X, position.Y, position.Z, rotation.X, rotation.Y,
                rotation.Z, 2.0f, 2.0f, 1.0f, scale.X, scale.Y, scale.Z, 2);
        }

        public static implicit operator InputArgument(Scaleform value)
        {
            return new InputArgument((ulong)value.Handle);
        }
    }
}