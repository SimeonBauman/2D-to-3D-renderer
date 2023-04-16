using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    
    float fov = 70;
    float offSet = .2f;
    public int numsOfRays = 500;
    public GameObject rayShooter;
    public GameObject cam;
    public GameObject pixel;
    public GameObject[] pixels;
   // int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(drawLines());
        offSet = fov / (float)numsOfRays;
        cam = Camera.main.gameObject;
        pixels = new GameObject[numsOfRays];
        createScreen();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < numsOfRays; i++)
        {
            int layer_mask = LayerMask.GetMask( "wall");
            rayShooter.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, (i * -offSet) + (offSet * (float)numsOfRays/2)));
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayShooter.transform.right, Mathf.Infinity,layer_mask);

            
            Debug.DrawLine(transform.position, hit.point, Color.white, .01f);
            
            if (10 / hit.distance > .001f) pixels[i].transform.localScale = new Vector2(pixels[i].transform.localScale.x, (10 / hit.distance) * Mathf.Cos(transform.rotation.z - rayShooter.transform.rotation.z));
            
            
            float cNum = (10 / hit.distance) * 30f;
            if( cNum > 255) cNum = 255;

            pixels[i].GetComponent<SpriteRenderer>().color = new Color32((byte)cNum, (byte)cNum, (byte)cNum, 255);
            
        }

    }

   void createScreen()
    {
        for (int i = 0; i < numsOfRays; i++) {
            float xSize = 10/(float)numsOfRays;
            pixels[i] = Instantiate(pixel, new Vector2(cam.transform.position.x + (i - (numsOfRays / 2)) * xSize, 0), Quaternion.identity);
            pixels[i].transform.localScale = new Vector2(xSize, 10);
        }
        
    }
}
