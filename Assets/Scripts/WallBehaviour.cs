using UnityEngine;
using UnityEngine.SceneManagement;

public class WallBehaviour : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall1"))
        {
            transform.position = new Vector3(0, 0.6f, 0);
        }

        if (collision.gameObject.CompareTag("Wall2"))
        {
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
