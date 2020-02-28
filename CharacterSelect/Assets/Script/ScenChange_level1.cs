using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenChange_level1 : MonoBehaviour
{
    /*
    public void NextScene()
    {
        SceneManager.LoadScene("Level_one");
    }
    */

    void OnCollisionEnter2D(Collision2D touched)
    {
        if (touched.gameObject.tag == "Door")
        {
            SceneManager.LoadScene("Level_one");
        }
        else if(touched.gameObject.tag == "Door1")
        {
            SceneManager.LoadScene("Level_two");
        }
    }
}