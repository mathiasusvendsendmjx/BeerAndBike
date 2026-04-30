using UnityEngine;

public class ActivateOndelay : MonoBehaviour
{
        public GameObject objectToActivate;
    
        private void ActivateObject()
        {
            objectToActivate.SetActive(true);
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("ActivateObject", 3f);
    }
}
