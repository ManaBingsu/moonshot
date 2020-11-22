using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class MapSetActive : MonoBehaviour
    {
        [SerializeField]
        private GameObject _Player;
        
        private int _mapIndex = 1;
        private int _recentIndex = 0;
        private List<GameObject> _wholeMapOrder = new List<GameObject>();
        private int _wholeMapOrderCount;
        private MapMaking _mapMaking;

        private void Awake()
        {
            _mapMaking = GetComponent<MapMaking>();
        }
        void Update()
        {
            if (_mapMaking.IsMapCreate == true &&
                _mapIndex < _wholeMapOrderCount &&
                _recentIndex < _wholeMapOrderCount &&
                    _Player.transform.position.y >= _wholeMapOrder[_recentIndex].transform.position.y)
            {
                SetMapActive();
                SetMapDisActive();
            }
        }

        public void MakeList()
        {
            int WholeMapOrderCount = gameObject.transform.GetComponent<MapMaking>().WholeMapOrder.Count;
            for (int i = 0; i < WholeMapOrderCount; i++)
                _wholeMapOrder.Add(gameObject.transform.GetComponent<MapMaking>().WholeMapOrder[i]);
            _wholeMapOrderCount = gameObject.transform.GetComponent<MapMaking>().WholeMapOrder.Count;
        }

        void SetMapActive()
        {
            _wholeMapOrder[_mapIndex].SetActive(true);
            _mapIndex++;
            _recentIndex++;
        }

        void SetMapDisActive()
        {
            if(_recentIndex >= 3)
            {
                _wholeMapOrder[_recentIndex-3].SetActive(false);
            }
        }
    }
}

