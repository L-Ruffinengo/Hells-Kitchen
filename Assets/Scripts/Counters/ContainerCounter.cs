using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    
    [SerializeField]
    private SOKitchenObject kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject()) //avoids spawning multiple kitchen objects
        {
            //Player is not carrying anything
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
