using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreater : MonoBehaviour
{
    int vertexCount = 0;
    bool mouseDown = false;
    LineRenderer line;




    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            mouseDown = true;
        if(mouseDown)
        {
            line.SetVertexCount(vertexCount + 1);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line.SetPosition(vertexCount,mousePos);
            vertexCount++;
        }
        if (Input.GetMouseButtonUp(0))
        {
            vertexCount = 0;
            mouseDown = false;
            line.SetVertexCount(0);
        }
            
    }
}
