using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    public Camera cam;
    public GameObject bullet;
    private float spawn_timer = 0;

    // Update is called once per frame
    void Update()
    {
        spawn_timer -= Time.deltaTime;
        if(spawn_timer <= 0)
        {
            spawn_timer = 1;
            SpawnBullet();
        }
    }

    public void SpawnBullet()
    {
        GameObject new_bullet = Instantiate(bullet);
        int x_pos, y_pos;

        if (Random.value < 0.5f)
        {
            if (Random.value < 0.5f)
            {
                x_pos = 0;
            }
            else
            {
                x_pos = cam.scaledPixelWidth;
            }

            y_pos = Random.Range(0, cam.scaledPixelHeight);
        }
        else
        {
            if (Random.value < 0.5f)
            {
                y_pos = 0;
            }
            else
            {
                y_pos = cam.scaledPixelHeight;
            }

            x_pos = Random.Range(0, cam.scaledPixelWidth);
        }

        Vector3 SpawnPoint = new Vector3(x_pos, y_pos, 0);
        SpawnPoint = cam.ScreenToWorldPoint(SpawnPoint);
        SpawnPoint.z = 0;

        new_bullet.transform.position = SpawnPoint;
    }   
}
