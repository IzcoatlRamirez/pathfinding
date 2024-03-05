// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace Cainos.PixelArtTopDown_Basic
// {
//     public class TopDownCharacterController : MonoBehaviour
//     {
//         public float speed;
//         private Animator animator;
//         private Transform player;
//         [SerializeField] private LayerMask obstacleLayer;
//         [SerializeField] private float radio;


//         public Vector2 targetPosition;

//         private void Start()
//         {
//             animator = GetComponent<Animator>();
//             player = GetComponent<Transform>();
//             StartCoroutine(MoveToTarget());

//         }
//         private void Stop()
//         {
//             GetComponent<Rigidbody2D>().velocity = Vector2.zero;
//             animator.SetBool("IsMoving", false);
//         }

//         private void MoveTop()
//         {
//             Vector2 dir = Vector2.zero;
//             dir.y = 1;
//             animator.SetInteger("Direction", 1);
//             dir.Normalize();
//             animator.SetBool("IsMoving", dir.magnitude > 0);
//             GetComponent<Rigidbody2D>().velocity = speed * dir;
//             Invoke("Stop", 1f);
//         }

//         private void MoveBottom()
//         {
//             Vector2 dir = Vector2.zero;
//             dir.y = -1;
//             animator.SetInteger("Direction", 0);
//             dir.Normalize();
//             animator.SetBool("IsMoving", dir.magnitude > 0);
//             GetComponent<Rigidbody2D>().velocity = speed * dir;
//             Invoke("Stop", 1f);
//         }

//         private void MoveLeft()
//         {
//             Vector2 dir = Vector2.zero;
//             dir.x = -1;
//             animator.SetInteger("Direction", 3);
//             dir.Normalize();
//             animator.SetBool("IsMoving", dir.magnitude > 0);
//             GetComponent<Rigidbody2D>().velocity = speed * dir;
//             Invoke("Stop", 1f);
//         }

//         private void MoveRight()
//         {
//             Vector2 dir = Vector2.zero;
//             dir.x = 1;
//             animator.SetInteger("Direction", 2);
//             dir.Normalize();
//             animator.SetBool("IsMoving", dir.magnitude > 0);
//             GetComponent<Rigidbody2D>().velocity = speed * dir;
//             Invoke("Stop", 1f);
//         }

//         private IEnumerator MoveToTarget()
//         {
//             while ((Vector2)transform.position != targetPosition)
//             {
//                 Vector2 currentPos = transform.position;

//                 float stepsG = Mathf.Abs(currentPos.x - targetPosition.x) + Mathf.Abs(currentPos.y - targetPosition.y);

//                 // Inicializa la mejor dirección y el mejor puntaje
//                 Vector2 bestDirection = Vector2.zero;
//                 float bestScore = float.MaxValue;

//                 foreach (Vector2 direction in new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right })
//                 {
//                     Vector2 neighborPos = currentPos + direction;

//                     if (!Physics2D.OverlapCircle(neighborPos, radio, obstacleLayer))
//                     {
//                         Debug.Log("No se encontró obstáculo");
              
//                         float neighborDistanceH = Vector2.Distance(neighborPos, targetPosition);

//                         float score = neighborDistanceH + stepsG + 1;

//                         if (score < bestScore)
//                         {
//                             bestScore = score;
//                             bestDirection = direction;
//                         }
//                     }
//                 }

//                 MoveInDirection(bestDirection);
//                 yield return new WaitForSeconds(1f);
//             }

//             Debug.Log("Llegó a la posición deseada.");
//         }

//         private void MoveInDirection(Vector2 direction)
//         {
//             if (direction == Vector2.up)
//                 MoveTop();
//             else if (direction == Vector2.down)
//                 MoveBottom();
//             else if (direction == Vector2.left)
//                 MoveLeft();
//             else if (direction == Vector2.right)
//                 MoveRight();
//         }

//         private void OnDrawGizmos()
//         {
//             Gizmos.color = Color.red;
//             Gizmos.DrawWireSphere(transform.position, radio);
//         }

//     }
// }
