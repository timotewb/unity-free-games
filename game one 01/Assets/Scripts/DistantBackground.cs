using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistantBackground : MonoBehaviour
{

    [SerializeField] GameObject[] platforms;
    [SerializeField] Vector3 platformStartPosition;
    [SerializeField] string parentName;
    [SerializeField] string sortingLayerName;
    [SerializeField] int gridWidth;
    [SerializeField] int gridHeight;
    [SerializeField] int chancePlatform;

    Vector2 platformSpacing;
    SpriteRenderer rend;

    void Start(){
      //height
      for(int i = 0; i < gridHeight; i++){
        //width
        for(int j = 0; j < gridWidth; j++){

          int randomPlatform = Random.Range(0,platforms.Length);
          platformSpacing = platforms[randomPlatform].GetComponent<Renderer>().bounds.size;

          //chances of there being a platform in cell
          if(Random.Range(1, chancePlatform) == 1){
            float scale = Random.Range(0.1f, 0.8f);

            GameObject go = Instantiate(platforms[randomPlatform], new Vector3(
              platformStartPosition.x + (j * platformSpacing.x)+ Random.Range(-10,10),
              platformStartPosition.y + (i * platformSpacing.y)+ Random.Range(-10,10)
            ), Quaternion.identity) as GameObject;

            rend = go.GetComponent<SpriteRenderer>();
            rend.sortingLayerName = sortingLayerName;

            go.transform.localScale  = new Vector3(scale,scale,go.transform.localScale.z);
            int flip = 0;
            if(Random.Range(1,4) == 1){
              flip = -180;
            }
            go.transform.rotation = Quaternion.Euler(0, flip, 0);
            go.transform.parent = GameObject.Find(parentName).transform;
          }
        }
      }
    }

}
