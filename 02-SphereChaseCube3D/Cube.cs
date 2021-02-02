using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	public float speed = 10.0f;

	void Update() {
		// 三维坐标中，X和Z构成平面，Y为高度
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		// 由输入构成向量，并获取方向
		Vector3 direction = input.normalized;
		// Speed为速度值，Velocity为带方向的速度向量
		Vector3 velocity = direction * speed;

		// 由输入控制Cube移动
		transform.Translate(velocity * Time.deltaTime);
	}
}