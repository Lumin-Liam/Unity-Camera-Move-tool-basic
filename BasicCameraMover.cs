using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSingleplayerMenu : MonoBehaviour
{
    bool disable = false;
    float x_rotation;
    float y_rotation;
    float x_pos;
    float z_pos;
    public float max_x_rotation;
    public float max_y_rotation;
    public float max_x_pos;
    public float max_z_pos;
    public float rotate_step;
    public float transform_step;
    // Start is called before the first frame update
    void Start()
    {
        x_rotation = transform.eulerAngles.x;
        y_rotation = transform.eulerAngles.y;
        x_pos = transform.position.x;
        z_pos = transform.position.z;
        Debug.Log(" "+ x_rotation + " " +  y_rotation + " " + x_pos + " " + z_pos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (x_rotation <= max_x_rotation)
        {
            x_rotation += rotate_step;
        }
        if (y_rotation <= max_y_rotation)
        {
            y_rotation += rotate_step;
        }
        if (x_pos >= max_x_pos)
        {
            x_pos += transform_step;
        }
        if (z_pos >= max_z_pos)
        {
            z_pos += transform_step;
        }
        transform.position = new Vector3(x_pos, transform.position.y, z_pos);
        transform.eulerAngles = new Vector3(x_rotation, y_rotation, 0);
        if (z_pos <= max_z_pos && x_pos <= max_x_pos && y_rotation >= max_y_rotation && x_rotation >= max_x_rotation)
        {
            disable = true;
        }
        if (disable == true)
        {
            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour mb in scripts)
            {
                if (mb.GetType().Name == "GoToSingleplayerMenu")
                {
                    mb.enabled = false;
                }
                disable = false;
            }
        }
    }
}
