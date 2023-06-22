using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
   public DialogueTrigger trigger;

   private void OnCollisionEnter2D(Collision2D col)
   {
      if (Collision.gameObject.CompareTag("Player")==true) 
         trigger.StartDialogue();
   }
}
