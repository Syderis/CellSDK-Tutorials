using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Store;
namespace InApp
{
    class MainScreen : Screen
    {
        private InAppProduct myProduct;
        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            StoreConfiguration conf = new StoreConfiguration();
            conf.Android.Enabled = true;
            conf.IOS.Enabled = true;
            //conf.WindowsPhone.Enabled = true;

            List<InAppProduct> productList = new List<InAppProduct>();

            myProduct = new InAppProduct("com.syderis.cellsdk.myProduct", InAppProductType.NonConsumable);
            productList.Add(myProduct);

            conf.ProductList = productList;


            InAppStore.OnUpdateTransaction += HandleInAppStoreOnUpdateTransaction;

            InAppStore.Initialize(conf);

            Button buy = new Button("Buy!");
            buy.Released += new Component.ComponentEventHandler(buy_Released);
            AddComponent(buy, 100, 100);
        }

        void buy_Released(Component source)
        {
            InAppStore.PurchaseProduct(myProduct.ProductId);
        }

        void HandleInAppStoreOnUpdateTransaction(InAppTransaction transaction)
        {
            switch (transaction.State)
            {
                case TransactionState.Cancelled:
                    break;
                case TransactionState.Error:
                    break;
                case TransactionState.ItemUnavailable:
                    break;
                case TransactionState.Purchased:
                    break;
                case TransactionState.Refunded:
                    break;
                case TransactionState.Restored:
                    break;
                default:
                    break;
            }
          
            InAppStore.FinishTransaction(transaction);
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
