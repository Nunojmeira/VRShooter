using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour {
    [SerializeField] private bool isExit = true;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet" && isExit)
        {
            Debug.Log("Exit");
        }
        else if (collision.gameObject.tag == "Bullet" && !isExit)
        {
            Debug.Log("RESTART");
        }
    }


}
