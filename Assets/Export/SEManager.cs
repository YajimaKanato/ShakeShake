using UnityEngine;
using UnityEngine.Audio;

public class SEManager : MonoBehaviour
{
    //SE���ƂɈȉ��̃e���v���[�g���g�p
    /*[Header("")]
    [SerializeField]
    AudioClip a;*/

    [Header("AudioMixer")]
    [SerializeField]
    AudioMixerGroup mixer;

    AudioSource[] audioSource;
    private static SEManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = new AudioSource[20];
            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i] = gameObject.AddComponent<AudioSource>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// ������AudioSource�Ƀ~�L�T�[��ݒ�
    /// </summary>
    /// <param name="source"></param>
    void SetMixer(AudioSource source)
    {
        source.outputAudioMixerGroup = mixer;
    }

    /// <summary>
    /// ���g�p��AudioSource���擾
    /// </summary>
    /// <returns></returns>
    AudioSource GetUnusedAudioSource()
    {
        Debug.Log("getUnused");
        foreach (var audiosource in audioSource)
        {
            if (audiosource.isPlaying == false)
            {
                return audiosource;
            }
        }
        return null;
    }

    
}
