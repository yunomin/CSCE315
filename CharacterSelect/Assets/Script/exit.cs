using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Quick_Start");
    }

}