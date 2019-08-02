using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia : MonoBehaviour
{

    //marca a posição do jogador//
    private Transform target;
    private Transform newTarget;
    //Marca o Y, dentro de um Vector2//
    private Vector2 targetY;
    //Marca o X, dentro de um Vector2//
    private Vector2 targetX;
    //Distancia pro robo ve//
    public float distanciaPraDeteccao;
    //Distancia Geral//
    private float playerDistance;
    //Calcula a distancia do ponto Y e o Player//
    private float playerDistanceY;
    //Calcula a distancia do ponto X e o Player//
    private float playerDistanceX;
    //Coloque aqui a distancia ideal para o inimigo parar//
    public float distanciaIdeal;
    //Velocidade do inimigo (Lembrar de colocar no Unity)//
    public float velocidade;
    //Seleciona o tipo do robô// 
    public bool roboAtira;
    //Seleciona o tipo de tiro, caso atire// 
    public bool tiroTeleguiado;
    //gameObject dos tiros pra instanciar//
    public GameObject tiroNormal;
    public GameObject tiroQueSegue;
    //Cooldown entre tiros//
    private float tempoEntreTiros;
    public float tempoInicialEntreTiros;
    //Selecionar se o robô é o cachorro ou não//
    public bool ehOcachorro;
    //Saber se ele mordeu//
    public bool mordeu;
    //tempo entre mordidas//
    public float tempoMordida;
    //próxima mordida//
    private float proxMordida;
    //Rosa dos Ventos//
    public bool cima;
    public bool baixo;
    public bool esquerda;
    public bool direita;
    //Direção formula//
    private Vector2 heading;
    private float distance;
    private Vector2 direction;
    //Quantidade de vida//
    public float vida;
    //som de morte do rbot//
    public AudioClip morteclip;
    //Pra saber se tem escudo//
    public bool escudo;
    //Pra saber se é o escudeiro//
    public bool escudeiro;
    //Quando tiver sem escudo (auxiliar na animação)//
    public bool semEscudo = false;
    //Resistencia do escudo//
    public float resEscudo;
    //Som de defesa 'escudo'//
    public AudioClip defesa;
    //Animator do Rbot
    public Animator anim;
    public RuntimeAnimatorController semEscudeiro;
    //Pegar o Is Trigger do Collider
    public Collider2D coll;
    public GameObject explosionRef;
    // variaveis para piscar o inimigo
    public GameObject anima; //gameobjecto do objeto filho que tem a animação do raio
    public SpriteRenderer goEnemy; //pega sprite render do inimigo
    public Animator vidaAnimator;
    //componente de som//
    private AudioSource som;
    void Start()
    {
        //Pega o componente de audio//
        som = GetComponent<AudioSource>();
        // Pega a posição do objeto com a tag 'Player'//
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //Pega o animator do rbot
        anim = GetComponent<Animator>();

        goEnemy = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // Pega a posição atualizada do objeto com a tag 'Player'//
        newTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerDistance = Vector2.Distance(transform.position, new Vector2(newTarget.position.x,newTarget.position.y));
        if(playerDistance<=distanciaPraDeteccao)
        {
            Movimentacao();   
            if(roboAtira==true)
            {
                Tiro();
            }
            else if(ehOcachorro == true)
            {   
                Mordida();
            }

            AnimVidas();
        }
        Direcao();
        Anim();
        if(escudeiro==true)
        {
            if(resEscudo <= 0)
            {
                semEscudo = true;  
            } 
            if(semEscudo == true)
            {
            coll.isTrigger = true;
            }
        }
    }

    void Movimentacao()
    {
        //Isso indica o eixo Y//
        targetY = new Vector2(transform.position.x, target.position.y);
        //Isso indica o eixo X//
        targetX = new Vector2(target.position.x, transform.position.y);
        //Atualiza a distancia entre inimigo e jogador nos eixos(x,y)//
        playerDistanceX = Vector2.Distance(transform.position, targetX);
        playerDistanceY = Vector2.Distance(transform.position, targetY);

        //Movimentação//
        if(playerDistanceY > playerDistanceX)//Caso a distancia entre os Xs esteja menor que a distancia entre os Zs, ele se move em X//
        {
            if(transform.position.y != target.position.y && playerDistanceY >= distanciaIdeal )
            {
                transform.position = Vector2.MoveTowards(transform.position, targetY, velocidade * Time.deltaTime);//Movimento do eixo Y//
            }
            else 
            {
                transform.position = Vector2.MoveTowards(transform.position, targetX, velocidade * Time.deltaTime);//Movimento do eixo X// 
            }
        }        
        else if(playerDistanceY < playerDistanceX)//Caso a distancia entre os Xs esteja maior que a distancia entre os Zs, ele se move em Z//
        {
            if(transform.position.x != target.position.x && playerDistanceX >= distanciaIdeal )
            {
                transform.position = Vector2.MoveTowards(transform.position, targetX, velocidade * Time.deltaTime);//Movimento do eixo X//
            }
            else 
            {
                transform.position = Vector2.MoveTowards(transform.position, targetY, velocidade * Time.deltaTime);//Movimento do eixo Y// 
            }
        }
        else//Caso esteja perfeitamente em sua diagonal, ele para, é utilizado para corrigir bugs//
        {

        }
        if(playerDistance <= distanciaIdeal && escudo == true)
        {
        }
    }
    void Tiro()
    {   
        if(tempoEntreTiros <=0)//Caso o cooldown chege a 0, ele atira//
        {
            if(tiroTeleguiado==true)//Seleciona se o tiro é teleguiado//
            {
                Instantiate(tiroQueSegue, transform.position, Quaternion.identity);
            }
            else//Seleciona se o tiro não é teleguiado//
            {
                Instantiate(tiroNormal, transform.position, Quaternion.identity);
            }
            tempoEntreTiros = tempoInicialEntreTiros;//Reseta o Cooldown//
        }
        else
        {
            tempoEntreTiros -= Time.deltaTime;//Diminui o tempo, fuincionando como um Cooldown//
        }
    }
    void Mordida()
    {
        if(mordeu == false && proxMordida <= 0)//Mordida fica verdadeira, e fica falsa após 2 segundos, essa função está bugada//
        {     
            if(playerDistance<=0.2)
            {
            mordeu = true;
            velocidade = 0;
            }
            proxMordida = tempoMordida;
        }
        else{
            proxMordida -= Time.deltaTime;
            if(proxMordida<=0)
            {
            mordeu = false;
            velocidade = 0.8f;
            }
        }
    }

    void Anim(){
        anim.SetBool("Cima", cima);
        anim.SetBool("Baixo", baixo);
        anim.SetBool("Direita", direita);
        anim.SetBool("Esquerda", esquerda);

        if(escudeiro){
            if(semEscudo){
                anim.runtimeAnimatorController = semEscudeiro;
            }
        }
    }

    public void AnimVidas(){
                //crie o objeto vida do inimigo com sprite vidas cheio (nao pode ser prefab) 
                //colocar ele como filo do inimigo, tem ue faze isso em cada um
                //depois de criar as animaçoes, há três parâmetros bool para mudar elas,
                //vida2: muda animação de 3 pra 2 corações...
                //crie transições entre todas as animações e confira se as condiçoes e parâmetros estão corretas :D
                if(vida + resEscudo >= 3){
                        vidaAnimator.SetBool("0vida", false);
                        vidaAnimator.SetBool("1vida", false);
                        vidaAnimator.SetBool("2vidas", false);
                } else if(vida + resEscudo == 2){
                        vidaAnimator.SetBool("2vidas", true);
                        vidaAnimator.SetBool("1vida", false);
                        vidaAnimator.SetBool("0vida", false);
                } else if(vida + resEscudo == 1){
                        vidaAnimator.SetBool("1vida", true);
                        vidaAnimator.SetBool("0vida", false);
                        vidaAnimator.SetBool("2vidas", false);
                } else if(vida == 0){
                        vidaAnimator.SetBool("0vida", true);
                        vidaAnimator.SetBool("1vida", false);
                        vidaAnimator.SetBool("2vidas", false);
                }
        }

    void Direcao()
    {
        heading = target.position - transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
        //print(direction);

        if(direction.x > 0 && direction.y > 0)
        {
            if(direction.x >= direction.y)
            {
                cima = false;
                baixo = false;
                esquerda = false;
                direita = true;
            }
            else if(direction.x < direction.y)
            {
                cima = true;
                baixo = false;
                esquerda = false;
                direita = false;
            }
        }
        else if(direction.x > 0 && direction.y <= 0)
        {
            if(direction.x >= direction.y*-1)
            {
                cima = false;
                baixo = false;
                esquerda = false;
                direita = true;
            }
            else if(direction.x < direction.y*-1) 
            {
                cima = false;
                baixo = true;
                esquerda = false;
                direita = false;
            }
        }
        else if(direction.x <= 0 && direction.y > 0)
        {
            if(direction.x*-1 >= direction.y)
            {
                cima = false;
                baixo = false;
                esquerda = true;
                direita = false;
            }
            else if (direction.x*-1 < direction.y)
            {
                cima = true;
                baixo = false;
                esquerda = false;
                direita = false;
            }
        }
        else if (direction.x <= 0 && direction.y <= 0)
        {
            if(direction.x*-1 >= direction.y*-1)
            {
                cima = false;
                baixo = false;
                esquerda = true;
                direita = false;
            }
            else if(direction.x*-1 < direction.y*-1)
            {
                cima = false;
                baixo = true;
                esquerda = false;
                direita = false;
            }
        }
    }

    private float knockback = 0.02f;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "tiroPlayer")//Lembrar de por a mesma tag que tiver no tiro do Player//
        {
            Vector2 direction = (this.transform.position - col.transform.position).normalized; //vai calcular a direção enemy - tiro
            this.transform.Translate(direction * knockback); //enemy vai ser pushado pra direção contrária do tiro
                                            
            StartCoroutine("Pisca", 1f);  //chama piscar cor           
            if(escudo==false)
            {
                vida--;
                if(vida<=0)
                {
                    explodir();
                    // som.clip=morteclip;
                    // som.Play();
                    Destroy(this.gameObject, 0.4f);                   
                }
            }
            else
            {
                resEscudo--;
                if(resEscudo <= 0)
                {
                    escudo=false;
                    semEscudo = true;
                }
            }  
        }
    }

    public IEnumerator glitch(){
        yield return new WaitForSeconds(0.5f);
    }

     public void Pisca(){
        goEnemy.color = Color.yellow; //muda cor
        anima.SetActive(true);
        Invoke("NormalizaCor", 0.3f); //tempo para voltar a cor normal
    }
    void NormalizaCor()
    {
        goEnemy.color = Color.white; //volta a cor normal
        anima.SetActive(false);
    }
    //instancia a Explosao
    public void explodir()
       {
       Instantiate(explosionRef, new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
       }
}
//Esse Script contém todo o Script de IA, menos a Vida, depois podemos separar//