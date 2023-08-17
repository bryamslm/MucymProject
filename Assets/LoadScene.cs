using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public ChangeImage1 changeImage;
   
    public void loadScene() {
        int sceneInt = changeImage.getSelectNum() + 2;
        changeImage.setSelectNum(0);
        SceneManager.LoadScene(sceneInt); 
    }
}
