using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Clients
{
    public partial class Form1 : Form
    {
        List<PictureBox> items = new List<PictureBox>();
        private Random rand = new Random();
        private int X, Y;
        private Color[] newColor = { Color.Red, Color.Turquoise, Color.Gold, Color.LimeGreen };
        private double spawnTime = 20;

        private System.Timers.Timer pathfindingTimer;
        private int targetX = 782;
        private int targetY = 591;
        private int[] target = { 782, 591, 870, 601 };
        private int[] table2 = { 782, 591, 870, 511 };
        private int[] table3 = { 782, 591, 876, 461 };
        private int[] table4 = { 782, 591, 844, 394 };
        private int[] table5 = { 782, 591, 600, 541 };
        private int[] table6 = { 782, 591, 426, 541 };
        private int[] table7 = { 782, 591, 312, 540 };
        private int[] table8 = { 782, 591, 194, 540 };
        private int[] table9 = { 782, 591, 559, 541 };
        private int[] table10 = { 782, 591, 408, 541 };
        private int[] table11 = { 782, 591, 254, 541 };
        private int[] table12 = { 180, 541, 228, 353 };
        private int[] table13 = { 560, 541, 559, 394 };
        private int stepSize = 5;
        
        Point[] targetPositions_1 = new Point[] { new Point(923, 639), new Point(923, 580), new Point(954, 580), new Point(953, 636) };
        Point[] targetPositions_2 = new Point[] { new Point(923, 545), new Point(954, 545), new Point(954, 487), new Point(923, 487) };
        Point[] targetPositions_3 = new Point[] { new Point(936, 438), new Point(936, 418), new Point(877, 431)};
        Point[] targetPositions_4 = new Point[] { new Point(937, 384), new Point(937, 365), new Point(877, 377) };
        Point[] targetPositions_5 = new Point[] { new Point(687, 481), new Point(634, 482), new Point(633, 515), new Point(687, 514) };
        Point[] targetPositions_6 = new Point[] { new Point(522, 481), new Point(465, 481), new Point(466, 513), new Point(522, 514) };
        Point[] targetPositions_7 = new Point[] { new Point(404, 480), new Point(349, 482), new Point(350, 514), new Point(404, 513) };
        Point[] targetPositions_8 = new Point[] { new Point(285, 480), new Point(231, 480), new Point(231, 513), new Point(275, 514) };
        
        Point[] targetPositions_9 = new Point[] { new Point(626, 649), new Point(594, 626), new Point(594, 597), new Point(660, 647), new Point(696, 621), new Point(697, 597) };
        Point[] targetPositions_10 = new Point[] { new Point(285, 480), new Point(231, 480), new Point(231, 513), new Point(275, 514), new Point(231, 513), new Point(275, 514) };
        Point[] targetPositions_11 = new Point[] { new Point(285, 480), new Point(231, 480), new Point(231, 513), new Point(275, 514), new Point(231, 513), new Point(275, 514) };
        Point[] targetPositions_12 = new Point[] { new Point(285, 480), new Point(231, 480), new Point(231, 513), new Point(275, 514),new Point(285, 480), new Point(231, 480), new Point(231, 513), new Point(275, 514),new Point(285, 480), new Point(231, 480), new Point(231, 513), new Point(275, 514), new Point(231, 513), new Point(275, 514) };
        Point[] targetPositions_13 = new Point[] { new Point(285, 480), new Point(231, 480), new Point(231, 513), new Point(275, 514), new Point(231, 513), new Point(275, 514) };
        //
        private int pictureBoxCount = 1;
        private int currentPictureBoxIndex = 0;
        private List<PictureBox> players = new List<PictureBox>();
        private int currentPlayerIndex = 2;

        private bool goup, godown, goleft, goright;
        private int playerSpeed;

        public Form1()
        {

            InitializeComponent();
            resetGame();
        }

        private void StartPathfinding()
        {
            // Initialiser le timer
            pathfindingTimer = new System.Timers.Timer();
            pathfindingTimer.Interval = 100; // Intervalle de mise à jour du déplacement (en millisecondes)
            pathfindingTimer.Elapsed += PathfindingTable_11;
            pathfindingTimer.Start();
        }
        
        private void StartPathfinding_2()
        {
            // Initialiser le timer
            pathfindingTimer = new System.Timers.Timer();
            pathfindingTimer.Interval = 100; // Intervalle de mise à jour du déplacement (en millisecondes)
            pathfindingTimer.Elapsed += PathfindingTable_13;
            pathfindingTimer.Start();
        }

        private void PathfindingTable_2(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table2[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left < table2[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left + playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top > table2[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_1(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Left < target[0] / 1.35)
            {

                Chefrang_2.Left = Chefrang_2.Left + playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Top < target[1] / 1.23)
            {
                Chefrang_2.Top = Chefrang_2.Top + playerSpeed;

            }
            // Arrêter le personnage pendant 3 secondes

            // Remonter le personnage jusqu'au point 601 sur l'axe Y

            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Left < target[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left + playerSpeed;
            }
            else if (Chefrang_2.Top < target[3] / 1.23 && Chefrang_2.Top > target[1] / 1.23)
            {
                Chefrang_2.Top = Chefrang_2.Top - 8;
                pathfindingTimer.Stop();
            }
            // Arrêter le pathfinding
            else
            {
                pathfindingTimer.Stop();
            }
        }

        private void PathfindingTable_3(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table3[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left < table3[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left + playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top > table3[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_4(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table4[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left < table4[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left + playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top > table4[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_5(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table5[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left > table5[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left - playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top < table5[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_6(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table6[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left > table6[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left - playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top > table6[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_7(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table7[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left > table7[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left - playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top > table7[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_8(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table8[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left > table8[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left - playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top > table8[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_9(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table9[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left > table9[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left - playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top > table9[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_10(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table10[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left > table10[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left - playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top > table10[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_11(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            //Console.WriteLine("Position of man"+Chefrang_2.Top);
            if (Chefrang_2.Top > table11[3] / 1.23)
            {
                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Descendre le personnage jusqu'au point targetY
            else if (Chefrang_2.Left > table11[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left - playerSpeed;
            }



            // Déplacer le personnage vers la droite jusqu'au point 870 sur l'axe X
            else if (Chefrang_2.Top > table11[3] / 1.23)
            {

                Console.WriteLine(Chefrang_2.Top);
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                pathfindingTimer.Stop();
            }

            // Arrêter le pathfinding

        }

        private void PathfindingTable_12(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers le haut jusqu'au point targetY
            if (Chefrang_2.Top > table12[1] / 1.23)
            {
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            else if (Chefrang_2.Left > table12[0] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left - playerSpeed;
            }
            // Déplacer le personnage vers le bas jusqu'au point 353 sur l'axe Y
            else if (Chefrang_2.Top > table12[3] / 1.23)
            {
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Déplacer le personnage vers la droite jusqu'au point targetX
            else if (Chefrang_2.Left < table12[2] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left + playerSpeed + 30;
                pathfindingTimer.Stop();
            }
        }

        private void PathfindingTable_13(object sender, ElapsedEventArgs e)
        {
            // Déplacer le personnage vers le haut jusqu'au point targetY
            if (Chefrang_2.Top > table13[1] / 1.23)
            {
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
            }
            // Déplacer le personnage vers la gauche jusqu'au point targetX
            else if (Chefrang_2.Left > table13[0] / 1.35)
            {
                Chefrang_2.Left = Chefrang_2.Left - playerSpeed;
            }
            // Déplacer le personnage vers le bas jusqu'au point 353 sur l'axe Y
            else if (Chefrang_2.Top > table13[3] / 1.23)
            {
                Chefrang_2.Top = Chefrang_2.Top - playerSpeed;
                //pathfindingTimer.Stop();
            }
            // Déplacer le personnage vers la droite jusqu'au point targetX

        }

        private void MakePictureBox()
        {
            int pictureBoxCount = 0;
            for (int i = 0; i < 3; i++)
            {
                PictureBox new_pic = new PictureBox();
                new_pic.Width = 17;
                new_pic.Height = 17;
                new_pic.Image = GetRandomImage();
                new_pic.SizeMode = PictureBoxSizeMode.StretchImage;
                new_pic.Location = new Point(610, 505);

                // Vérifier si l'indice est valide dans le tableau des positions cibles
                if (i < targetPositions_1.Length)
                {
                    Point targetPosition = targetPositions_4[i];
                    int targetX = targetPosition.X;
                    int targetY = targetPosition.Y;

                    // Le reste du code pour créer et configurer le PictureBox

                    // Créer un timer pour le mouvement
                    System.Windows.Forms.Timer pathfindingTimer = new System.Windows.Forms.Timer();
                    pathfindingTimer.Interval = 100; // Intervalle de mise à jour du déplacement (en millisecondes)
                    pathfindingTimer.Tick += (sender, e) => PathfindingPlayer(new_pic, targetX, targetY, pathfindingTimer);
                    pathfindingTimer.Start();

                    players.Add(new_pic);
                    pictureBoxCount++;
                }

                items.Add(new_pic);
                this.Controls.Add(new_pic);
                new_pic.BringToFront();
            }
            Console.WriteLine(pictureBoxCount);
            MovePlayerToNextTarget();
        }
        private void MovePlayerToNextTarget()
        {
            if (currentPlayerIndex >= players.Count)
            {
                // Tous les joueurs ont atteint leur cible, sortir de la méthode
                return;
            }

            PictureBox currentPlayer = players[currentPlayerIndex];
            //int targetX = 910;
            //int targetY = 400;

            System.Windows.Forms.Timer pathfindingTimer = new System.Windows.Forms.Timer();
            pathfindingTimer.Interval = 100;
            pathfindingTimer.Tick += (sender, e) => PathfindingPlayer(currentPlayer, targetX, targetY, pathfindingTimer);
            pathfindingTimer.Start();

            currentPlayerIndex++;
           // Console.WriteLine(currentPlayerIndex);
        }
        
        private void PathfindingPlayer(PictureBox pictureBox, int targetX, int targetY, System.Windows.Forms.Timer pathfindingTimer)
        {
            int step = 5;
            //Console.WriteLine(targetY);
            if (pictureBox.Top > targetY / 1.23)
            {
                pictureBox.Top =pictureBox.Top- step;
            }
            else if (pictureBox.Left < targetX / 1.35)
            {
                pictureBox.Left = pictureBox.Left+step;
            }
            else if (pictureBox.Top > targetY / 1.23)
            {
                pictureBox.Top = pictureBox.Top-step;
                // pathfindingTimer.Stop();
                // moveNextAction.Invoke();
                if (pictureBox.Top < targetY / 1.23)
                {
                    pictureBox.Top = pictureBox.Top+step;
                    pathfindingTimer.Stop();
                }
            }
                
            /*else
            {
                pictureBox.Top = pictureBox.Top + step;
                pathfindingTimer.Stop();
            }*/
            //this.pathfindingTimer.Stop();
                
        }
        
        // POUR LES CLIENTS DE GAUCHES
        
        private void MakePictureBox_gauche()
        {
            int pictureBoxCount = 0;
            for (int i = 0; i < 4; i++)
            {
                PictureBox new_pic = new PictureBox();
                new_pic.Width = 17;
                new_pic.Height = 17;
                new_pic.Image = GetRandomImage();
                new_pic.SizeMode = PictureBoxSizeMode.StretchImage;
                new_pic.Location = new Point(610, 505);

                // Vérifier si l'indice est valide dans le tableau des positions cibles
                if (i < targetPositions_1.Length)
                {
                    Point targetPosition = targetPositions_6[i];
                    int targetX = targetPosition.X;
                    int targetY = targetPosition.Y;

                    // Le reste du code pour créer et configurer le PictureBox

                    // Créer un timer pour le mouvement
                    System.Windows.Forms.Timer pathfindingTimer = new System.Windows.Forms.Timer();
                    pathfindingTimer.Interval = 100; // Intervalle de mise à jour du déplacement (en millisecondes)
                    pathfindingTimer.Tick += (sender, e) => PathfindingPlayer_gauche(new_pic, targetX, targetY, pathfindingTimer);
                    pathfindingTimer.Start();

                    players.Add(new_pic);
                    pictureBoxCount++;
                }

                items.Add(new_pic);
                this.Controls.Add(new_pic);
                new_pic.BringToFront();
            }
            MovePlayerToNextTarget_gauche();
            Console.WriteLine(pictureBoxCount);
        }
        // pour les clients des table de gauche
        private void MovePlayerToNextTarget_gauche()
        {
            if (currentPlayerIndex >= players.Count)
            {
                // Tous les joueurs ont atteint leur cible, sortir de la méthode
                return;
            }

            PictureBox currentPlayer = players[currentPlayerIndex];
            //int targetX = 910;
            //int targetY = 400;

            System.Windows.Forms.Timer pathfindingTimer = new System.Windows.Forms.Timer();
            pathfindingTimer.Interval = 100;
            pathfindingTimer.Tick += (sender, e) => PathfindingPlayer_gauche(currentPlayer, targetX, targetY, pathfindingTimer);
            pathfindingTimer.Start();

            currentPlayerIndex++;
            //Console.WriteLine(currentPlayerIndex);
        }
            
            // Pour les clients de gauche
            private void PathfindingPlayer_gauche(PictureBox pictureBox, int targetX, int targetY, System.Windows.Forms.Timer pathfindingTimer)
            {
                int step = 5;
               // Console.WriteLine(targetY);
                if (pictureBox.Top > targetY / 1.23)
                {
                    pictureBox.Top =pictureBox.Top- step;
                }
                else if (pictureBox.Left > targetX / 1.35)
                {
                    pictureBox.Left = pictureBox.Left-step;
                    //pathfindingTimer.Stop();
                }
               
                
                else if (pictureBox.Top > targetY / 1.23)
                {
                    pictureBox.Top = pictureBox.Top-step;
                    // pathfindingTimer.Stop();
                    // moveNextAction.Invoke();
                    if (pictureBox.Top < targetY / 1.23)
                    {
                        pictureBox.Top = pictureBox.Top+step;
                        pathfindingTimer.Stop();
                    }
                }
                
                /*else
                {
                    pictureBox.Top = pictureBox.Top + step;
                    pathfindingTimer.Stop();
                }*/
                //this.pathfindingTimer.Stop();
                
            }
            
            //POUR CLIENTS GQUCHE BAS
            
            private void MakePictureBox_gauche_bas()
            {
                int pictureBoxCount = 0;
            for (int i = 0; i < rand.Next(1,6); i++)
            {
                PictureBox new_pic = new PictureBox();
                new_pic.Width = 17;
                new_pic.Height = 17;
                new_pic.Image = GetRandomImage();
                new_pic.SizeMode = PictureBoxSizeMode.StretchImage;
                new_pic.Location = new Point(610, 505);

                // Vérifier si l'indice est valide dans le tableau des positions cibles
                if (i < targetPositions_9.Length)
                {
                    Point targetPosition = targetPositions_9[i];
                    int targetX = targetPosition.X;
                    int targetY = targetPosition.Y;

                    // Le reste du code pour créer et configurer le PictureBox

                    // Créer un timer pour le mouvement
                    System.Windows.Forms.Timer pathfindingTimer = new System.Windows.Forms.Timer();
                    pathfindingTimer.Interval = 100; // Intervalle de mise à jour du déplacement (en millisecondes)
                    pathfindingTimer.Tick += (sender, e) => PathfindingPlayer_gauche(new_pic, targetX, targetY, pathfindingTimer);
                    pathfindingTimer.Start();

                    players.Add(new_pic);
                    pictureBoxCount++;
                    
                }

                items.Add(new_pic);
                this.Controls.Add(new_pic);
                new_pic.BringToFront();
                Console.WriteLine(i);
            }
            MovePlayerToNextTarget_gauche_bas();
           // Console.WriteLine(pictureBoxCount);
            
        }
        // pour les clients des table de gauche
        private void MovePlayerToNextTarget_gauche_bas()
        {
            if (currentPlayerIndex >= players.Count)
            {
                // Tous les joueurs ont atteint leur cible, sortir de la méthode
                return;
            }

            PictureBox currentPlayer = players[currentPlayerIndex];
            //int targetX = 910;
            //int targetY = 400;

            System.Windows.Forms.Timer pathfindingTimer = new System.Windows.Forms.Timer();
            pathfindingTimer.Interval = 100;
            pathfindingTimer.Tick += (sender, e) => PathfindingPlayer_gauche_down(currentPlayer, targetX, targetY, pathfindingTimer);
            pathfindingTimer.Start();

            currentPlayerIndex++;
           // Console.WriteLine(currentPlayerIndex);
        }
            
            private void PathfindingPlayer_gauche_down(PictureBox pictureBox, int targetX, int targetY, System.Windows.Forms.Timer pathfindingTimer)
            {
                int step = 5;
                //Console.WriteLine(targetY);
                if (pictureBox.Top > targetY / 1.23)
                {
                    pictureBox.Top =pictureBox.Top- step;
                }
                else if (pictureBox.Left > targetX / 1.35)
                {
                    pictureBox.Left = pictureBox.Left-step;
                    //pathfindingTimer.Stop();
                }
                else if (pictureBox.Top < targetY / 1.23)
                {
                    pictureBox.Top = pictureBox.Top+step;
                    // pathfindingTimer.Stop();
                    // moveNextAction.Invoke();
                   
                }
                 if (pictureBox.Top > targetY / 1.23)
                    {
                        pictureBox.Top = pictureBox.Top-step;
                        pathfindingTimer.Stop();
                    }
                
                /*else
                {
                    pictureBox.Top = pictureBox.Top + step;
                    pathfindingTimer.Stop();
                }*/
                //this.pathfindingTimer.Stop();
                
            }
    



        private Image GetRandomImage()
        {
            Image[] images = { Properties.Resources.droit, Properties.Resources.droit, Properties.Resources.droit }; // Ajoutez ici toutes les images possibles
            return images[rand.Next(0, images.Length)];
        }
        private void Keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            
            //
            
        }

        private void Keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            
        }

        private void mainGameTimer(object sender, ElapsedEventArgs e)
        {
            if (goleft == true)
            {
                man2.Left -= playerSpeed;
                man2.Image = Properties.Resources.droit;
            }
            if (goright == true)
            {
                man2.Left += playerSpeed;
               man2.Image = Properties.Resources.droit;
            }
            if (goup == true)
            {
                man2.Top -= playerSpeed;
               man2.Image = Properties.Resources.droit;
            }
            if (godown == true)
            {
                man2.Top += playerSpeed;
               man2.Image = Properties.Resources.droit;
            }
            //MakePicrureBox();
            
           /* if (man2.Left <= 100 )
            {
                Console.WriteLine("Position of man"+man.Left);
                man2.Left = man2.Left + playerSpeed-4;
                
            }

            else if (man2.Top<451)
            {
                man2.Top = man2.Top + playerSpeed - 4;
            }*/
            //
            /*spawnTime -= 1;
            if (spawnTime<1)
            {
               MakePicrureBox();
                //spawnTime = 50;
              //  Thread.Sleep(1000);
                foreach (PictureBox item in items.ToList())
                {
                    if (man2.Bounds.IntersectsWith(item.Bounds))
                    {
                        items.Remove(item);
                        this.Controls.Remove(item);
                    }
                    
                }
            }*/
        }

        /*private void MakePictureBox()
        {
            //for (int i = 0; i < rand.Next(1,3); i++)
            for (int i = 0; i < 4; i++)
            {   
                Console.WriteLine(i);
                PictureBox new_pic = new PictureBox();
                new_pic.Width = 17;
                new_pic.Height = 17;
                new_pic.Image = GetRandomImage(); // Utilisez une méthode pour obtenir une image aléatoire
                new_pic.SizeMode = PictureBoxSizeMode.StretchImage;
                // X = rand.Next(10, this.ClientSize.Width - new_pic.Width);
                // Y = rand.Next(10, this.ClientSize.Height - new_pic.Height);
                X = 610 ;
                Y = 505;
                new_pic.Location = new Point(X, Y);
                items.Add(new_pic);
                this.Controls.Add(new_pic);
                new_pic.BringToFront();
                //Console.WriteLine(items.Count());
            }
        }*/

        private void resetGame()
        {
            //Score.Text = "score: 0";
           // man2.Left = 59;
            //man2.Top = 142;
            playerSpeed = 8;
            StartPathfinding();
            MakePictureBox();
            MakePictureBox_gauche();
            MakePictureBox_gauche_bas();
           // this.BackgroundImage = Properties.Resources.plan;
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            gameTimer.Start();
            
        }


        
    }
}
