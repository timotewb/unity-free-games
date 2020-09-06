using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int frameCount;
    // Start is called before the first frame update
    void Start()
    {
        print("Start Game.");
    }

    // Update is called once per frame
    void Update()
    {
        frameCount +=1;
        print("Frame Count: " + frameCount);
        print("Calcuation: " + randomCalculation(5, frameCount));
    }

    int randomCalculation(int param1, int param2){
      int result = param1 + param2;
      return result;
    }
}
