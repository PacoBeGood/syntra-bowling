using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeCoaching;

public class BillboardPlacer : MonoBehaviour
{
    [SerializeField] GameObject billboardPrefab;
    [SerializeField] GameObject dividerPrefab;
    [SerializeField] List<string> urls;
    [Space]
    [SerializeField] Vector2 size = new Vector2(5f, 2f);
    [Space]
    [SerializeField] bool useDividers = true;
    [SerializeField] float dividerWidth = 0.05f;
    [SerializeField] Color dividerColor = Color.black;
    float offset;


    IEnumerator Start()
    {
        // Board making
        Vector3 tempRotation = transform.localEulerAngles; // Store rotation
        transform.localEulerAngles = Vector3.zero; // Reset
        for (int i = 0; i < urls.Count; i++)
        {
            yield return StartCoroutine(CreateBillBoards(urls[i], i));
            if (useDividers && i != urls.Count - 1) CreateDivider();
        }
        transform.localEulerAngles = tempRotation; // Restore rotation
        //Debug.Log(offset);
    }

    private IEnumerator CreateBillBoards(string url, int listIndex = 0)
    {
        yield return StartCoroutine(Request.getImage(url, (response) =>
        {
            // Create
            GameObject board = Instantiate(billboardPrefab, transform);
            board.name = $"Billboard{listIndex+1} ({response.width}x{response.height})";
            // Get variables
            float width = response.width;
            float height = response.height;
            // Ratio (Scale horizontaly)
            float ratio = (float)height / width;
            height = size.y;
            width = height / ratio;
            // Modify object
            board.GetComponent<Renderer>().material.mainTexture = response;
            board.transform.localPosition = new Vector3(0, 0, width/2 + offset);
            board.transform.localScale = new Vector3(width, 1, height);
            offset += width;
        }));
    }

    private void CreateDivider()
    {
        GameObject divider = Instantiate(dividerPrefab, transform);
        divider.transform.localPosition = new Vector3(0, 0, offset + dividerWidth / 2);
        divider.transform.localScale = new Vector3(dividerWidth, 1, size.y);
        divider.GetComponent<Renderer>().material.color = dividerColor;
        offset += dividerWidth;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(new Vector3(0, 0, size.x/2), new Vector3(0.01f,size.y,size.x));
    }
}
