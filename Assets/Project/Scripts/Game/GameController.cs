using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameController : MonoBehaviour {
    [SerializeField]
    private GameSettings gameSettings;

    private Camera mainCamera;
    private void Awake()
    {
        //Caching components
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(gameSettings.infinitySpawnOnMouseDown) 
        {
            if (Input.GetMouseButton(0)) //Infinity spawn
                SpawnObject();
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) //Spawn on mouse click
                SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Get ray from camera
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity); //Check if object casted
        if(hit.collider != null && hit.transform.CompareTag("Hedgehog")) //if casted
        {
            //Make random force on object
            hit.transform.GetComponent<Hedgehog>().AddRandomForce(gameSettings.clickMinForce, gameSettings.clickMaxForce);
        }
        else //if not casted = spawn object
        {
            Vector3 spawnPoint = ray.origin; //Get ray position
            spawnPoint.z = 0; //Set Z cord to zero
            GameObject obj = Instantiate(gameSettings.objectToSpawn, spawnPoint, Quaternion.identity); //Spawn object

            var size = Random.Range(gameSettings.spawnMinSize, gameSettings.spawnMaxSize); //Random object size
            obj.transform.localScale = Vector3.one * size;
        }
    }
}
