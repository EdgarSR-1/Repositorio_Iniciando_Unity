using UnityEngine;

public class WallBehaviour : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall1"))
        {
            transform.position = new Vector3(0, 0.6f, 0);
        }
    }
}
