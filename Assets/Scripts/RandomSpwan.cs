using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpwan : MonoBehaviour {
    
    public Transform[] points;
    public Enemy enemy;
    public int enemyCount;
    public float createTime = 3.0f;

    // Use this for initialization
    void Start () {
        points = GameObject.Find("spawn_points").GetComponentsInChildren<Transform>();
        Debug.Log(points);
        StartCoroutine(this.CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        for(int i =0; i< enemyCount; i++) { 

            
            int idx = Random.Range(1, points.Length);
            Instantiate(enemy, points[idx].position, Quaternion.identity);
            yield return new WaitForSeconds(createTime);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
}