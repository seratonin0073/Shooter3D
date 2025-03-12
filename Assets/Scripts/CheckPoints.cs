using UnityEngine;
using UnityEditor.SceneManagement;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] private GameObject LVL2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == LVL2)
        {
            EditorSceneManager.LoadScene(1);
        }
    }
}
