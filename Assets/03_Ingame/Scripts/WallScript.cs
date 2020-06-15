using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField] private float Count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ReleaseWall()
    {
        yield return new WaitForSeconds(Count);
        Destroy(this);
        //이거 솔직히 나중에 넣을 연출 대신으로 대충 만든거임.
    }
}
