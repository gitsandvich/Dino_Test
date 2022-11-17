using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_scratch : MonoBehaviour
{
    public Color pixel;
    public SpriteRenderer SpriteRenderer;
    Texture2D Scar_Image;
    public Texture2D Source;
    public Rect SourceRect;
    public Sprite sprite;
    public float Circle_X, Circle_NX, Circle_Y, Circle_NY;
    public float Circle_R;
    public float Circle_RP;
    public int FPC, CPC,CPC_S;// full pixel count, color pixel count, static;
    public bool ScratchFinished = false;
    public Animator anim;
    //private GameObject 
    // Start is called before the first frame update
    void Start()
    {
        FPC = Source.width * Source.height;
        
        if (Circle_R <= 0)
        {
            Circle_R = 5;
        }
        
        ResetDirt();
        for (int yy = 1; yy < Source.height - 1; yy++)
        {
            for (int xx = 1; xx < Source.width - 1; xx++)
            {
                pixel = sprite.texture.GetPixel(xx, yy);

                if (pixel.a != 0)
                {
                    CPC++;
                }

            }
        }
        CPC_S = CPC; //color pixel count, static;
    }
   
    // Update is called once per frame
    public void PixelAlter(Vector2 pos)
    {
        if(ScratchFinished == true)
        {
            return;
        }
        //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        sprite = SpriteRenderer.sprite;

        // calculate the distance of the mouse from the center of the sprite's transform
        float x = pos.x - this.transform.position.x;
        float y = pos.y - this.transform.position.y;
        // convert the x and y values from units to pixels             
        //x *= sprite.pixelsPerUnit;
        //y *= sprite.pixelsPerUnit;
        y *= sprite.pixelsPerUnit / this.transform.localScale.y;
        x *= sprite.pixelsPerUnit / this.transform.localScale.x;
        // modify so pixel distance from bottom left corner instead of from center
        x += SourceRect.width / 2;
        y += SourceRect.height /2;
        // adjust for location of sprite on original texture
        x += SourceRect.x;
        y += SourceRect.y;
        // mouse position x and y subtract transform position x and y, then multiply by pixels per unit
        Circle_X = x + Circle_R;
        Circle_NX = x - Circle_R;
        Circle_Y = y + Circle_R;
        Circle_NY = y - Circle_R;
        

        //xx yy���� x y���?
        for (int yy=1; yy< Source.height-1;yy++)
        {
          for(int xx =1; xx< Source.width-1; xx++)
           {
                if(yy > Circle_NY && yy < Circle_Y && xx > Circle_NX && xx < Circle_X)
                {
                    Circle_RP = (Mathf.Pow((xx - x), 2) + Mathf.Pow((yy - y), 2) );
                    if(Circle_RP <= Circle_R)
                    {
                        
                        pixel = sprite.texture.GetPixel(xx, yy);
                        if (pixel.a != 0)
                        {
                            CPC--;
                        }
                        pixel.a = 0;
                        Scar_Image.SetPixel(xx, yy, pixel);
                    }
                    else
                    {
                        normal_color_set(xx, yy);
                    }
                    
                }
                else
                {
                    normal_color_set(xx, yy);
                }
                             
                
             
             //c.a=0;
             
           }
         }
        /*
        for (int xxx = -3; xxx < 3; xxx++)
        {
            for (int yyy = -3; yyy < 3; yyy++)
            {
            pixel = sprite.texture.GetPixel(Mathf.FloorToInt(x) - xxx, Mathf.FloorToInt(y) - yyy);
            pixel.a = 0;
            Scar_Image.SetPixel(Mathf.FloorToInt(x) - xxx, Mathf.FloorToInt(y) - yyy, pixel);
            }

        }
        */

        Scar_Image.Apply();
        SpriteRenderer.sprite = Sprite.Create(Scar_Image, new Rect(0, 0, Scar_Image.width, Scar_Image.height), new Vector2(0.5f, 0.5f));
        if(CPC_S - CPC >4000) //color pixel count decresing
        {
            ScratchFinished = true;
            SpriteRenderer.sprite = null;
        }


    }
    void normal_color_set(int xx,int yy)
    {
        Color c = sprite.texture.GetPixel(xx, yy);

        c = new Color(c.r, c.g, c.b, c.a);
        Scar_Image.SetPixel(xx, yy, c);
    }
    public void ResetDirt() 
    {
        SpriteRenderer.sprite = Sprite.Create(Source, new Rect(0, 0, Source.width, Source.height), new Vector2(0.5f, 0.5f));
        Scar_Image = new Texture2D(Source.width, Source.height);
        this.GetComponent<BoxCollider2D>().size = new Vector2(Source.width / 100f, (Source.height / 100f));
        this.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
        sprite = SpriteRenderer.sprite;
        SourceRect = sprite.textureRect;
        ScratchFinished = false;
        CPC = CPC_S;
        anim.SetTrigger("Expanding");
    }
}
