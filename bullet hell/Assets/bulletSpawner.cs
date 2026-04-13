using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    public Camera cam;
    public GameObject bullet;
    private float spawn_timer = 0;
    public int max_bullets = 5;
    public float min_time = 0.25f;
    public float max_time = 1f;

    // Update is called once per frame
    void Update()
    {
        spawn_timer -= Time.deltaTime;
        if(spawn_timer <= 0)
        {
            spawn_timer = Random.Range(min_time, max_time);

            int bullets_to_spawn = Random.Range(1, max_bullets + 1);
            
            for (int i = 0; i < bullets_to_spawn; i++)
            {
                SpawnBullet();
            }
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
