using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio_Control : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Audio");
    }
}
