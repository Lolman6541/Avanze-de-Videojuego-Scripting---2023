using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    IEnemy Clone();
    void Move();
    void OnTriggerEnter2D(Collider2D col);
    void PlayExplosion();
}