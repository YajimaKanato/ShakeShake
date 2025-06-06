using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

enum PrefabEnum
{
    SalmonInRiceball = 100,
    SalmonFillet = 100,
    SalmonCaviar = 100,
    FriedSalmon = 100,
    BearEatSalmon = 100
}

public class GameDirector : MonoBehaviour
{
    [Header("Score")]
    [SerializeField]
    Text text;
    static int score = 0;
    private static float bonus = 0.0f;
    public static int Score { set { score += (int)(value + bonus); } }

    void Start()
    {
        text.text = "" + score;
    }

    private void Update()
    {
        text.text = "" + score;
    }

    //以降がボタンに設置するメソッド
    int bonusHard = 0;
    public void Bonus()
    {
        if (score >= 100 + bonusHard)
        {
            bonus++;
            Debug.Log($"Bonus={bonus}");
            score -= 100 + bonusHard;
            bonusHard += 100;
        }
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

    [Header("PrefabList")]
    [SerializeField]
    List<GameObject> prefabList;
    public void RateChange(string key)
    {
        foreach (var list in prefabList)
        {
            if (list.GetComponent<Prefab>().key == key)
            {
                foreach (var value in Enum.GetValues(typeof(PrefabEnum)))
                {
                    string name = Enum.GetName(typeof(PrefabEnum), value);
                    if (list.GetComponent<Prefab>().key == name)
                    {
                        if (score >= (int)value)
                        {
                            if (list.GetComponent<Prefab>().dropRate == 0)
                            {
                                Debug.Log($"{key}を解放");
                            }
                            else
                            {
                                Debug.Log($"{key}の確率を変更");
                            }
                            list.GetComponent<Prefab>().dropRate += 0.01f;
                            score -= (int)value;
                            return;
                        }
                    }
                }

            }
        }
    }

    void RateChangeLock(GameObject list)
    {
        foreach (var value in Enum.GetValues(typeof(PrefabEnum)))
        {
            string name = Enum.GetName(typeof(PrefabEnum), value);
            if (list.GetComponent<Prefab>().key == name)
            {
                if (score >= (int)value)
                {
                    score -= (int)value;
                }
            }
        }
    }

    public void RateListClose()
    {
        Debug.Log("確率変更リストクローズ");
        openList.SetActive(false);
    }


    //オートでスコアを加算する
    private float autoScoreInterval = 5.0f;
    private int autoScore = 1;
    Coroutine coroutine;

    [Header("AutoSetting")]
    [SerializeField]
    GameObject autoSettingList;
    public void AutoSettingListOpen()
    {
        autoSettingList.SetActive(true);
    }

    public void AutoScoreStart()
    {
        if (coroutine == null)
        {
            Debug.Log("オートスコアスタート");
            coroutine = StartCoroutine(AutoScoreCoroutine());
        }
    }

    IEnumerator AutoScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoScoreInterval);
            score += autoScore;
            Debug.Log("スコア加算");
        }
    }

    public void AutoScoreUp()
    {
        autoScore++;
    }

    public void IntervalDecrease()
    {
        if (autoScoreInterval > 0)
        {
            autoScoreInterval -= 0.1f;
        }
    }

    public void SettingListClose()
    {
        autoSettingList.SetActive(false);
    }


    //オブジェクトレベル
    [Header("ObjectLevelList")]
    [SerializeField]
    GameObject objectLevelList;
    public void ObjectLevelListOpen()
    {
        objectLevelList.SetActive(true);
    }

    [Header("Basket")]
    [SerializeField]
    Transform basket;
    public void BasketLevelUp()
    {
        if (basket.localScale.x < 4 && basket.localScale.y < 1)
        {
            basket.localScale += new Vector3(0.04f, 0.01f);
        }
    }

    [Header("GuardLeft")]
    [SerializeField]
    Transform guardLeft;
    public void GuardLeftLevelUp()
    {
        if (guardLeft.localScale.x < 1 && guardLeft.localScale.y < 2)
        {
            guardLeft.localScale += new Vector3(0.01f, 0.02f);
        }
    }

    [Header("GuardRight")]
    [SerializeField]
    Transform guardRight;
    public void GuardRightLevelUp()
    {
        if (guardRight.localScale.x < 1 && guardRight.localScale.y < 2)
        {
            guardRight.localScale += new Vector3(0.01f, 0.02f);
        }
    }

    public void ObjectLevelListClose()
    {
        objectLevelList.SetActive(false);
    }


    //シェイクレンジ
    [Header("ShakeRange")]
    [SerializeField]
    Transform shakeRange;
    [Header("Shake")]
    [SerializeField]
    GameObject shake;
    public void ShakeRangeChange()
    {
        if (shakeRange.localScale.x > 0.02f)
        {
            shakeRange.localScale -= new Vector3(0.01f, 0.01f);
            shake.GetComponent<Shake>().shakeRange -= 0.04f;
        }
    }


    //プレイング情報
    [Header("PlayingList")]
    [SerializeField]
    GameObject playingList;
    public void PlayingListOpen()
    {
        playingList.SetActive(true);
    }



    public void PlayingListClose()
    {
        playingList.SetActive(false);
    }
}
