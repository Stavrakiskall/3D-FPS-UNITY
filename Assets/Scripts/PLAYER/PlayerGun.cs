using UnityEngine;
using UnityEngine.VFX;

public class PlayerGun : MonoBehaviour
{
    public Transform gunBarrel;
    public VisualEffect pioupiouVFX;
    public AudioSource piouipouSFX;

    public void Shoot()
    {
        Debug.DrawRay(gunBarrel.position, gunBarrel.forward * 3f, Color.blue, 5f);
        Debug.DrawRay(gunBarrel.position, -gunBarrel.forward * 3f, Color.cyan, 5f);
        Debug.DrawRay(gunBarrel.position, gunBarrel.up * 3f, Color.green, 5f);
        Debug.DrawRay(gunBarrel.position, -gunBarrel.up * 3f, Color.yellow, 5f);
        Debug.DrawRay(gunBarrel.position, gunBarrel.right * 3f, Color.red, 5f);
        Debug.DrawRay(gunBarrel.position, -gunBarrel.right * 3f, Color.magenta, 5f);

        Vector3 shootDirection = gunBarrel.right;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, Quaternion.LookRotation(shootDirection));
        bullet.GetComponent<Rigidbody>().linearVelocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * 80;
    }
}