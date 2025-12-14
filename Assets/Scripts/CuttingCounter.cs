using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //kitchenobject yok 
            if (player.HasKitchenObject()) //playerin kitchenobject i var
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //playerin elinde bir sey yok 

            }
        }
        else
        {
            //kitchenobject mevcut tezgahta 
            if (player.HasKitchenObject())
            {
                //player elinde bir sey tasiyor
            }
            else
            {
                //player elinde bir sey tasimiyor
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            //Burada KitchenObject var 
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }
}
