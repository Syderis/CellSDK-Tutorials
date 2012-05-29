using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core.Animations;

namespace WP7Sprites
{
    class MainScreen : Screen
    {
        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            //Loads the spritesheet
            SpriteSheet spriteSheetChuck = ResourceManager.CreateSpriteSheet("chuckSpriteSheet");

            //Create the Sprites
            Sprite spriteHead = new Sprite("head", spriteSheetChuck["head"]) { Pivot = Vector2.One / 2, Touchable = false };
            Sprite spriteBody = new Sprite("body", spriteSheetChuck["body"]) { Pivot = Vector2.One / 2 };
            Sprite spriteArmLeft1 = new Sprite("arm_left_1", spriteSheetChuck["arm_left_1"]) { Pivot = new Vector2(0.75f, 0.65f), Touchable = false };
            Sprite spriteArmLeft2 = new Sprite("arm_left_2", spriteSheetChuck["arm_left_2"]) { Pivot = new Vector2(0.75f, 0.25f), Touchable = false };
            Sprite spriteArmRight1 = new Sprite("arm_right_1", spriteSheetChuck["arm_right_1"]) { Pivot = new Vector2(0.75f, 0.35f), Touchable = false };
            Sprite spriteArmRight2 = new Sprite("arm_right_2", spriteSheetChuck["arm_right_2"]) { Pivot = new Vector2(0.75f, 0.75f), Touchable = false };
            Sprite spriteFootLeft = new Sprite("foot_left", spriteSheetChuck["foot_left"]) { Pivot = Vector2.One / 2, Touchable = false };
            Sprite spriteFootRight = new Sprite("foot_right", spriteSheetChuck["foot_right"]) { Pivot = Vector2.One / 2, Touchable = false };
            spriteBody.Draggable = true;

            // Sprite tree
            spriteBody.AddChild(spriteHead);
            spriteBody.AddChild(spriteArmLeft2);
            spriteBody.AddChild(spriteArmRight2);
            spriteBody.AddChild(spriteFootLeft);
            spriteBody.AddChild(spriteFootRight);
            spriteArmLeft2.AddChild(spriteArmLeft1);
            spriteArmRight2.AddChild(spriteArmRight1);

            // Adds the player to the screen
            AddComponent(spriteBody, 0.5f * Preferences.ViewportManager.VirtualWidth, 0.5f * Preferences.ViewportManager.VirtualHeight);

            // Positions
            spriteArmLeft2.Position = spriteBody.Position + Vector2.UnitY * spriteBody.Size.Y * spriteBody.Pivot.Y * 0.9f;
            spriteArmRight2.Position = spriteBody.Position - Vector2.UnitY * spriteBody.Size.Y * spriteBody.Pivot.Y * 0.9f;
            spriteArmLeft1.Position = spriteArmLeft2.Position - new Vector2(spriteArmLeft2.Size.X * spriteArmLeft2.Pivot.X, -spriteArmLeft2.Size.Y * spriteArmLeft2.Pivot.Y);
            spriteArmRight1.Position = spriteArmRight2.Position - new Vector2(spriteArmRight2.Size.X * spriteArmRight2.Pivot.X, spriteArmLeft2.Size.Y * spriteArmLeft2.Pivot.Y);
            spriteFootLeft.Position = spriteBody.Position + Vector2.UnitY * spriteBody.Size * spriteBody.Pivot * 0.3f - Vector2.UnitX * 10;
            spriteFootRight.Position = spriteBody.Position - Vector2.UnitY * spriteBody.Size * spriteBody.Pivot * 0.3f - Vector2.UnitX * 10;

            // ordered
            SendToFront(spriteHead);
            SendToFront(spriteArmLeft1);
            SendToFront(spriteArmRight1);

            // Rotation slider
            Slider sliderAngle = new Slider() { Pivot = new Vector2(0.5f, 1.0f) };
            sliderAngle.ValueChangeEvent += (s) =>
            {
                spriteBody.Rotation = MathHelper.ToRadians(sliderAngle.Value * 3.60f);
            };
            AddComponent(sliderAngle, Preferences.ViewportManager.BottomCenterAnchor);

            ///////// DEFEND ANIMATION ////////
            // Animaciones
            Animation animationDefendHead = Animation.CreateAnimation(9);
            animationDefendHead.AnimationType = AnimationType.Relative;
            animationDefendHead.AddKey(new KeyFrame(0, Vector2.Zero));
            animationDefendHead.AddKey(new KeyFrame(2, -Vector2.UnitX * 2));
            animationDefendHead.AddKey(new KeyFrame(4, Vector2.Zero));
            animationDefendHead.AddKey(new KeyFrame(6, Vector2.UnitX * 2));
            animationDefendHead.AddKey(new KeyFrame(8, Vector2.Zero));
            animationDefendHead.FramePerSeconds = 10;
            AddAnimation(animationDefendHead);

            //Some variables to use in animations
            float degree = 45f;
            int framesDefend = 30;
            int waitfps = 60;

            Animation animationDefendLeftArm = Animation.CreateAnimation(framesDefend);
            animationDefendLeftArm.AnimationType = AnimationType.Relative;
            animationDefendLeftArm.AddKey(new KeyFrame(0, Vector2.Zero, 0.0f, 1.0f));

            animationDefendLeftArm.AddKey(new KeyFrame((int)(0.5f * framesDefend), Vector2.Zero, MathHelper.ToRadians(degree), 1.0f));

            animationDefendLeftArm.AddKey(new KeyFrame(framesDefend - 1, Vector2.Zero, 0.0f, 1.0f));
            animationDefendLeftArm.FramePerSeconds = waitfps;
            AddAnimation(animationDefendLeftArm);

            Animation animationDefendRightArm = Animation.CreateAnimation(framesDefend);
            animationDefendRightArm.AnimationType = AnimationType.Relative;
            animationDefendRightArm.AddKey(new KeyFrame(0, Vector2.Zero, 0.0f, 1.0f));
            animationDefendRightArm.AddKey(new KeyFrame((int)(0.5f * framesDefend), Vector2.Zero, MathHelper.ToRadians(-degree), 1.0f));
            animationDefendRightArm.AddKey(new KeyFrame(framesDefend - 1, Vector2.Zero, 0.0f, 1.0f));
            animationDefendRightArm.FramePerSeconds = waitfps;
            AddAnimation(animationDefendRightArm);


            ///////// RIGHT ATTACK ANIMATION ///////
            int rpfps = 60;
            int frames = 20;
            // body
            Animation animationAttackPunchBody = Animation.CreateAnimation(frames);
            animationAttackPunchBody.AnimationType = AnimationType.Relative;
            animationAttackPunchBody.AddKey(new KeyFrame(0, Vector2.Zero, 0.0f, 1.0f));
            animationAttackPunchBody.AddKey(new KeyFrame((int)(frames * 0.5), -Vector2.UnitX * 20, MathHelper.ToRadians(-85), 1.0f));
            animationAttackPunchBody.AddKey(new KeyFrame(frames - 1, Vector2.Zero, 0.0f, 1.0f));
            animationAttackPunchBody.FramePerSeconds = rpfps;
            AddAnimation(animationAttackPunchBody);

            // head
            Animation animationRightAttackHead = Animation.CreateAnimation(frames);
            animationRightAttackHead.AnimationType = AnimationType.Relative;
            animationRightAttackHead.AddKey(new KeyFrame(0, Vector2.Zero, 0.0f, 1.0f));
            animationRightAttackHead.AddKey(new KeyFrame((int)(frames * 0.5), Vector2.Zero, MathHelper.ToRadians(+85), 1.0f));
            animationRightAttackHead.AddKey(new KeyFrame(frames - 1, Vector2.Zero, 0.0f, 1.0f));
            animationRightAttackHead.FramePerSeconds = rpfps;
            AddAnimation(animationRightAttackHead);

            // right arm
            Animation animationRightAttackRightArm = Animation.CreateAnimation(frames);
            animationRightAttackRightArm.AnimationType = AnimationType.Relative;
            animationRightAttackRightArm.AddKey(new KeyFrame(0, Vector2.Zero, 0.0f, 1.0f));
            animationRightAttackRightArm.AddKey(new KeyFrame((int)(frames * 0.5), Vector2.Zero, MathHelper.ToRadians(35), 1.0f));
            animationRightAttackRightArm.AddKey(new KeyFrame(frames - 1, Vector2.Zero, 0.0f, 1.0f));
            animationRightAttackRightArm.FramePerSeconds = rpfps;
            AddAnimation(animationRightAttackRightArm);

            // right hand
            Animation animationRightAttackRightHand = Animation.CreateAnimation(frames);
            animationRightAttackRightHand.AnimationType = AnimationType.Relative;
            animationRightAttackRightHand.AddKey(new KeyFrame(0, Vector2.Zero, 0.0f, 1.0f));
            animationRightAttackRightHand.AddKey(new KeyFrame((int)(frames * 0.5), Vector2.Zero, MathHelper.ToRadians(45), 1.0f));
            animationRightAttackRightHand.AddKey(new KeyFrame(frames - 1, Vector2.Zero, 0.0f, 1.0f));
            animationRightAttackRightHand.FramePerSeconds = rpfps;
            AddAnimation(animationRightAttackRightHand);

            // left arm
            Animation animationRightAttackLeftArm = Animation.CreateAnimation(frames);
            animationRightAttackLeftArm.AnimationType = AnimationType.Relative;
            animationRightAttackLeftArm.AddKey(new KeyFrame(0, Vector2.Zero, 0.0f, 1.0f));
            animationRightAttackLeftArm.AddKey(new KeyFrame((int)(frames * 0.5), Vector2.Zero, MathHelper.ToRadians(45), 1.0f));
            animationRightAttackLeftArm.AddKey(new KeyFrame(frames - 1, Vector2.Zero, 0.0f, 1.0f));
            animationRightAttackLeftArm.FramePerSeconds = rpfps;
            AddAnimation(animationRightAttackLeftArm);


            // attack
            Vector2 v = new Vector2(0, 0);
            Animation animationAttack = Animation.CreateAnimation(frames);
            animationAttack.AnimationType = AnimationType.Relative;
            animationAttack.AddKey(new KeyFrame(0, v, 0.0f, 1.0f));
            animationAttack.AddKey(new KeyFrame((int)(frames * 0.5), v, 0.0f, 3.0f));
            animationAttack.AddKey(new KeyFrame(frames - 1, v, 0.0f, 1.0f));
            animationAttack.FramePerSeconds = rpfps;
            animationAttack.IsLooped = true;
            AddAnimation(animationAttack);


            Button btnDefend = new Button("Defend") { Pivot = new Vector2(0.5f, 0.0f) };
            btnDefend.Released += (s) =>
            {
                if (animationDefendRightArm.State == AnimationState.Stopped && animationAttackPunchBody.State == AnimationState.Stopped)
                {
                    animationDefendHead.Play(spriteHead);
                    animationDefendLeftArm.Play(spriteArmLeft2);
                    animationDefendRightArm.Play(spriteArmRight2);
               }

            };
            AddComponent(btnDefend, Preferences.ViewportManager.TopCenterAnchor);


            Button btnAttack = new Button("Attack") { Pivot = new Vector2(0.5f, 0.0f) };
            btnAttack.Released += (s) =>
            {
                if (animationAttackPunchBody.State == AnimationState.Stopped && animationDefendRightArm.State == AnimationState.Stopped)
                {
                    animationAttackPunchBody.Play(spriteBody);
                    animationRightAttackHead.Play(spriteHead);
                    animationRightAttackRightArm.Play(spriteArmRight2);
                    animationRightAttackRightHand.Play(spriteArmRight1);
                    animationRightAttackLeftArm.Play(spriteArmLeft2);

                }

            };
            AddComponent(btnAttack, btnDefend.Position + Vector2.UnitY * btnDefend.Size);


          
        }


        /// <summary>
        /// Pops this screen returning to the previous one, or exiting the app if there is no more left.
        /// This method is called when the hardware back button is pressed (only Windows Phone & Android)
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
