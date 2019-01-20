using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfLife
{
    class AtomButton: Button
    {
        private int isalive = 0;
        

        public int IsAlive
        {
            get
            {
                return isalive;
            }
            set
            {
                if((value>=0)&&(value<=1))
                {
                    isalive = value;
                }
            }
        }


       
        public AtomButton()
        {


            this.MouseEnter += AtomButton_MouseEnter;
            this.Click += AtomButton_Click;
            this.Background = Brushes.Black;
         
        }


        public AtomButton(SolidColorBrush newbr)
        {
            this.Click += AtomButton_Click;
            this.Background = newbr;
        }

        public AtomButton(SolidColorBrush newbr, int newallive)
        {
            this.Click += AtomButton_Click;
            this.Background = newbr;
            this.IsAlive = newallive;
        }
        public AtomButton( int newallive)
        {
            this.Click += AtomButton_Click;
            this.IsAlive = newallive;
            this.Background = Brushes.Black;
        }

        void AtomButton_Click(object sender, RoutedEventArgs e)
        {
             if (this.IsAlive==0)
             { 
                 this.IsAlive = 1;
                 this.Background = Brushes.Green;
             
             }
             else
             {
                 if (this.IsAlive == 1)
                 {
                     this.IsAlive = 0;
                     this.Background = Brushes.Black;
                    
                 }
             }
            
        }




        void AtomButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                if (this.IsAlive == 0)
                {
                    this.IsAlive = 1;
                    this.Background = Brushes.Green;

                }
                else
                {
                    if (this.IsAlive == 1)
                    {
                        this.IsAlive = 0;
                        this.Background = Brushes.Black;

                    }
                }

            }
        }
 


    }
}
