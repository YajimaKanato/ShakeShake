using UnityEngine;

public class Basket : MonoBehaviour
{
    [Header("GameDirector")]
    [SerializeField]
    GameObject director;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        director.GetComponent<GameDirector>().ScoreChange();
        GameDirector.Score = collision.gameObject.GetComponent<Prefab>().dropScore;
        Destroy(collision.gameObject);
    }
}
