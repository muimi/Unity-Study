using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class RayCast : MonoBehaviour
{
    // Use For test_01()
    public LayerMask mask;
    
    // Use For test_02()
    public Transform objectToPlace; // An Object Moving on the Ground
    public Camera gameCamera;       // Main Camera Object

    // Use For test_03()

    void Start() {
        // Collider2D
        Physics2D.queriesStartInColliders = false;
    }
=======
public class test01 : MonoBehaviour
{
    // Use For test1()
    public LayerMask mask;
    
    // Use For test2()
    public Transform objectToPlace;
    public Camera gameCamera;
>>>>>>> a2207d0417a8fb11f7b8410bc51f71e8331184a1


    void Update()
    {
<<<<<<< HEAD
        //test_01();
        //test_02();
        test_03();
    }

    void test_01() {
=======
        test1();
        //test2();
        //test3();
    }

    void test1() {
>>>>>>> a2207d0417a8fb11f7b8410bc51f71e8331184a1
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

<<<<<<< HEAD
    void test_02() {
=======
    void test2() {
>>>>>>> a2207d0417a8fb11f7b8410bc51f71e8331184a1
        // This script is attached to a empty game object
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if ( Physics.Raycast(ray, out hitInfo)) {
            objectToPlace.position = hitInfo.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

<<<<<<< HEAD
    void test_03() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right);

        if (hitInfo.collider != null) {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        } else {
            Debug.DrawLine(transform.position, transform.position + transform.right * 100, Color.green);
        }

=======
    void test3() {
        // This is New Function
>>>>>>> a2207d0417a8fb11f7b8410bc51f71e8331184a1
    }
}
