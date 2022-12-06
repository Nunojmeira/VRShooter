using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public enum ButtonType
{
    Restart,
    Exit
}
public class ButtonClick : MonoBehaviour {

    [SerializeField] ButtonType type;
    private void OnCollisionEnter(Collision collision)
    {
        foreach (var tag in GameSceneManager.instance.bulletTags)
            if (collision.transform.CompareTag(tag))
            {
                Debug.Log(tag);
                if (type == ButtonType.Restart)
                    GameManager.instance.gameState = GameState.Gameplay;
                else Application.Quit();
            }
    }


}
