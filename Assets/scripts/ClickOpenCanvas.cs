using UnityEngine;

public class ClickOpenCanvas : MonoBehaviour
{
    public GameObject canvasToOpen;

    private void OnMouseDown()
    {
        Debug.Log("Canvas should open");
        canvasToOpen.SetActive(true);
    } 
}
