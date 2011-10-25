using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;

namespace CanvasSample
{
    class MyCanvas:Canvas
    {
        private RenderTarget2D drawing;
        private Texture2D brush;
        private Vector2 actualPosition;
        private Vector2 middleoffset;        

        public Color PaintColor { get; set; }

        public MyCanvas(int weidth, int heigh)
            : base(weidth, heigh)
        {
            drawing = new RenderTarget2D(MultitouchStaticContent.SpriteBatch.GraphicsDevice, weidth,
                      heigh, false, SurfaceFormat.Color,
                      DepthFormat.Depth24, 0, RenderTargetUsage.PreserveContents);
            brush = MultitouchStaticContent.Content.Load<Texture2D>("brush");
            middleoffset = new Vector2(brush.Width / 2, brush.Height / 2);
        }

        public override void CanvasDraw()
        {
            base.CanvasDraw();

            SetRenderTarget(drawing);
            MultitouchStaticContent.SpriteBatch.Begin();
            if (actualPosition!=Vector2.Zero)
            {
                MultitouchStaticContent.SpriteBatch.Draw(brush, actualPosition - middleoffset, PaintColor);
            }
            MultitouchStaticContent.SpriteBatch.End();

            SetRenderTarget(null);

            MultitouchStaticContent.SpriteBatch.GraphicsDevice.Clear(Color.Transparent);
            
            MultitouchStaticContent.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            MultitouchStaticContent.SpriteBatch.Draw(drawing, Vector2.Zero, Color.White);

            MultitouchStaticContent.SpriteBatch.End();
        }

        public override void CanvasTouchMoved(List<Syderis.CellSDK.Common.IBlob> blobs)
        {
            base.CanvasTouchMoved(blobs);
            actualPosition = blobs[0].Position;
        }

        public override void CanvasTouchReleased(List<Syderis.CellSDK.Common.IBlob> blobs)
        {
            base.CanvasTouchReleased(blobs);
            actualPosition = Vector2.Zero ;
        }

       
        
    }
}
