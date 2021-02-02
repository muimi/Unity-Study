using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    public Vector2 speedMinMax;
    float speed;
    float visibleHeight;

    private void Start()
    {
        speedMinMax = new Vector2(7.0f, 13.0f);
        // 在60秒之内Block下降速度达到最快，60秒定义在Difficulty中
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        // 屏幕下缘位置
        visibleHeight = -Camera.main.orthographicSize - transform.localScale.y;
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
        // 超出屏幕下缘，销毁Block
        if (transform.position.y < visibleHeight) {
            Destroy(gameObject);
        }
    }
}
