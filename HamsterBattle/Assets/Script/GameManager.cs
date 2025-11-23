using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   public CastleHealth playerCastle;
   public CastleHealth enemyCastle;
   
   void Awake()
   {
      Instance = this;
   }
   
   public void CastleDestroyed(GameObject castle)
   {
      if (castle.CompareTag("PlayerCastle"))
      {
         Debug.Log("¡Derrota! Tu castillo fue destruido.");
      }
      else
      {
         Debug.Log("¡Victoria! Destruiste el castillo enemigo.");
      }
   }
}
