using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private Vector3 translateSphere;
    int indexColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
       
        var myObject = GameObject.Find("Main Camera");
        var myScript = myObject.GetComponent<FieldCreate>();
       
        if (myScript.selectedSphere.x > -1)
        {
            Collider[] hitColliders = Physics.OverlapSphere(myScript.selectedSphere, 0.5f);
            foreach (var hitCollider in hitColliders)
            {
                translateSphere= new Vector3(transform.position.x, transform.position.y, -2);
                hitCollider.transform.position = translateSphere;
               
               
               for (int i=0;i< myScript.sphereArray.Length; i++)
                {
                    if (myScript.sphereArray[i].name == hitCollider.name.Substring(0, hitCollider.name.Length - 7))
                    {
                        indexColor = i;
                        break;
                    }
                       
                }
                myScript.busyArray[Mathf.RoundToInt(translateSphere.x), Mathf.RoundToInt(translateSphere.y)] = indexColor;
                myScript.busyArray[Mathf.RoundToInt(myScript.selectedSphere.x), Mathf.RoundToInt(myScript.selectedSphere.y)] = -1;
            }

            myScript.GenerateSpheres();
        }
      
    }
}
