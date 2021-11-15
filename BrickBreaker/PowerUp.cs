using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class PowerUp
    {
        /* sort the diffrent types of powerups
         * (Breaking cetain blocks) or (Random blocks give random powerups)
         * powerups fall and either collide with the player or fall out of the screen (Move behavoir)
         * if the player coides with the power ups give the player the power up (colide behavoir with player and bottom of screen)
         * use space to activate the power up (use behavoir)
         */


        /// Types of power ups and sorting powerups
        /// "mushroom", "cherry", "fireFlower"
        //Star(one shot everything for short amount of time)    
        //1-up mushroom(1 life increase)                        
        //Pac man cherry(score increase)                        
        //Tanooki suit(mario tail) (slows the ball speed)       
        //Mushroom(increases paddle size)                       
        //
        //Fire flower(destroy blocks in straight line)          
        //Zelda  bow and arrow(Shoot projectiles)               
        //Koopa shell(shells that act like ball but won't count towards lives)   
        //Metroid bomb (explodes in an area if doesn't hit any bricks falls back down)  
        //Megaman buzzsaw 
        //Dk barrel (??) 

        /// States: Fall, wait, active.
        string type;
        int Speed = 10;
        string state = "wait";
        int x, y;
        int size = 10;
        


        public void Move()
        {
            y += Speed;
        }

        public void Active()
        {

        }

    }
}
