using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]
    private SOKitchenObject kitchenObjectSO;
    [SerializeField]
    private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    public void Interact()
    {
        if(kitchenObjectSO == null) //avoids spawning multiple kitchen objects
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;
            
            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        }
        

    }
}
