using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;

public class PlayerDataScript : MonoBehaviour
{
    Rigidbody2D rb;
    public bool gVHS = false;
    public ParticleSystem pS;
    public CinemachineVirtualCamera Vcam1;
    public CinemachineVirtualCamera Vcam2;
    [SerializeField]
    private GameObject gameOverGUI;


    public void GameOver()
    {
      Debug.Log("You Died!");
      gameOverGUI.SetActive(true);
    }
      // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "gVHS")
        {
        gVHS = true;
        Debug.Log("gVHS collected");
        pS.Play();
        Destroy(col.gameObject);
        Destroy(col);
      }
      else if(col.gameObject.tag == "return")
      {
        if(gVHS == true)
        {
          Debug.Log("Level Finished");
          Destroy(col);
        }
      }
      else if(col.gameObject.tag == "Respawn")
      {
        Vcam1.enabled = false;
        Vcam2.enabled = true;
        GameOver();
        Destroy(col);
      }
    }
}
