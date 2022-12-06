using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFold : MonoBehaviour
{
    SpriteRenderer image;
    private void OnEnable()
    {
        image = GetComponent<SpriteRenderer>();
        Color c = image.color;
        image.color = new Color(c.r, c.g, c.b, 0f);

        InvokeRepeating("fadeScreen", 5, 0.2f);
    }

    void fadeScreen()
    {
        Color c = image.color;
        float alpha = Mathf.Clamp01(c.a + 0.1f);
        image.color = new Color(c.r, c.g, c.b, alpha);

        if (alpha == 1f)
            CancelInvoke();
    }

    public void clearFold()
    {
        CancelInvoke();
        Color c = image.color;
        image.color = new Color(c.r, c.g, c.b, 0f);
    }
}
