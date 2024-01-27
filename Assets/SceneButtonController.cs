using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButtonController : MonoBehaviour
{

    [SerializeField] List<GameObject> camButtonsList = new List<GameObject>(); 

    [SerializeField]  GameObject desactivatedButton = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void desactivateNewButton(GameObject newButton){
        if(desactivatedButton != null){
            desactivatedButton.GetComponent<ExtendedButton>().enabled = true;
            desactivatedButton.GetComponent<ExtendedButton>().onPointerExit.Invoke();
        }
        newButton.GetComponent<ExtendedButton>().enabled = false;
        camButtonsList.Add(desactivatedButton);
        desactivatedButton = newButton;
        camButtonsList.Remove(desactivatedButton);
    }
}
