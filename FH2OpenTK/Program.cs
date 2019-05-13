using System;
using System.Drawing;
using System.Drawing.Imaging;

using OpenTK;
using BeginMode = OpenTK.Graphics.BeginMode;
using ClearBufferMask = OpenTK.Graphics.ClearBufferMask;
using EnableCap = OpenTK.Graphics.EnableCap;
using GL = OpenTK.Graphics.GL;
using HintMode = OpenTK.Graphics.HintMode;
using HintTarget = OpenTK.Graphics.HintTarget;
using MatrixMode = OpenTK.Graphics.MatrixMode;
using PixelFormat = OpenTK.Graphics.PixelFormat;
using PixelInternalFormat = OpenTK.Graphics.PixelInternalFormat;
using PixelType = OpenTK.Graphics.PixelType;
using TextureMagFilter = OpenTK.Graphics.TextureMagFilter;
using TextureMinFilter = OpenTK.Graphics.TextureMinFilter;
using TextureParameterName = OpenTK.Graphics.TextureParameterName;
using TextureTarget = OpenTK.Graphics.TextureTarget;

namespace FH2OpenTK
{

    namespace Examples.Tutorial
    {
        /// <summary>
        /// Demonstrates simple OpenGL Texturing.
        /// </summary>
        public class Textures : GameWindow
        {
            Bitmap bitmap = new Bitmap("Data/Textures/logo.jpg");
            int texture;

            public Textures() : base(800, 600)
            {
            }

            #region OnLoad

            /// <summary>
            /// Setup OpenGL and load resources here.
            /// </summary>
            /// <param name="e">Not used.</param>
            protected override void OnLoad(EventArgs e)
            {
                GL.ClearColor(Color.MidnightBlue);
                GL.Enable(EnableCap.Texture2D);

                GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

                GL.GenTextures(1, out texture);
                GL.BindTexture(TextureTarget.Texture2D, texture);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                    (int) TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                    (int) TextureMagFilter.Linear);

                BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                    PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                bitmap.UnlockBits(data);
            }

            #endregion

            #region OnUnload

            protected override void OnUnload(EventArgs e)
            {
                GL.DeleteTextures(1, ref texture);
            }

            #endregion

            #region OnResize

            /// <summary>
            /// Respond to resize events here.
            /// </summary>
            /// <param name="e">Contains information on the new GameWindow size.</param>
            /// <remarks>There is no need to call the base implementation.</remarks>
            protected override void OnResize(EventArgs e)
            {
                GL.Viewport(0, 0, Width, Height);

                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
            }

            #endregion

            #region OnUpdateFrame

            /// <summary>
            /// Add your game logic here.
            /// </summary>
            /// <param name="e">Contains timing information.</param>
            /// <remarks>There is no need to call the base implementation.</remarks>
            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                var keyboard = OpenTK.Input.Keyboard.GetState();
                if (keyboard[OpenTK.Input.Key.Escape])
                    this.Exit();
            }

            #endregion

            #region OnRenderFrame

            /// <summary>
            /// Add your game rendering code here.
            /// </summary>
            /// <param name="e">Contains timing information.</param>
            /// <remarks>There is no need to call the base implementation.</remarks>
            protected override void OnRenderFrame(FrameEventArgs e)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit);

                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.BindTexture(TextureTarget.Texture2D, texture);

                GL.Begin( BeginMode.Quads);

                GL.TexCoord2(0.0f, 1.0f);
                GL.Vertex2(-0.6f, -0.4f);
                GL.TexCoord2(1.0f, 1.0f);
                GL.Vertex2(0.6f, -0.4f);
                GL.TexCoord2(1.0f, 0.0f);
                GL.Vertex2(0.6f, 0.4f);
                GL.TexCoord2(0.0f, 0.0f);
                GL.Vertex2(-0.6f, 0.4f);

                GL.End();

                SwapBuffers();
            }

            #endregion

            #region public static void Main()

            /// <summary>
            /// Entry point of this example.
            /// </summary>
            [STAThread]
            public static void Main()
            {
                using (Textures example = new Textures())
                {
                    // Get the title and category  of this example using reflection.
                    example.Title = $"OpenTK";
                    example.Run(30.0, 0.0);
                }
            }

            #endregion
        }
    }
}
