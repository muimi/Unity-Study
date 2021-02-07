using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoRoutines : MonoBehaviour
{
    public Transform[] path;

    IEnumerator currentCoroutine;

    void Start()
    {
        string[] messages = {"Welcome", "To", "This", "Amazing", "Game"};
        StartCoroutine(PrintMessage(messages, 0.5f));
        StartCoroutine(FollowPath());
    }

    void Update()
    {
        // 按下空格键不起作用的话，有可能是收到输入法影响
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (currentCoroutine != null) {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = Move(Random.onUnitSphere * 5, 8);
            StartCoroutine(currentCoroutine);
        }
    }

    IEnumerator PrintMessage(string[] messages, float delay) {
        foreach(string message in messages) {
            Debug.Log(message);
            // Pause coroutine for "delay" seconds
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator Move(Vector3 destination, float speed) {
        while (transform.position != destination) {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            // pause coroutine until next frame
            yield return null;
        }
    }

    IEnumerator FollowPath() {
        foreach (Transform wayPoint in path) {
            currentCoroutine = Move(wayPoint.position, 8);
            // pause coroutine until "currentCoroutine" has finished running
            yield return StartCoroutine(currentCoroutine);
        }
    }

    
}
