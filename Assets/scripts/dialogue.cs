using UnityEngine;

public class dialogue : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    public void SwitchObjects()
    {
        objectToDisable.SetActive(false);
        objectToEnable.SetActive(true);
    }
}

