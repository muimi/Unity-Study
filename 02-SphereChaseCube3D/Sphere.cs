using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

	public float speed = 7.0f;

	void Update() {
		// 获取位置信息
		Vector3 cubePosition = FindObjectOfType<Cube>().transform.position;
		Vector3 selfPosition = transform.position;
		// 计算位置差
		Vector3 displacement = cubePosition - selfPosition;

		// 计算距离和方向
		float distance = displacement.magnitude;
		Vector3 direction = displacement.normalized;

		// 防止Cube和Sphere贴合，距离过近时不移动
		if (distance > 1.5f) {
			transform.Translate(direction * speed * Time.deltaTime);
		}
	}
}