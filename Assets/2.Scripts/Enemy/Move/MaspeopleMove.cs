﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class MaspeopleMove : EnemyMove
    {

        override protected IEnumerator TrackingPlayer()
        {

            _time = 0;
            _startPosition = this.transform.position;


            while (true)
            {
                _speed += 0.1f;
                _speed = Mathf.Clamp(_speed, 1f, _maxSpeed);
                transform.Translate(_playerDirction * _speed * Time.smoothDeltaTime, Space.World);
                
                yield return null;
                PlayerDistanceCalculation();
                if (_playerDistance > _lookingPlayerRange)
                {
                    _speed = _startSpeed;
                    StartCoroutine(Translate());
                    break;
                }
            }
        }
    }

}