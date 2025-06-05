using System;
using UnityEngine;

public class Prefab : MonoBehaviour
{
    [Header("Drop Rate")]
    [Tooltip("アイテムのドロップ確率とキーを設定してください")]
    public float dropRate = 0.0f;
    public string key;

    [Header("Score")]
    [Tooltip("スコアを設定してください")]
    public int dropScore;

    private void Update()
    {
        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}
