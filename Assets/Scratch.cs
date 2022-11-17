using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : MonoBehaviour
{
    public Color pixel;
    public SpriteRenderer SpriteRenderer;
    Texture2D Scar_Image;
    public Texture2D SP; 
    public Rect SourceRect;
    private GameObject Target_Sprite;
    private Collider2D collidersHit;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer.sprite = Sprite.Create(SP, new Rect(0,0,SP.width,SP.height),new Vector2(0.5f,0.5f));
        Scar_Image = new Texture2D(SP.width,SP.height);
        this.GetComponent<BoxCollider2D>().size = new Vector2(SP.width/100f,(SP.height/100f));
        this.GetComponent<BoxCollider2D>().offset = new Vector2(0,0);
        //SpriteRenderer.sprite = Sprite.Create(Scar_Image, new Rect(0,0, Scar_Image.width, Scar_Image.height), new Vector2(0.5f,0.5f));
    }

    // Update is called once per frame
    void Update()
    {



        SpriteSelection();
    }
    void SpriteSelection()
    {Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // When mouse 0 is pressed
     if (Input.GetMouseButton(0))
     {
         
         collidersHit = Physics2D.OverlapPoint(pos);
         //GameObject selectedObject = null;        
     }
        if(collidersHit.name == this.ToString())
        {

        
             Target_Sprite = collidersHit.gameObject;
             Sprite sprite = SpriteRenderer.sprite;
             Rect rect = sprite.textureRect;

            Scar_Image = new Texture2D(SP.width,SP.height,TextureFormat.RGBA32,false);

             //Scar_Image = new Texture2D(x,y);
             // calculate the distance of the mouse from the center of the sprite's transform
             float x = pos.x - Target_Sprite.transform.position.x;
             float y = pos.y - Target_Sprite.transform.position.y;
             // convert the x and y values from units to pixels             
             x *= sprite.pixelsPerUnit;
             y *= sprite.pixelsPerUnit;
             // modify so pixel distance from bottom left corner instead of from center
             x += rect.width / 2;
             y += rect.height /2;
             // adjust for location of sprite on original texture
             x += rect.x;
             y += rect.y;
             // mouse position x and y subtract transform position x and y, then multiply by pixels per unit
            
            for(int yy=1; yy<SP.height-1;yy++)
            {
                for(int xx =1; xx<SP.width-1; xx++)
                {
                Color c =sprite.texture.GetPixel(xx,yy);
                c = new Color(c.r,c.g,c.b);
                //c.a=0;
                Scar_Image.SetPixel(xx,yy,c);
                }
            }
            
             
             
             for(int xxx=-3; xxx<3;xxx++)
             {
                for(int yyy =-3; yyy<3;yyy++)
                {
                    pixel = sprite.texture.GetPixel(Mathf.FloorToInt(x)-xxx , Mathf.FloorToInt(y)-yyy);
                    pixel = new Color(0,108,108);
                    Scar_Image.SetPixel(Mathf.FloorToInt(x)-xxx,Mathf.FloorToInt(y)-yyy,pixel);
                }
                
             }            
             //Debug.Log(pixel.ToString());                                
          
                
             
             
             //Debug.Log(pixels.ToString());


            Debug.Log(x);
            Debug.Log(y);
            
            //Scar_Image.SetPixel(Mathf.FloorToInt(x),Mathf.FloorToInt(y),pixels[0]);
            

           

            
            Scar_Image.Apply();
            SpriteRenderer.sprite = Sprite.Create(Scar_Image, new Rect(0,0, Scar_Image.width, Scar_Image.height), new Vector2(0.5f,0.5f));
            
            

             //SpriteRenderer.sprite = 
             //sprite.SetPixel(x,y,pixel);

         
        }
    }
}
