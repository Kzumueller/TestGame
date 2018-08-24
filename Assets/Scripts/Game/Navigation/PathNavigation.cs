using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNavigation : MonoBehaviour {

    public Transform goalTransform;
    public float speed = 10f;

    private TileMapManager manager;
    private Stack<Tile> path;
    private Tile nextTile;
    private SearchAlgorithm search;

    private void Awake() {
        manager = GameObject.FindWithTag("TileMapPlane").GetComponent<TileMapManager>();
        search = new AStarSearch() { manager = manager};
    }

    // Use this for initialization
    void Start () {
        if (null != goalTransform)
            StartSearch(goalTransform.position);
	}

    public void StartSearch(Vector3 goalPosition) {
        var start = manager.VectorToTile(transform.position);
        var goal = manager.VectorToTile(goalPosition);

        if (search.IsBlocked(goal)) {
            Debug.Log($"Cannot start search, goal {goal} is blocked");
            return;
        }

        path = search.GetPath(start, goal);
        if (path.Count > 0)
            nextTile = path.Pop();
    }
	
	// Update is called once per frame
	void Update () {
        if (null == nextTile) return;

        var tileCenter = manager.TileCenter(nextTile);
        tileCenter.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, tileCenter, speed * Time.deltaTime);
        transform.LookAt(tileCenter, Vector3.up);

        var distance = Vector3.Distance(transform.position, tileCenter);

        if (.05f > distance && 0 < path.Count)
            nextTile = path.Pop();
	}
}
