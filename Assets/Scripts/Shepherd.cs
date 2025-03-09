using UnityEngine;
using UnityEngine.SceneManagement;

public class Shepherd : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private void Start()
    {
        Invoke(nameof(StartChase), 1);
    }

    private void StartChase()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
