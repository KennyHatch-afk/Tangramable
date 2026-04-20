using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject menu;

    public void OnPointerClick(PointerEventData eventData)
    {
        menu.GetComponent<Menus>().StartGame();
        AudioManager.Play("snap");
    }
}
