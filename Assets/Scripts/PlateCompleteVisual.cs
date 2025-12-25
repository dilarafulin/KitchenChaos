using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSoGameObjectList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

        foreach (KitchenObjectSO_GameObject kitchenObjectSOGameObject in kitchenObjectSoGameObjectList)
        {

            kitchenObjectSOGameObject.gameObject.SetActive(false);
        }

    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObject kitchenObjectSOGameObject in kitchenObjectSoGameObjectList)
        {
            if(kitchenObjectSOGameObject.kitchenObjectSO == e.kitchenObjectSO) {
                kitchenObjectSOGameObject.gameObject.SetActive(true);
            }
        }
    }
}
