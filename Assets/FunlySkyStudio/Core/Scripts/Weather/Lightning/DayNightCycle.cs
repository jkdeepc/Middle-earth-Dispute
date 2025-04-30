using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight;    // 直射光（太阳光）
    public float rotationSpeed = 10f; // 旋转速度（角度/秒）
    public float minIntensity = 0.1f; // 夜间最低光强
    public float maxIntensity = 1f;   // 白天最大光强

    void Start()
    {
        // 如果没有指定直射光，尝试自动获取
        if (directionalLight == null)
        {
            directionalLight = GetComponent<Light>();
            if (directionalLight == null)
            {
                Debug.LogError("Directional light not found!");
                return;
            }
        }
    }

    void Update()
    {
        // 使得每秒光源旋转一定角度，模拟一天的进程
        directionalLight.transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);

        // 获取当前光源的旋转角度
        float angle = directionalLight.transform.eulerAngles.x;

        // 计算光强度：使用余弦函数模拟白天和夜晚的变化
        // 光源旋转 0 度到 180 度代表白天，180 度到 360 度代表夜晚
        float intensity = Mathf.Clamp01(Mathf.Cos(Mathf.Deg2Rad * angle));
        directionalLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, intensity);
    }
}