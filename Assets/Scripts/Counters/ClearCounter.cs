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
            } else
            {
                //player elinde bir sey tasimiyor
                GetKitchenObject().SetKitchenObjectParent(player);
           }
        }

    }
}
