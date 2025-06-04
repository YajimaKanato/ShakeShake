using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

[System.Serializable]
class SalmonDrops
{
    [Header("Drops")]
    [Tooltip("�h���b�v�A�C�e���̃v���n�u��ݒ肵�Ă�������")]
    public GameObject prefab;

    [Header("Drop Rate")]
    [Tooltip("�A�C�e���̃h���b�v�m����ݒ肵�Ă�������")]
    public float dropRate = 0.0f;
}

public class Shake : MonoBehaviour
{
    [Header("Drops with DropRate")]
    [Tooltip("�h���b�v�A�C�e���Ƃ��̊m����ݒ肵�Ă�������")]
    [SerializeField]
    List<SalmonDrops> dropList;

    private float dropInterval = 0.5f;//�h���b�v�Ԋu
    private float getMousePointInterval = 0.5f;

    private Vector3[] mousepos=new Vector3[3];
    private List<Vector3> compareVector = new List<Vector3>();

    Coroutine cor;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("�N���b�N�J�n");
            mousepos[0] = Input.mousePosition;
            mousepos[1] = Input.mousePosition;
            //cor = StartCoroutine(DropCoroutine());
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("�N���b�N��");
            mousepos[2] = Input.mousePosition;
            mousepos[2].z = 10;
            transform.position = Camera.main.ScreenToWorldPoint(mousepos[2]);//�����}�E�X�ɍ��킹�ē�����

            if (Vector3.Angle(mousepos[0] - mousepos[1], mousepos[1] - mousepos[2]) > 150)
            {
                compareVector.Add(mousepos[1]);//�}�E�X�̐؂�ւ����𒲂ׂ�
            }

            if (compareVector.Count == 2)//���؂�ւ�������
            {
                if(Vector3.Distance(compareVector[0], compareVector[1])>Screen.height / 10)
                {
                    cor = StartCoroutine(DropCoroutine());
                }
                compareVector.RemoveAt(0);
            }

            mousepos[0] = mousepos[1];
            mousepos[1] = mousepos[2];
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("�N���b�N�I��");
            if (cor != null)
            {
                StopCoroutine(cor);
                cor = null;
            }
            mousepos[0] = Vector3.zero;
            mousepos[1] = Vector3.zero;
            compareVector.Clear();
        }
    }

    /*IEnumerator DropCoroutine()//System.Collections���K�v
    {
        while (true)
        {
            yield return new WaitForSeconds(getMousePointInterval);
            Debug.Log("���̃}�E�X�ʒu���擾");
            mousepos[1] = Input.mousePosition;
            if (Vector3.Distance(mousepos[0], mousepos[1]) > Screen.height / 10)
            {
                Drop();
                yield return new WaitForSeconds(dropInterval);
            }
            mousepos[0] = mousepos[1];
        }
    }*/

    IEnumerator DropCoroutine()//System.Collections���K�v
    {
        Drop();
        yield return new WaitForSeconds(dropInterval);
    }

    void Drop()
    {
        if(dropList.Count ==0 || dropList == null)
        {
            Debug.Log("���X�g����ł�");
            return;
        }

        float totalRate = 0.0f;
        foreach(var list in dropList)
        {
            totalRate += list.dropRate;
        }

        float nowRate = 0.0f;
        float rand = Random.Range(0, totalRate);
        foreach (var list in dropList)
        {
            nowRate += list.dropRate;
            if (nowRate <= rand)
            {
                Debug.Log("�h���b�v");
                float angleRand = Random.Range(0, 360);
                Quaternion q = Quaternion.AngleAxis(angleRand, Vector3.forward);
                Instantiate(list.prefab, this.transform.position, q);
                return;
            }
        }
    }
}
