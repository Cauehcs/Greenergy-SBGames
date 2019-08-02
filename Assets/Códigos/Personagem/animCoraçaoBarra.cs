using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animCoraçaoBarra : MonoBehaviour
{
    public Animator coracaoSuperior, coracaoMediano, coracaoInferior;
    public bool levouDano, dano, cura;

    void Start(){
        levouDano = false;
        dano = false;
    }

    void Update(){
        perderVidaAnim();
        cura = novoSistemaVida.recuperarVida;
    }

    void perderVidaAnim(){
        if(dano){
            coracaoInferior.SetBool("Dano", false);
            coracaoMediano.SetBool("Dano", false);
            coracaoSuperior.SetBool("Dano", false);
            dano = false;
        }

        if(cura){
            coracaoInferior.SetBool("Cura", false);
            coracaoMediano.SetBool("Cura", false);
            coracaoSuperior.SetBool("Cura", false);
            novoSistemaVida.recuperarVida = false;
        }

        if(novoSistemaVida.recuperarVida){
            coracaoInferior.SetBool("Cura", true);
            coracaoMediano.SetBool("Cura", true);
            coracaoSuperior.SetBool("Cura", true);
            novoSistemaVida.recuperarVida = false;
        }

        if(novoSistemaVida.levarDano && novoSistemaVida.vidaAtual == 2){
            coracaoInferior.SetBool("Dano", true);
            novoSistemaVida.levarDano = false;
        }
              if(novoSistemaVida.levarDano && novoSistemaVida.vidaAtual == 1){
                coracaoMediano.SetBool("Dano", true);
                novoSistemaVida.levarDano = false;
            }
                 if(novoSistemaVida.levarDano && novoSistemaVida.vidaAtual == 0){
                    coracaoSuperior.SetBool("Dano", true);
                    novoSistemaVida.levarDano = false;
                }
   
    }
}

