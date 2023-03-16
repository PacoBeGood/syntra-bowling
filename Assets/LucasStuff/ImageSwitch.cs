using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeCoaching;

public class ImageSwitch : MonoBehaviour
{
    private float response;
    
    [SerializeField] private GameObject targetObject;
    [Space]
    [SerializeField] string url = "https://media.istockphoto.com/id/637918362/photo/come-with-me.jpg?b=1&s=170667a&w=0&k=20&c=SnR3W4JuzLDHmQAFDOH9lulkB_Vhl0vE4sJnYA6VQss=";
    [SerializeField] Vector2 textureRatio = new Vector2(5,1);
    [Header("Extra's")]
    [SerializeField] bool scaleOnZ = false;
    [SerializeField] Vector3 setRotation;
    

    void Start()
    {
        ChangeImageUrl(url);
    }

    public void ChangeImageUrl(string newUrl)
    {
        StartCoroutine(Request.getImage(url, (response) =>
        {
            float width = response.width;
            float height = response.height;
            GameObject original = targetObject;
            if (targetObject.scene.IsValid()) targetObject.SetActive(false);
            GameObject image = Instantiate(original);
            image.transform.rotation = original.transform.rotation;
            if (width > height)
            {
                float ratio = (float)width / height;
                width = 2;
                height = width / ratio;
            }
            else
            {
                float ratio = (float)height / width;
                height = 2;
                width = height / ratio;
            }

            //if(scaleOnZ) image.transform.localScale = new Vector3(width, 0.01f, height);
            //else image.transform.localScale = new Vector3(width, height, 0.01f);

            image.transform.position = new Vector3(original.transform.position.x, original.transform.position.y, original.transform.position.z); // waar in de wereld moet de afbeelding komen
            //image.transform.eulerAngles = setRotation;

            //image.GetComponent<Renderer>().material.mainTexture.wrapMode = TextureWrapMode.Repeat;
            image.GetComponent<Renderer>().material.mainTexture = response;
            image.SetActive(true);
        }));
    }
}