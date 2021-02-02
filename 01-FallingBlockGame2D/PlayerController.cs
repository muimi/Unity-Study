using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

    public event Action OnPlayerDeath;
    public float speed;
    Vector2 playerPositionBoundary;

    void Start() {
        speed = 7.0f;
        // 取得Player的宽和高
        float halfPlayerWidth = transform.localScale.x / 2f;
        float halfPlayerHeight = transform.localScale.y / 2f;
        // 取得屏幕的宽和高
        Vector2 halfScreenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        // 计算Player的移动边界
        playerPositionBoundary = new Vector2(halfScreenSize.x - halfPlayerWidth, halfScreenSize.y - halfPlayerHeight);
    }

    void Update() {
        // 取得键盘输入
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // 计算移动量并更新
        Vector2 velocity = input.normalized * speed;
        transform.Translate(velocity * Time.deltaTime);

        // 使Player保持在屏幕宽度边界之内
        if (transform.position.x < -playerPositionBoundary.x) {
            transform.position = new Vector2(-playerPositionBoundary.x, transform.position.y);
        } 
        if (transform.position.x > playerPositionBoundary.x) {
            transform.position = new Vector2(playerPositionBoundary.x, transform.position.y);
        }

        // 使Player保持在屏幕高度边界之内
        if (transform.position.y < -playerPositionBoundary.y) {
            transform.position = new Vector2(transform.position.x, -playerPositionBoundary.y);
        } 
        if (transform.position.y > playerPositionBoundary.y) {
            transform.position = new Vector2(transform.position.x, playerPositionBoundary.y);
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider) {
        // Player需要设置为RigidBody2D以及Collider2D，Block只需要设置Collider2D
        // RigidBody2D中需要设置Kinematic，用以去掉重力影响
        if (triggerCollider.tag == "Falling Block") {
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
            }
            // Player被销毁
            Destroy(gameObject);
        }

    }
}
