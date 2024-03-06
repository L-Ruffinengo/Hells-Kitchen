using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    private SOKitchenObject soKitchenObject;

    public SOKitchenObject GetKitchenObjectSO() 
    {
        return soKitchenObject; 
    }
}
