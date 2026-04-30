using UnityEngine;

public class ClickOpenCanvas : MonoBehaviour
{
    public GameObject canvasToOpen;

    private void OnMouseDown()
    {
        canvasToOpen.SetActive(true);
    } 
}
