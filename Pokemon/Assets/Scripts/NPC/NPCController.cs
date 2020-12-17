using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour , Interactable 
{
    //Direction du NPC en intéraction:
    [SerializeField] List<Sprite> mySprites;
    SpriteRenderer spriteRenderer;
    private Vector3[] NPCRange; //Les 4 directions du NPC
    private bool isTalking;
    private int NPCdirectionFace;
    //Boite de dialogue:
    private StartAConv myConvo;
    public GameObject dialogBox;
    
    // Start is called before the first frame update
    void Start()
    {
        myConvo = GetComponent<StartAConv>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isTalking = false;

        NPCRange = new Vector3[4]; //Allocation 4 emplacements mémoire pour 4 directions
        NPCRange[0] = new Vector3(0,1); //Dialogue vers le haut
        NPCRange[1] = new Vector3(0,-1); //Dialogue vers le bas
        NPCRange[2] = new Vector3(-1,0); //Dialogue vers la gauche
        NPCRange[3] = new Vector3(1,0); //Dialogue vers la droite
        NPCdirectionFace = 5;
    }
    public bool isNPCTalking(){
        return isTalking;
    }
    public void Interact(){
        
        if(!dialogBox.activeInHierarchy){
            isTalking = false;
            interactionPosInit();
        }
        //Dialogue
        if(Input.GetKeyDown(KeyCode.Space)){
            if(dialogBox.activeInHierarchy){
                myConvo.ReadNext();
            }else{
                isTalking = true;
                dialogBox.SetActive(true);
                myConvo.StartConvo(1);

                //Si dialogue non activé avant, et mtn oui, le NPC se met face au joueur
                //Sinon il est censé déjà être face 
                for(int i = 0 ; i < 4 ; i++){
                var interactPos = transform.position + NPCRange[i];
                var collider = Physics2D.OverlapCircle(interactPos, 0.3f, LayerMask.GetMask("Hero"));
                    if(collider != null){
                        NPCdirectionFace = i;
                        i = 5; //On arrête le for
                    }
                }   
                switch(NPCdirectionFace){
                    case 0:
                        interactionPosHaut();
                        break;
                    case 1:
                        interactionPosBas();
                        break;
                    case 2:
                        interactionPosGauche();
                        break;
                    case 3:
                        interactionPosDroite();
                        break;
                }
            }
        }
    }

    public void interactionPosHaut(){
        spriteRenderer.sprite = mySprites[0];
    }
    public void interactionPosBas(){
        spriteRenderer.sprite = mySprites[1];
    }
    public void interactionPosGauche(){
        spriteRenderer.sprite = mySprites[2];
    }
    public void interactionPosDroite(){
        spriteRenderer.sprite = mySprites[3];
    }
    public void interactionPosInit(){ //Sprite initial
        spriteRenderer.sprite = mySprites[4];
    }
}