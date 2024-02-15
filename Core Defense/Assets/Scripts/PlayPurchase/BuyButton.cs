using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public enum ItemType
    {
        Gold300,
        Gold600,
        Gold3000,
        Gold30000,
       
       
        NoAds
    }

    public ItemType itemType;

    public TextMeshProUGUI priceText;

    
    void Start()
    {
        
        StartCoroutine(LoadPriceRoutine());
    }

   public void Clickbuy()
    {
        switch (itemType)
        {
            case ItemType.Gold300:
               
                
                break;
            case ItemType.Gold600:
            
              
                break;
            case ItemType.Gold3000:
               
               
                break;
            case ItemType.Gold30000:
                
                break;
            
            case ItemType.NoAds:
                break; 
        }
    }

   
    private IEnumerator LoadPriceRoutine()
    {
        while (!IAPManager.Instance.IsInitialized())
        {
            yield return null;
        }

        string loadedPrice = "";
        switch (itemType)
        {
            case ItemType.Gold300:
               loadedPrice= IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.gold_1000);
                break;
            case ItemType.Gold600:
              loadedPrice=  IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.gold_2000);
                break;
            case ItemType.Gold3000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.gold_5000);
                break;
            case ItemType.Gold30000:
                loadedPrice = IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.gold_10000);
                break;
            
            case ItemType.NoAds:
               loadedPrice= IAPManager.Instance.GetProductPriceFromStore(IAPManager.Instance.no_ads);
                break;

        }

        priceText.text = loadedPrice;
    }
}
