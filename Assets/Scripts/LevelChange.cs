using DevLocker.Utils;
using UnityEngine;
using CustomAttributes;

public class LevelChange : MonoBehaviour
{
    [Category("Transition Level", TextAnchor.MiddleCenter)]
    [SerializeField] private SceneReference levelToLoad;


    [Category("Transition Settings",TextAnchor.MiddleCenter)]
    [SerializeField] private CircleCollider2D transitionCollider;

    [SerializeField] private float radius = 1f;


    private void Start()
    {
        transitionCollider = GetComponent<CircleCollider2D>();

        transitionCollider.radius = radius;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneHandler.Instance.LoadScene(levelToLoad.SceneName);
        }
    
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
