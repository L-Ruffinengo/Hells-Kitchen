using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
    public SOKitchenObject input;
    public SOKitchenObject output;
    public int cuttingProgressMax;
}
