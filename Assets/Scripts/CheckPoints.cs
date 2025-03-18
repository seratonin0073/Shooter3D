using UnityEngine;
using UnityEditor.SceneManagement;

public class CheckPoints : MonoBehaviour
{
    private GameObject LVL2;

    private void Start()
    {
        LVL2 = GameObject.FindGameObjectWithTag("CheckPoint");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == LVL2)
        {
            EditorSceneManager.LoadScene(1);
        }
    }
}
