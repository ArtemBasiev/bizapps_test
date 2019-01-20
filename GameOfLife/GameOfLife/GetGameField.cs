using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;
using System.Threading;


namespace GameOfLife
{
   public class GetGameField: Grid
    {

      
        private GridView MainGridView = new GridView();
       private AtomButton[,] mbarr;

       private int sizeoffield =45;

       public int SizeOfField
       {
           get
           {
               return sizeoffield;
           }

           set
           {
               if ((value>=10)&&(value<=50))
               {
                   sizeoffield = value;
               }
               else
               {
                   sizeoffield = 10;
               }
               
           }
       }

       public GetGameField()
        {
            
            this.ShowGridLines = true;
            this.Background = new SolidColorBrush(Color.FromArgb(a: 100, r: 255, g: 255, b: 255));
            mbarr = new AtomButton[sizeoffield, sizeoffield];

            for (int id = 0; id < sizeoffield; id++)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition());
                this.RowDefinitions.Add(new RowDefinition());
                
            }
            for (int i = 0; i < sizeoffield; i++)
                {
                    for (int j = 0; j < sizeoffield; j++)
                    {
                        mbarr[i, j] = new AtomButton();
                        Grid.SetRow(mbarr[i, j], i);
                        Grid.SetColumn(mbarr[i, j], j);
                        this.Children.Add(mbarr[i, j]);
                    }

                }

        }

       public void ClearField()
       {

           for (int i = 0; i < sizeoffield; i++)
           {
               for (int j = 0; j < sizeoffield; j++)
               {
                   mbarr[i, j].IsAlive = 0;
                   mbarr[i, j].Background = Brushes.Black;
               }

           }

       }

       public void NextGeneration()
       {

           for (int i = 0; i < sizeoffield; i++)
           {
               for (int j = 0; j < sizeoffield; j++)
               {
                   int neibercount = 0;
                
                       try 
                       {
                           if (mbarr[i - 1, j - 1].IsAlive == 1)
                           {
                               neibercount++;
                           }
                       }
                       catch 
                       {
                         
                       }

                       try
                       {
                           if (mbarr[i, j - 1].IsAlive == 1)
                           {
                               neibercount++;
                           }
                       }
                       catch
                       {

                       }
                       try
                       {
                           if (mbarr[i + 1, j - 1].IsAlive == 1)
                           {
                               neibercount++;
                           }
                       }
                       catch
                       {

                       }

                       try
                       {
                           if (mbarr[i + 1, j].IsAlive == 1)
                           {
                               neibercount++;
                           }
                       }
                       catch
                       {

                       }

                       try
                       {
                           if (mbarr[i + 1, j + 1].IsAlive == 1)
                           {
                               neibercount++;
                           }
                       }
                       catch
                       {

                       }

                       try
                       {
                           if (mbarr[i, j + 1].IsAlive == 1)
                           {
                               neibercount++;
                           }
                       }
                       catch
                       {

                       }

                       try
                       {

                           if (mbarr[i - 1, j + 1].IsAlive == 1)
                           {
                               neibercount++;
                           }
                       }
                       catch
                       {

                       }

                       try
                       {
                           if (mbarr[i - 1, j].IsAlive == 1)
                           {
                               neibercount++;
                           }
                       }
                       catch
                       {

                       }


                       if (mbarr[i, j].IsAlive == 1)
                       {
                           if ((neibercount<2)||(neibercount>3) )
                           {
                               mbarr[i, j].IsAlive = 0;
                               Action action = () =>
                                   {
                                       mbarr[i, j].Background = Brushes.Black;
                                     
                                   };
                           
                                   this.Dispatcher.Invoke(action);
                          
                               
                           }
                         
                       }
                      else
                       {
                           if((mbarr[i,j].IsAlive==0)&&(neibercount==3))
                           {
                               mbarr[i, j].IsAlive = 1;
                               Action action = () =>
                               {
                                 
                                   mbarr[i, j].Background = Brushes.Green;

                               };
                       
                                   this.Dispatcher.Invoke(action);
        
                           }
                       }
                    
                       

               }

           }
       }

    }
}
