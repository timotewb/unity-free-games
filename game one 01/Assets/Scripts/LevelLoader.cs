using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float transitionTime = 1f;
    public void LoadNextLevel(int loadSceneIndex, Animator transition) {
        StartCoroutine(LoadLevel(loadSceneIndex, transition));
    }
    IEnumerator LoadLevel(int levelIndex, Animator transition) {

        // play animation
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(transitionTime);

        //load
        SceneManager.LoadScene(levelIndex);
    }

}
