using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent 
{
    [SerializeField]
    private SOKitchenObject kitchenObjectSO;
    [SerializeField]
    private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    public void Interact(Player player)
    {
        if(kitchenObjectSO == null) //avoids spawning multiple kitchen objects
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
            kitchenObjectTransform.localPosition = Vector3.zero;
        }
        else
        {
            //Give the object to the player
            kitchenObject.SetKitchenObjectParent(player);
            
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
