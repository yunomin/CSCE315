using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings_Control : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Tutorial_level");
    }

}
