using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{

    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    public virtual void Interact(Player player) //virtual sayesinde miras alan diger classlarda override yapabilecegiz
        //abstract yapsaydik kisaca virtual'in aksine override yapmak zorunlu olurdu. func da abstract
    {
        Debug.LogError("BaseCounter.Interact();");
    }

    public virtual void InteractAlternate(Player player) 
                                                
    {
        //Debug.LogError("BaseCounter.InteractAlternate();");
    }
    

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() { return kitchenObject; }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
