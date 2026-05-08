using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public MonoBehaviour playerMovementScript;
    public Rigidbody playerRigidbody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (playerMovementScript != null)
            playerMovementScript.enabled = false;
    }

    public void StartIntro()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        if (playerRigidbody != null)
        {
            playerRigidbody.linearVelocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            playerRigidbody.isKinematic = true;
        }

        gameObject.SetActive(true);
    }

    public void EndIntro()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;

        if (playerRigidbody != null)
            playerRigidbody.isKinematic = false;

        gameObject.SetActive(false);
    }
}