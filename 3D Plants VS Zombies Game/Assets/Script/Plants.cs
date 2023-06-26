using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] GameObject plantPrefab;
    GameObject plant;

    bool drop = false;
    bool dropped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plant != null && !drop)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40.0f));

            if (Input.GetMouseButtonDown(0))
            {
                drop = true;
            }
        }

        if (drop && !dropped) {
            RaycastHit hit;
            if (Physics.Raycast(plant.transform.position, Vector3.down, out hit))
            {
                float check = plant.transform.localScale.y;
                dropped = hit.distance <= check;
            }

            Vector3 position = plant.transform.position;
            position.y -= 9.8f * Time.deltaTime;
            plant.transform.position = position;
        }

        if (dropped)
        {
            PeaShooter peaShooter = plant.GetComponent<PeaShooter>();
        }
    }

    public void InstallPlant()
    {
        if (plant == null)
        {
            plant = Instantiate(plantPrefab) as GameObject;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            plant.transform.position = mousePosition;
            plant.transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}


