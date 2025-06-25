using UnityEngine;

public class BGMManager : MonoBehaviour
{
    //�V�[���ɍ��킹�Ĉȉ��̃e���v���[�g���g�p
    /*
     [Header("")]
     [SerializeField]
     AudioClip a;
     */

    [Header("Title")]
    [SerializeField]
    AudioClip title;

    [Header("Info")]
    [SerializeField]
    AudioClip info;

    [Header("Credit")]
    [SerializeField]
    AudioClip credit;

    [Header("Select")]
    [SerializeField]
    AudioClip select;

    [Header("InGame")]
    [SerializeField]
    AudioClip inGame;

    AudioSource audioSource;
    private static BGMManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //�V�[���ɍ��킹�Ĉȉ��̃e���v���[�g���g�p
    /*
    public void ~BGM()
    {
        Debug.Log("");
        if(audioSource.clip != null)
        {
           audioSource.clip = title;
           audioSource.Play();
        }
    }
     */

    public void TitleBGM()
    {
        Debug.Log("TitleBGM");
        if (audioSource.clip != null)
        {
            audioSource.clip = title;
            audioSource.Play();
        }
    }

    public void InfoBGM()
    {
        Debug.Log("InfoBGM");
        if (audioSource.clip != null)
        {
            audioSource.clip = info;
            audioSource.Play();
        }
    }

    public void CreditBGM()
    {
        Debug.Log("CreditBGM");
        if (audioSource.clip != null)
        {
            audioSource.clip = credit;
            audioSource.Play();
        }
    }

    public void SelectBGM()
    {
        Debug.Log("SelectBGM");
        if (audioSource.clip != null)
        {
            audioSource.clip = select;
            audioSource.Play();
        }
    }

    public void InGameBGM()
    {
        Debug.Log("InGame");
        if (audioSource.clip != null)
        {
            audioSource.clip = inGame;
            audioSource.Play();
        }
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }
}
