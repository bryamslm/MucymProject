using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement;

public class loadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Load_Menu");
    }

    // Update is called once per frame
    IEnumerator Load_Menu()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(1);
    }
}
