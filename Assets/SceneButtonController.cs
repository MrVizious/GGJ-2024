using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButtonController : MonoBehaviour
{

    [SerializeField] List<GameObject> camButtonsList = new List<GameObject>(); 

    [SerializeField]  GameObject desactivatedButton = null;

    [SerializeField]  GameObject bazingaButton;
    [SerializeField] int numKeyDeactivated = 0;
    // Start is called before the first frame update
    void Start()
    {
        numKeyDeactivated = 0;
        bazingaButton.GetComponent<ExtendedButton>().enabled = false;
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

    public void deactivateSoundButton(GameObject soundButton){
        soundButton.GetComponent<ExtendedButton>().enabled = false;
    }

    public void deactivateKeyButton(GameObject keyButton){
        keyButton.GetComponent<ExtendedButton>().enabled = false;
        numKeyDeactivated++;
        if(numKeyDeactivated == 2){
            bazingaButton.GetComponent<ExtendedButton>().enabled = true;
            Debug.Log("Turbobazinga activado");
        }
    }

    public void deactivateBazingaButton(){
          bazingaButton.GetComponent<ExtendedButton>().enabled = false;
    }
}
