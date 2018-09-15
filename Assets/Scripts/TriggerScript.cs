using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    private float _lastPosX = 0;
    private float _lastPosY = 0;

    private Vector3 _gObjPos;
    private Vector3 _trigElemPos;

    private Movement _m;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {	
	}

    void OnTriggerEnter2D(Collider2D col) {
        _gObjPos = col.transform.position;
        if (col.gameObject.tag == "Player" && Vector2.Distance(_gObjPos, _trigElemPos) < 0.715f) {

            _m = col.gameObject.GetComponent<Movement>();

            
            _trigElemPos = transform.position;

            _lastPosX = _gObjPos.x;
            _lastPosY = _gObjPos.y;

        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Player" && Vector2.Distance(_gObjPos, _trigElemPos) < 0.715f) {
            _gObjPos = col.transform.position;

            if (_lastPosX < _gObjPos.x) {
                print("Left");
                _m.canMoveLeft = false;
            }

            if (_lastPosX > _gObjPos.x) {
                print("Right");
                _m.canMoveRight = false;
            }

            if (_lastPosY < _gObjPos.y) {
                print("Up");
                _m.canMoveUp = false;
            }

            if (_lastPosY > _gObjPos.y) {
                print("Down");
                _m.canMoveDown = false;
            }

            _lastPosX = _gObjPos.y;
            _lastPosY = _gObjPos.y;
        }
    }


    void OnTriggerExit2D(Collider2D col) {
         if (col.gameObject.tag == "Player") {
            _m.canMoveUp = true;
            _m.canMoveDown = true;
            _m.canMoveLeft = true;
            _m.canMoveRight = true;
        }
    }
}
