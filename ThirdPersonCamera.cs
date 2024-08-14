using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Vector3 offset;
    private Transform target;
    [Range(0, 10)] public float lerpValue;
    [Range(0, 10)]public float sensibility;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset; 
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * sensibility, Vector3.right) * offset;

        transform.LookAt(target);
    }
}
