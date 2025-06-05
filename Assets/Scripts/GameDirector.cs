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

    //以降がボタンに設置するメソッド
    public void Bonus()
    {
        Debug.Log($"Bonus={bonus}");
        bonus += 0.01f;
    }

    //確率変更
    [Header("RateListOpen")]
    [SerializeField]
    GameObject openList;

    public void RateListOpen()
    {
        Debug.Log("確率変更リストオープン");
        openList.SetActive(true);
    }

    public void RateListClose()
    {
        Debug.Log("確率変更リストクローズ");
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
                Debug.Log($"{key}の確率を変更");
                list.GetComponent<Prefab>().dropRate += 0.01f;
                return;
            }
        }
    }

    //オートでスコアを加算する
    private float autoScoreInterval = 5.1f;
    Coroutine coroutine;
    public void AutoScoreStart()
    {
        autoScoreInterval -= 0.1f;
        Debug.Log($"現在のインターバル={autoScoreInterval}");
        if (coroutine == null)
        {
            Debug.Log("オートスコアスタート");
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
            Debug.Log("スコア加算");
        }
    }
}
