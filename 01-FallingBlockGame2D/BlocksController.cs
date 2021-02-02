using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour {

    public GameObject fallingBlock;
    Vector2 timeBetweenFallDownMinMax;
    Vector2 blockSizeMinMax;
    float blockAngleMax;
    float timeToFallDownBlock;
    Vector2 halfScreenSize;

    void Start() {
        // 定义Block生成间隔的最大最小值
        timeBetweenFallDownMinMax = new Vector2(0.3f, 1.0f);
        // 随机生成Block大小的范围
        blockSizeMinMax = new Vector2(0.5f, 1.5f);
        // 初始降落最大转角
        blockAngleMax = 15.0f;

        halfScreenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }


    void Update() {
        if (Time.time > timeToFallDownBlock) {
            // 在60秒之内Block下降间隔逐渐达到最短，60秒定义在Difficulty中
            float timeBetweenFallDown = Mathf.Lerp(timeBetweenFallDownMinMax.y, timeBetweenFallDownMinMax.x, Difficulty.GetDifficultyPercent());
            timeToFallDownBlock = Time.time + timeBetweenFallDown;

            float blockSize = Random.Range(blockSizeMinMax.x, blockSizeMinMax.y);
            float blockAngle = Random.Range(-blockAngleMax, blockAngleMax);
            
            // 加二分之一高度用于在画面外生成Block
            Vector2 blockBornPosition = new Vector2(Random.Range(-halfScreenSize.x, halfScreenSize.x), halfScreenSize.y + blockSize / 2.0f);
            // 生成Block
            GameObject newBlock = (GameObject)Instantiate(fallingBlock, blockBornPosition, Quaternion.Euler(Vector3.forward * blockAngle));
            // 设置Block大小
            newBlock.transform.localScale = Vector2.one * blockSize;
        }
    }
}
