using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    [Range(1f, 20f)]
    private float moveSpeed;
    [SerializeField]
    [Range(1f, 15f)]
    private float rotationSpeed;
    [SerializeField]
    private GameInput gameInput;

    private bool isWalking;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
            playerRadius, moveDirection, moveDistance);

        // Diagonal movement when colliding
        if (!canMove)
        {
            // Cannot move towards moveDirection

            //Attempt only x movement
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, 
                playerRadius, moveDirectionX, moveDistance);

            if (canMove)
            {
                // Can move only on X axis
                moveDirection = moveDirectionX;
            }
            else
            {
                // Cannot move only on the X

                //Attempt only z movement
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                    playerRadius, moveDirectionZ, moveDistance);

                if (canMove)
                {
                    // Can move only on Z axis
                    moveDirection = moveDirectionZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }
        }

        if(canMove)
        {
            transform.position += moveDirection * moveDistance;
        }
        
        isWalking = moveDirection != Vector3.zero;//es lo mismo que if moveDir!=Vector.zero{isWalking = true}

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
