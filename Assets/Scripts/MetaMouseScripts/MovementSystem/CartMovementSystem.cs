using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CartMovementSystem : MonoBehaviour
{
    public Vector2 mouseVelocity;
    public float mouseSpeed;
    public float mouseAngularSpeed;
    private int rotateKey;
    private int moveKey;
    private MetaMouse metaMouse;

    Vector2 CartMovement(float moveKey, float linearSpeed, float rotateKey, float angularSpeed)       //object의 앞 방향을 가져와서 속도 벡터로 설정한다.
    {
        Vector2 mouseVelocity;
        CartRotate(rotateKey, angularSpeed);

        mouseVelocity = transform.right * linearSpeed * moveKey;

        return mouseVelocity;
    }

    void CartRotate(float rotateKey, float angularSpeed)         //함수 인스턴스에 metaMouse가 있는 건 나중에 Vector3to2 함수를 다른 스크립트에 이동하면서 수정할 수 있습니다.
    {
        float angle;
        angle = rotateKey * angularSpeed * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, 0, angle);
    }
}