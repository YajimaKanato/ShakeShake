using UnityEngine;
using System.Collections.Generic;



public class Shake : MonoBehaviour
{
    [Header("Drops with DropRate")]
    [Tooltip("ドロップアイテムとその確率を設定してください")]
    [SerializeField]
    List<GameObject> dropList;

    public float shakeRange = 5.5f;

    private Vector3 mousepos = new Vector3();
    private Vector3[] compareVector = new Vector3[2];

    Coroutine cor;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousepos = Input.mousePosition;
            mousepos.z = 10;
            transform.position = Camera.main.ScreenToWorldPoint(mousepos);//鮭をマウスに合わせて動かす
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("クリック終了");
            if (cor != null)
            {
                StopCoroutine(cor);
                cor = null;
            }
        }
    }

    /// <summary>
    /// 重み付き確率による生成 
    /// </summary>
    void Drop()
    {
        if (dropList.Count == 0 || dropList == null)
        {
            Debug.Log("リストが空です");
            return;
        }

        float totalRate = 0.0f;
        foreach (var list in dropList)
        {
            totalRate += list.GetComponent<Prefab>().dropRate;
        }

        float nowRate = 0.0f;
        float rand = Random.Range(0, totalRate);
        foreach (var list in dropList)
        {
            nowRate += list.GetComponent<Prefab>().dropRate;
            if (nowRate >= rand)
            {
                Debug.Log("ドロップ");
                float angleRand = Random.Range(0, 360);
                Quaternion q = Quaternion.AngleAxis(angleRand, Vector3.forward);
                Instantiate(list, this.transform.position, q);
                return;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ShakeRange")
        {
            compareVector[0] = transform.position;
            Debug.Log("端に到達");
            if (Vector3.Distance(compareVector[0], compareVector[1]) >= shakeRange)
            {
                Debug.Log("ナイスシェイク");
                Drop();
            }
            compareVector[1] = compareVector[0];
        }
    }
}
