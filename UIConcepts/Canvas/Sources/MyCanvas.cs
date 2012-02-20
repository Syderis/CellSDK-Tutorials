/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Common; 
#endregion

namespace CanvasSample
{
    public class MyCanvas:Canvas
    {
        private RenderTarget2D drawing;
        private Texture2D brush;
        private Vector2 actualPosition;
        private Vector2 middleoffset;        

        public Color PaintColor { get; set; }

        public MyCanvas(int weidth, int heigh)
            : base(weidth, heigh)
        {
            drawing = new RenderTarget2D(StaticContent.SpriteBatch.GraphicsDevice, weidth,
                      heigh, false, SurfaceFormat.Color,
                      DepthFormat.Depth24, 0, RenderTargetUsage.PreserveContents);            
            brush = StaticContent.Resources.CreateImage("brush").Texture;
            middleoffset = new Vector2(brush.Width / 2, brush.Height / 2);
        }

        public override void CanvasDraw()
        {
            base.CanvasDraw();

            SetRenderTarget(drawing);
            StaticContent.SpriteBatch.Begin();
            if (actualPosition!=Vector2.Zero)
            {
                StaticContent.SpriteBatch.Draw(brush, actualPosition - middleoffset, PaintColor);
            }
            StaticContent.SpriteBatch.End();

            SetRenderTarget(null);

            StaticContent.SpriteBatch.GraphicsDevice.Clear(Color.Transparent);
            
            StaticContent.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            StaticContent.SpriteBatch.Draw(drawing, Vector2.Zero, Color.White);

            StaticContent.SpriteBatch.End();
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
