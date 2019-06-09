using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace FH2OpenTK
{
    namespace Examples.Tutorial
    {
        /// <summary>
        ///     Demonstrates simple OpenGL Texturing.
        /// </summary>
        public class Textures : GameWindow
        {
            private readonly Bitmap bitmap = new Bitmap("Data/Textures/logo.jpg");
            private int texture;

            public Textures() : base(800, 600)
            {
            }

            #region OnLoad

            /// <summary>
            ///     Setup OpenGL and load resources here.
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

                var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                    OpenTK.Graphics.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

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
            ///     Respond to resize events here.
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
            ///     Add your game logic here.
            /// </summary>
            /// <param name="e">Contains timing information.</param>
            /// <remarks>There is no need to call the base implementation.</remarks>
            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                var keyboard = OpenTK.Input.Keyboard.GetState();
                if (keyboard[Key.Escape])
                    Exit();
            }

            #endregion

            #region OnRenderFrame

            /// <summary>
            ///     Add your game rendering code here.
            /// </summary>
            /// <param name="e">Contains timing information.</param>
            /// <remarks>There is no need to call the base implementation.</remarks>
            protected override void OnRenderFrame(FrameEventArgs e)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit);

                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.BindTexture(TextureTarget.Texture2D, texture);

                GL.Begin(BeginMode.Quads);

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
            ///     Entry point of this example.
            /// </summary>
            [STAThread]
            public static void Main()
            {
                using (var example = new Textures())
                {
                    // Get the title and category  of this example using reflection.
                    example.Title = "OpenTK";
                    example.Run(30.0, 0.0);
                }
            }

            #endregion
        }
    }
}