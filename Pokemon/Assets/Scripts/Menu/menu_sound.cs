using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_sound : MonoBehaviour
{
   public AudioSource mySound;
   public AudioClip hoverS;
   public AudioClip clickS;

   public void HoverSound(){

       mySound.PlayOneShot (hoverS);
   }
   public void ClickSound(){
       mySound.PlayOneShot(clickS);
   }
}
