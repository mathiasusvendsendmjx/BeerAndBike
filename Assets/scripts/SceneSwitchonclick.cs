using UnityEngine;
using UnityEngine.SceneManagement;

public class MonoBehaviourScript : MonoBehaviour
{
    private void OnMouseDown(){
    {
        sceneswitch();
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void sceneswitch()
    {
        SceneManager.LoadScene("Strand");
    }
}
}