using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_move : MonoBehaviour
{
	//Cette variable ajuste la vitesse du personnage, ici initialisée à 5
	public float speed = 5;
    //Cette variable prend la direction indiquée par les flèches directionnelles de l'utilisateur
    Vector2 dir;
    //Cette variable prend en compte l'animation du sprite du personnage
    Animator anim;
    //Cette variable va permettre au personnage de s'immobiliser dans la direction vers laquelle il s'est arrêté
    int immobile = 0;
    //Cette variable permet de ne pas prendre en compte d'autre input tant que le joueur n'a pas fini de bouger
    bool ismoving = false;
    public bool menu {get; set;}
    bool isTalking = false;  //quand il parle à un NPC, si true, le perso ne peut pas bouger

    // Start is called before the first frame update
    void Start()
    {
        //On récupère les animations du sprite concerné par le script
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!ismoving && menu == false && isTalking == false)
        {
            dir.x = Input.GetAxisRaw("Horizontal");
            dir.y = Input.GetAxisRaw("Vertical");
            //On évite le déplacement en diagonale grâce à cette condition
            if(dir.x != 0)
            dir.y = 0;

            //Si l'utilisateur à appuyer sur un bouton pour effectuer un mouvement
            if(dir != Vector2.zero)
            {
                //Variable qui contient la position d'arrivée du joueur après son mouvement
                var targetPos = transform.position;
                targetPos.x += dir.x;
                targetPos.y += dir.y;

                //On vérifie que le joueur ne va pas rentrer dans un objet solide
                if(isWalkable(targetPos))
                {
                    //On fait bouger le joueur
                    StartCoroutine(Move(targetPos));
                }
                //Cette boucle permet au joueur de se tourner sans bouger lorsqu'il est à côté d'un objet solide
                else
                {
                    if(dir.x > 0)
                    {
                        immobile = 1;
                    }
                    else if(dir.x < 0)
                    {
                        immobile = 2;
                    }
                    else if(dir.y > 0)
                    {
                        immobile = 3;
                    }
                    else if(dir.y < 0)
                    {
                        immobile = 0;
                    }
                }
            }
            //Cette fonction permet de paramétrer les animations du joueur. Ici, elle sert a paramétrer les animations d'immobilisation (le joueur se tourne vers ladroite sans se déplacer)
            setParam();
        }
        Interact();
        goToScene();
    }

    IEnumerator Move(Vector3 targetPos)
    {
        //On annonce que le joueur bouge
        ismoving = true;
        //On désactive le BoxCollider2D du joueur
        GetComponent<BoxCollider2D>().enabled = false;
        //On s'assure que le joueur avance bien d'exactement une case à la fois et pas légèrement moins ou plus, ce qui à la ongue peut créer des bugs
        targetPos.x = Mathf.Ceil(targetPos.x) - 0.5f;
        targetPos.y = Mathf.Ceil(targetPos.y) - 0.5f;

        //Tant que le joueur n'a pas fini son mouvement
        while(targetPos != transform.position)
        {
            //On fait avancer le joueur
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
            //On appelle encore une fois les animations du joueur
            setParam();
        }
        //On assigne au joueur la position d'arrivée une fois le mouvement effectué
        transform.position = targetPos;

        /*
        if(Physics2D.OverlapCircle(transform.position, 0.3f, LayerMask.GetMask("MoveScene")))
        {
        	Debug.Log("here");
            GetComponent<BoxCollider2D>().enabled = true;
        }*/
        Grass();
        //On annonce que le joueur à finit son mouvement
        ismoving = false;
    }
    void goToScene(){
    	var collider = Physics2D.OverlapCircle(transform.position, 0.3f, LayerMask.GetMask("MoveScene"));
        if(collider != null){
        	GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    //AJOUT
    void Interact(){
    	Vector3 facingDir = new Vector3(1,0);
    	//direction dans laquelle le perso fait face
    	if(immobile == 0) //vers le bas
    		facingDir = new Vector3(0,-1);
    	else if(immobile ==1) //vers la droite
    		facingDir = new Vector3(1,0);
    	else if (immobile == 2) //vers la gauche
    		facingDir = new Vector3(-1,0);
    	else if (immobile == 3) //vers le haut
    		facingDir = new Vector3(0,1);

    	var interactPos = transform.position + facingDir;

    	var collider = Physics2D.OverlapCircle(interactPos, 0.3f, LayerMask.GetMask("Interactable"));
    	if(collider != null){
                GetComponent<BoxCollider2D>().enabled = true;
        		collider.GetComponent<Interactable>()?.Interact();
                if(collider.GetComponent<NPCController>().isNPCTalking() == true){
                    isTalking = true;
                }else{
                    isTalking = false;
                }
    	}else{
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    
    private bool isWalkable(Vector3 targetPos)
    {   //Si la position d'arrivée du joueur est dans le layer Solid, alors on retourne false et on empêche le mouvement.
        //AJOUT : egalement si layer interactable
        if(Physics2D.OverlapCircle(targetPos,0.1f,LayerMask.GetMask("Solid") | LayerMask.GetMask("Interactable") ) != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void Grass()
    {
        if(Physics2D.OverlapCircle(transform.position,0.1f,LayerMask.GetMask("Grass")) != null)
        {
            if(Random.Range(1,101) <= 10)
            {
                SceneManager.LoadScene("Battle");
            }
        }
    }

    void setParam()
    {
    	//Immobile
    	if(!ismoving)
    	{
    		//Cas où le personnage allait vers le bas
    		if(immobile == 0)
    		{
    			anim.SetInteger("Dir",0);
    		}
    		//Cas où le personnage allait vers la droite
    		else if(immobile == 1)
    		{
    			anim.SetInteger("Dir",5);
    		}
    		//Cas où le personnage allait vers la gauche
    		else if(immobile == 2)
    		{
    			anim.SetInteger("Dir",6);
    		}
    		//Cas où le personnage allait vers le haut
    		else if(immobile == 3)
    		{
    			anim.SetInteger("Dir",7);
    		}
    	}

    	//Droite
    	else if(dir.x > 0)
    	{
    		if(Input.GetKey(KeyCode.Space))
    		{
    			anim.SetInteger("Dir",8);
    			speed = 10;
    		}
    		else
    		{
    			anim.SetInteger("Dir",1);
    			speed = 5;
    		}
    		immobile = 1;
    	}
    	//Gauche
    	else if(dir.x < 0)
    	{
    		if(Input.GetKey(KeyCode.Space))
    		{
    			anim.SetInteger("Dir",9);
    			speed = 10;
    		}
    		else
    		{
    			anim.SetInteger("Dir",2);
    			speed = 5;
    		}
    		immobile = 2;
    	}
    	//Bas
    	else if(dir.y < 0)
    	{
            //Bouton pour courir
    		if(Input.GetKey(KeyCode.Space))
    		{
    			anim.SetInteger("Dir",10);
    			speed = 10;
    		}
    		else
    		{
    			anim.SetInteger("Dir",3);
    			speed = 5;
    		}
    		immobile = 0;
    	}
    	//Haut
    	else if(dir.y > 0)
    	{
    		if(Input.GetKey(KeyCode.Space))
    		{
    			anim.SetInteger("Dir",11);
    			speed = 10;
    		}
    		else
    		{
    			anim.SetInteger("Dir",4);
    			speed = 5;
    		}
    		immobile = 3;
    	}

    	//Cas où l'on court
    	
    }
}
