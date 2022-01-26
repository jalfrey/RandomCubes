/*
 * Created By: Jason Alfrey
 * Date: 1/24/2022
 * 
 * Last Edited by: NA
 * Last Edited: 1/26/2022
 * 
 * Description: Spawn multiple cube prefabs into scene.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    // Variables
    public GameObject cubePrefab;
    public List<GameObject> gameObjectList;
    public float scalingFactor = 0.95f;
    [HideInInspector]
    public int numberOfCubes = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++;
        gameObject gObj = Instantiate<gameObject>(cubePrefab);
        gObj.name = "Cube" + numberOfCubes;

        // Transform to a random point in the square of size one and add to list 
        gObj.transform.position = Random.insideUnitSphere;
        gameObjectList.Add(gObj);

        Color randColor = new Color(RandomCubes.value, RandomCubes.value, RandomCubes.value);
        gObj.GetComponent<Renderer>.material.color = randColor;

        // Transform the scale for each game object, while checking
        // to add to remove list
        List<GameObject> removeList = new List<GameObject>();
        foreach (GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x;
            scale *= scalingFactor;
            goTemp.trasform.localScale = Vector3.one * scale;

            if (scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }
        }

        // Remove the objects from the removeList 
        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp);
            Destroy(goTemp);
        }
    }
}
