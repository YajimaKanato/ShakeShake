using UnityEngine;

public class Prefab : MonoBehaviour
{
    [Header("Drop Rate")]
    [Tooltip("アイテムのドロップ確率を設定してください")]
    public float dropRate = 0.0f;

    [Header("Score")]
    [Tooltip("スコアを設定してください")]
    public float dropScore;

    private void Update()
    {
        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}
