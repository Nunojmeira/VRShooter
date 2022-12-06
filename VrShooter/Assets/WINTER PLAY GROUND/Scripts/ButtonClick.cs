using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// Just by implementing IPointerClickHandler like any UI, you can click on objects
    /// </summary>
    public UnityEvent OnClick;
        

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke();
    }

    public void ExitGame()
    {
        Debug.Log("EXIT");
        //Application.Quit();
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
    }

}
