﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SphereManager : MonoBehaviour
    {
     
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
        GameObject myObject = GameObject.Find("Main Camera");
        var myScript = myObject.GetComponent<FieldCreate>();

        myScript.selectedSphere = transform.position;
       
        }
    }
