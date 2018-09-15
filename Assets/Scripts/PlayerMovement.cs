using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0.64f;

    public Movement m;

    public float GameFieldX = 0;
    public float GameFieldY = 0;
    public float GameFieldWidth = 10.24f;
    public float GameFieldHeigh = 10.24f;

    private Vector2 _movementDirection;

	void Start () {

        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");

        CamMovement camMove = cam.GetComponent<CamMovement>();
        camMove.player = gameObject;

        m = gameObject.GetComponent<Movement>();

        m.canMoveUp = true;
        m.canMoveDown = true;
        m.canMoveLeft = true;
        m.canMoveRight = true;
    }
	
	void Update () {
        //if (Input.GetKeyDown(KeyCode.D)) {
        //    transform.Translate(new Vector3(0.64f, 0f));
        //} else if (Input.GetKeyDown(KeyCode.A)) {
        //    transform.Translate(new Vector3(-0.64f, 0f));
        //} else if (Input.GetKeyDown(KeyCode.W)) {
        //    transform.Translate(new Vector3(0f, 0.64f));
        //} else if (Input.GetKeyDown(KeyCode.S)) {
        //    transform.Translate(new Vector3(0f, -0.64f));
        //}

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.x != 0)
        {
            if ((input.x < 0 && !m.canMoveRight) || (input.x > 0 && !m.canMoveLeft))
            {
                return;
            }
            _movementDirection.Set(input.x, 0f);
        }
        else if (input.y != 0)
        {
            if ((input.y < 0 && !m.canMoveDown) || (input.y > 0 && !m.canMoveUp))
            {
                return;
            }
            _movementDirection.Set(0f, input.y);
        }
        else
        {
            _movementDirection = Vector2.zero;
        }

        Vector3 destination = transform.position + (Vector3)_movementDirection * speed * Time.deltaTime;

        if (destination.x < GameFieldX) { destination.x = GameFieldX; }
        else if (destination.y < GameFieldY) { destination.y = GameFieldY; }
        else if (destination.x > GameFieldWidth - GameFieldX) { destination.x = GameFieldWidth - GameFieldX; }
        else if (destination.y > GameFieldHeigh - GameFieldY) { destination.y = GameFieldHeigh - GameFieldY; }

        transform.position = destination;

    }

}
