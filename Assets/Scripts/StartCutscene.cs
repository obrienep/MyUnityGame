using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    public GameObject thePlayer;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "player") {
            cam.SetActive (true);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //System.Threading.Thread.Sleep(2000);
            //cam.SetActive (false);
            //thePlayer.SetActive (true);
        }
    }
        private void OnTriggerExit2D(Collider2D other) {

        }

    
}
