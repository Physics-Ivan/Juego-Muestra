using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public GameObject ObjectToPickup;
    public GameObject PickedObject;
    public Transform InteractionZone; 
    void Update()
    {
        if (ObjectToPickup != null && 
            ObjectToPickup.GetComponent<PickableObject>().isPickable == true &&
            PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickup;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(InteractionZone);
                PickedObject.transform.position = InteractionZone.transform.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else if (PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;    
            }


        }

    }
}
