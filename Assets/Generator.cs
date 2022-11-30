using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    [SerializeField] Transform targetParent;
    [SerializeField] Transform start;
    [SerializeField] Transform mirrorPrefab;
    target[] targets;
    target end;

    private void Start()
    {
        targets = targetParent.GetComponentsInChildren<target>();
    }

    public void generate()
    {
        int index = Random.Range(0, targets.Length);
        end = targets[index];

        Vector2Int cur = new Vector2Int(-1, 0);
        Vector2Int dir = Vector2Int.right;

        //if(dfs(cur, dir))
        //{

        //}
    }

    public bool dfs(Vector2Int pos, Vector2Int dir)
    {
        if (pos == end.cord && dir == end.dir)
            return true;

        pos += dir;

        if (pos.x > 4 || pos.x < 0 || pos.y > 4 || pos.y < 0)
            return false;

        int addon = Random.Range(0, 10);
        int[] px = new int[3] { 0, 1, 2 };


        Vector2Int nextDir = Vector2Int.zero;

        for (int i = 0; i < px.Length; i++)
        {
            int idx = (px[i] + addon) % 3;
            if (idx == 0)
            {
                nextDir = dir;
            }
            else if (idx == 1)
            {
                nextDir.x = dir.y;
                nextDir.y = dir.x;
                Transform mirror = Instantiate(mirrorPrefab, null);
                //mirror.rotation.eulerAngles
                //MapLocator.instance.AddItem(pos, mirror);
            }
            else if (idx == 2)
            {
                nextDir.x = -dir.y;
                nextDir.y = -dir.x;
            }

            if(dfs(pos, nextDir))
            {
                return true;
            }
        }
        return false;
    }
}
