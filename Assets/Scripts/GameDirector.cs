using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour
{
    [Header("Score")]
    [SerializeField]
    Text text;
    static int score = 0;
    private static float bonus = 1.0f;
    public static int Score { set { score += (int)(value * bonus); } }

    void Start()
    {
        text.text = "" + score;
    }

    private void Update()
    {
        text.text = "" + score;
    }

    //�ȍ~���{�^���ɐݒu���郁�\�b�h
    public void Bonus()
    {
        Debug.Log($"Bonus={bonus}");
        bonus += 0.01f;
    }

    //�m���ύX
    [Header("RateListOpen")]
    [SerializeField]
    GameObject openList;

    public void RateListOpen()
    {
        Debug.Log("�m���ύX���X�g�I�[�v��");
        openList.SetActive(true);
    }

    public void RateListClose()
    {
        Debug.Log("�m���ύX���X�g�N���[�Y");
        openList.SetActive(false);
    }

    [Header("PrefabList")]
    [SerializeField]
    List<GameObject> prefabList;
    public void RateChange(string key)
    {
        foreach (var list in prefabList)
        {
            if (list.GetComponent<Prefab>().key == key)
            {
                Debug.Log($"{key}�̊m����ύX");
                list.GetComponent<Prefab>().dropRate += 0.01f;
                return;
            }
        }
    }

    //�I�[�g�ŃX�R�A�����Z����
    private float autoScoreInterval = 5.1f;
    Coroutine coroutine;
    public void AutoScoreStart()
    {
        autoScoreInterval -= 0.1f;
        Debug.Log($"���݂̃C���^�[�o��={autoScoreInterval}");
        if (coroutine == null)
        {
            Debug.Log("�I�[�g�X�R�A�X�^�[�g");
            coroutine = StartCoroutine(AutoScoreCoroutine());
        }
    }

    [Header("SalmonOre")]
    [SerializeField]
    GameObject ore;
    IEnumerator AutoScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoScoreInterval);
            score += ore.GetComponent<Prefab>().dropScore;
            Debug.Log("�X�R�A���Z");
        }
    }
}
