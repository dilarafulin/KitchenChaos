using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
   [SerializeField] private KitchenObjectSO kitchenObjectSO;
   
    public override void Interact(Player player)
    {
       if(!HasKitchenObject())
        {
            //kitchenobject yok 
            if (player.HasKitchenObject())
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
            if(player.HasKitchenObject())
            {
                //player elinde bir sey tasiyor
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                //player tabak tasiyor
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                } else
                {  //player tabak disinda bir sey tasiyor

                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    { //tezgahta bir tabak var
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }

                    }
                }
            } else
            {
                //player elinde bir sey tasimiyor
                GetKitchenObject().SetKitchenObjectParent(player);
           }
        }

    }
}
