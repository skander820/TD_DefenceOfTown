using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {
    // Start is called before the first frame update

    public float hp = 150;
    private float totalHp;
    public GameObject explosionEffect;
    private Slider hpSlider;
    Transform[] position;
    int pos_index = 1;

    public int move_speed = 5;
    void Move () {
        transform.Translate ((position[pos_index].position - transform.transform.position).normalized * Time.deltaTime * move_speed);
        if (Vector3.Distance (position[pos_index].position, transform.position) <= 0.2f) {
            pos_index = (pos_index + 1) % position.Length;
            // Debug.Log (pos_index);
        }

    }
    void Start () {
        position = PathManager.getPath ();
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();
        // Debug.Log(hpSlider);


    }

    // Update is called once per frame
    void Update () {
        Move ();
    }
    //   void OnDestroy()
    // {
    //     EnemySpawner.CountEnemyAlive--;
    // }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
    }
}