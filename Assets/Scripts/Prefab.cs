using UnityEngine;

public class Prefab : MonoBehaviour
{
    [Header("Drop Rate")]
    [Tooltip("�A�C�e���̃h���b�v�m����ݒ肵�Ă�������")]
    public float dropRate = 0.0f;

    [Header("Score")]
    [Tooltip("�X�R�A��ݒ肵�Ă�������")]
    public float dropScore;

    private void Update()
    {
        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}
