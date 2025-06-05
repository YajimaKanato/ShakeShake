using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [Header("Score")]
    [SerializeField]
    Text text;
    static float score = 0;
    public static float Score { get { return score; } set { score += value; } }

    void Start()
    {
        text.text = "" + score;
    }

    public void ScoreChange()
    {
        text.text = "" + score;
    }


}
