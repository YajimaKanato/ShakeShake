using System;
using UnityEngine;

public class Prefab : MonoBehaviour
{
    [Header("Drop Rate")]
    [Tooltip("�A�C�e���̃h���b�v�m���ƃL�[��ݒ肵�Ă�������")]
    public float dropRate = 0.0f;
    public string key;

    [Header("Score")]
    [Tooltip("�X�R�A��ݒ肵�Ă�������")]
    public int dropScore;

    private void Update()
    {
        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}
