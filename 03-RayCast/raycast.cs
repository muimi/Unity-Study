using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test01 : MonoBehaviour
{
    // Use For test1()
    public LayerMask mask;
    
    // Use For test2()
    public Transform objectToPlace;
    public Camera gameCamera;


    void Update()
    {
        test1();
        //test2();
        //test3();
    }

    void test1() {
        // This script is attached to a Cube to cast ray
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100, mask, QueryTriggerInteraction.Ignore)) {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            print(hitInfo.collider.gameObject.name);
            Destroy(hitInfo.collider.gameObject);
        } else {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }

    void test2() {
        // This script is attached to a empty game object
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if ( Physics.Raycast(ray, out hitInfo)) {
            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    void test3() {
        // This is New Function
    }
}
