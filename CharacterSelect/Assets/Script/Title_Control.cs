using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Control : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Level_two");
    }
}
