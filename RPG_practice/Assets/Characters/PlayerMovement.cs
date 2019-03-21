using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkMoveStopRadius = .2f;

    Boolean selfMove = true;

    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
        
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            print("Cursor raycast hit layer : " + cameraRaycaster.layerHit);
            switch (cameraRaycaster.layerHit)
            {
                case Layer.Walkable:
                    // if my layer is walkeable, pass into function move, the point hit - current position (to walk to it)  jump / crouch false.
                    currentClickTarget = cameraRaycaster.hit.point;
                    m_Character.Move(currentClickTarget - transform.position, false, false);
                    selfMove = true;
                    break;
                case Layer.Enemy:
                    print("enemy >:O");
                    break;
                default:
                    print("Unexpected Layer found");
                    break;
            }
        }
        // this is the difference in location.
        var playerToClickPoint = currentClickTarget - transform.position;
        if (playerToClickPoint.magnitude >= walkMoveStopRadius && selfMove == true)
        {
            m_Character.Move(playerToClickPoint, false, false);
        }
        else
        {
            m_Character.Move(Vector3.zero, false, false);
            //this allows for characted wasd control as well
            selfMove = false;
        }
        

    }
}

