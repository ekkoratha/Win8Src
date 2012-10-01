using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace QuadClock
{
    public sealed partial class SundialClockControl : UserControl
    {
        public SundialClockControl()
        {
            this.InitializeComponent();
            DisplayTime();
        }

        public void DisplayTime()
        {

            //txtTo.Text = DateTime.Now.ToString("mm/dd/yyyy HH:mm:ss");
            string HH_str = DateTime.Now.ToString("HH");

            int hour = Convert.ToInt32(HH_str); ;

            shadow1.Stroke = new SolidColorBrush(Colors.Black);
            shadow2.Stroke = new SolidColorBrush(Colors.Black);
            shadow1.StrokeThickness = 3;
            shadow2.StrokeThickness = 3;


            LineGeometry s1Geometry = new LineGeometry();
            LineGeometry s2Geometry = new LineGeometry();

            s1Geometry.StartPoint = new Point(235, 208);
            s1Geometry.EndPoint = new Point(231, 300);
            shadow1.Data = s1Geometry;
            shadow1.HorizontalAlignment = HorizontalAlignment.Left;
            shadow1.VerticalAlignment = VerticalAlignment.Center;
            if (hour > 3 && hour < 21)
            {
                shadow1.Visibility = Visibility.Visible;
                shadow2.Visibility = Visibility.Visible;
            }

            switch (hour)
            {

                case 4:
                    //shadow 1
                    shadow1.Margin = new Thickness { Left = 228.655, Top = 220, Right = 193.5, Bottom = 336 };

                    //shadow 2
                    s2Geometry.StartPoint = new Point(238, 324.00107);

                    s2Geometry.EndPoint = new Point(235, 387.00137);

                    shadow2.Data = s2Geometry;

                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;

                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;

                    shadow2.Height = 92.5;

                    shadow2.Width = 45.345;

                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 193.5, Bottom = 311.5 };

                    break;


                case 5:

                    //shadow 1

                    shadow1.Margin = new Thickness { Left = 228.655, Top = 238.25, Right = 162, Bottom = 336 };


                    //shadow 2

                    s2Geometry.StartPoint = new Point(238, 324.00107);

                    s2Geometry.EndPoint = new Point(235, 387.00137);

                    shadow2.Data = s2Geometry;

                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;

                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;

                    shadow2.Height = 82.25;

                    shadow2.Width = 80.832;

                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 162, Bottom = 303.5 };

                    break;


                case 6:

                    //shadow 1

                    shadow1.Margin = new Thickness { Left = 228.655, Top = 260, Right = 143, Bottom = 336 };


                    //shadow 2

                    s2Geometry.StartPoint = new Point(238, 324.00107);

                    s2Geometry.EndPoint = new Point(235, 387.00137);

                    shadow2.Data = s2Geometry;

                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;

                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;

                    shadow2.Height = 60.5;

                    shadow2.Width = 99.082;

                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 143.75, Bottom = 303.5 };

                    break;


                case 7:

                    //shadow 1

                    shadow1.Margin = new Thickness { Left = 228.655, Top = 286.5, Right = 138, Bottom = 336 };

                    //shadow 2

                    s2Geometry.StartPoint = new Point(238, 324.00107);

                    s2Geometry.EndPoint = new Point(235, 387.00137);

                    shadow2.Data = s2Geometry;

                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;

                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;

                    shadow2.Height = 34;

                    shadow2.Width = 104.832;

                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 138, Bottom = 303.5 };

                    break;

                case 8:

                    //shadow 1

                    shadow1.Margin = new Thickness { Left = 228.655, Top = 286.5, Right = 145.25, Bottom = 311.5 };



                    s1Geometry.StartPoint = new Point(235, 208);

                    s1Geometry.EndPoint = new Point(261, 300);

                    shadow1.Data = s1Geometry;


                    //shadow 2

                    s2Geometry.StartPoint = new Point(238, 324.00107);

                    s2Geometry.EndPoint = new Point(235, 387.00137);

                    shadow2.Data = s2Geometry;

                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;

                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;

                    shadow2.Height = 7.4;

                    shadow2.Width = 97.932;

                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 146.4, Bottom = 305 };

                    break;

                case 9:

                    //shadow 1

                    shadow1.Margin = new Thickness { Left = 228.655, Top = 286.5, Right = 161, Bottom = 297 };

                    s1Geometry.StartPoint = new Point(235, 208);

                    s1Geometry.EndPoint = new Point(261, 300);

                    shadow1.Data = s1Geometry;

                    //228.655,286.5,161,297"


                    //shadow 2

                    s2Geometry.StartPoint = new Point(238, 324.00107);

                    s2Geometry.EndPoint = new Point(240, 387.00137);

                    shadow2.Data = s2Geometry;

                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;

                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;

                    shadow2.Height = 16.65;

                    shadow2.Width = 83.332;

                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 161, Bottom = 293.75 };

                    break;

                case 10:

                    //shadow 1

                    shadow1.Margin = new Thickness { Left = 228.655, Top = 286.5, Right = 179, Bottom = 280 };

                    s1Geometry.StartPoint = new Point(235, 208);

                    s1Geometry.EndPoint = new Point(261, 300);

                    shadow1.Data = s1Geometry;

                    //shadow 2  shadow2" Data="M238,324.00107 L240,387.00137"  Margin="0,0,179,280"  Width="65.332"  Height="30.4" >10

                    s2Geometry.StartPoint = new Point(238, 324.00107);

                    s2Geometry.EndPoint = new Point(240, 387.00137);

                    shadow2.Data = s2Geometry;

                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;

                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;

                    shadow2.Height = 30.4;

                    shadow2.Width = 65.332;

                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 179, Bottom = 280 };

                    break;

                case 11:

                    //shadow 1 shadow1" Data="M235,208 L251,300"  Margin="228.655,286.5,203.333,268.999"   />11

                    shadow1.Margin = new Thickness { Left = 228.655, Top = 286.5, Right = 203.333, Bottom = 268.999 };

                    s1Geometry.StartPoint = new Point(235, 208);

                    s1Geometry.EndPoint = new Point(261, 300);

                    shadow1.Data = s1Geometry;

                    //shadow 2  shadow2" Data="M238,324.00107 L240,387.00137"  Margin="0,0,203.333,268.999"  Width="40.999"  Height="41.401"  />  11  

                    s2Geometry.StartPoint = new Point(238, 324.00107);

                    s2Geometry.EndPoint = new Point(240, 387.00137);

                    shadow2.Data = s2Geometry;

                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;

                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;

                    shadow2.Height = 41.401;

                    shadow2.Width = 40.999;

                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 203.333, Bottom = 268.999 };

                    break;

                case 12:
                    //shadow 1 shadow1" Data="M235,208 L251,300"  Margin="228.655,286.5,226.833,264"   /> 12
                    shadow1.Margin = new Thickness { Left = 228.655, Top = 286.5, Right = 226.833, Bottom = 264 };
                    s1Geometry.StartPoint = new Point(235, 208);
                    s1Geometry.EndPoint = new Point(261, 300);
                    shadow1.Data = s1Geometry;

                    //shadow 2  shadow2" Data="M238,324.00107 L240,387.00137"  Margin="0,0,226.833,264"  Width="17.499"  Height="46.4"  /> 12
                    s2Geometry.StartPoint = new Point(238, 324.00107);
                    s2Geometry.EndPoint = new Point(240, 387.00137);
                    shadow2.Data = s2Geometry;
                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow2.Height = 46.4;
                    shadow2.Width = 17.499;
                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 226.833, Bottom = 264 };
                    break;

                case 13:
                    //shadow 1 M235,208 L261,300" Data="M235,208 L251,300"  Margin="228.655,286.5,250.345,264"   />1
                    shadow1.Margin = new Thickness { Left = 228.655, Top = 286.5, Right = 250.345, Bottom = 260 };
                    s1Geometry.StartPoint = new Point(235, 208);
                    s1Geometry.EndPoint = new Point(251, 300);
                    shadow1.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow1.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow1.Data = s1Geometry;

                    s2Geometry.StartPoint = new Point(238, 324.00107);
                    s2Geometry.EndPoint = new Point(230, 387.00137);
                    shadow2.Data = s2Geometry;
                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow2.Height = 49.6;
                    shadow2.Width = 9.2;
                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 241, Bottom = 260 };
                    break;

                case 14:
                    //shadow 1shadow1" Data="M235,208 L231,300"  Margin="207.667,284.25,253.333,260"  
                    shadow1.Margin = new Thickness { Left = 207.667, Top = 284.25, Right = 253.333, Bottom = 260 };
                    s1Geometry.StartPoint = new Point(235, 208);
                    s1Geometry.EndPoint = new Point(231, 300);
                    shadow1.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow1.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow1.Data = s1Geometry;
                    // shadow2" Data="M238,324.00107 L230,387.00137"  Margin="0,0,241.333,260"  Width="31"  Height="47.333"  /> 2
                    s2Geometry.StartPoint = new Point(238, 324.00107);
                    s2Geometry.EndPoint = new Point(230, 387.00137);
                    shadow2.Data = s2Geometry;
                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow2.Height = 47.333;
                    shadow2.Width = 31;
                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 241.333, Bottom = 260 };
                    break;

                case 15:
                    //shadow1" Data="M235,208 L231,300"  Margin="180,284.25,253.333,264"   /> 3
                    shadow1.Margin = new Thickness { Left = 180, Top = 284.25, Right = 253.333, Bottom = 264 };
                    s1Geometry.StartPoint = new Point(235, 208);
                    s1Geometry.EndPoint = new Point(231, 300);
                    shadow1.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow1.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow1.Data = s1Geometry;
                    // shadow2" Data="M238,324.00107 L230,387.00137"  Margin="0,0,241.333,264"  Width="58.667"  Height="43.333"  /> 3
                    s2Geometry.StartPoint = new Point(238, 324.00107);
                    s2Geometry.EndPoint = new Point(230, 387.00137);
                    shadow2.Data = s2Geometry;
                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow2.Height = 47.333;
                    shadow2.Width = 58.667;
                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 241.333, Bottom = 264 };
                    break;

                case 16:
                    //shadow1" Data="M235,208 L231,300"  Margin="154.333,284.25,253.333,275"   />4
                    shadow1.Margin = new Thickness { Left = 154.333, Top = 284.25, Right = 253.333, Bottom = 275 };
                    s1Geometry.StartPoint = new Point(235, 208);
                    s1Geometry.EndPoint = new Point(231, 300);
                    shadow1.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow1.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow1.Data = s1Geometry;
                    // shadow2" Data="M238,324.00107 L230,387.00137"  Margin="0,0,241.333,275"  Width="84.334"  Height="32.333"  />
                    s2Geometry.StartPoint = new Point(238, 324.00107);
                    s2Geometry.EndPoint = new Point(230, 387.00137);
                    shadow2.Data = s2Geometry;
                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow2.Height = 32.333;
                    shadow2.Width = 84.334;
                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 241.333, Bottom = 275 };
                    break;
                case 17:
                    //shadow1" Data="M235,208 L231,300"  Margin="129,284.25,253.333,293.75"   />5
                    shadow1.Margin = new Thickness { Left = 129, Top = 284.25, Right = 253.333, Bottom = 293.75 };
                    s1Geometry.StartPoint = new Point(235, 208);
                    s1Geometry.EndPoint = new Point(231, 300);
                    shadow1.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow1.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow1.Data = s1Geometry;
                    // shadow2" Data="M238,324.00107 L230,387.00137"  Margin="0,0,241.333,293.75"  Width="109.667"  Height="13.583"  />5
                    s2Geometry.StartPoint = new Point(238, 324.00107);
                    s2Geometry.EndPoint = new Point(230, 387.00137);
                    shadow2.Data = s2Geometry;
                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow2.Height = 13.583;
                    shadow2.Width = 109.667;
                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 241.333, Bottom = 293.75 };
                    break;
                case 18:
                    //shadow1" Data="M235,208 L231,300"  Margin="107,284.25,253.333,321"   /> 6
                    shadow1.Margin = new Thickness { Left = 107, Top = 284.25, Right = 253.333, Bottom = 321 };
                    s1Geometry.StartPoint = new Point(235, 208);
                    s1Geometry.EndPoint = new Point(231, 300);
                    shadow1.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow1.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow1.Data = s1Geometry;
                    //        shadow2" Data="M238,324.00107 L260,387.00137"  Margin="0,0,241.333,305.333"  Width="131.667"  Height="16"  />6
                    s2Geometry.StartPoint = new Point(238, 324.00107);
                    s2Geometry.EndPoint = new Point(260, 387.00137);
                    shadow2.Data = s2Geometry;
                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow2.Height = 16;
                    shadow2.Width = 131.667;
                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 241.333, Bottom = 305.333 };
                    break;

                case 19:
                    //shadow1" Data="M235,208 L261,300"  Margin="107,271.667,253.333,338.333"   /> 7
                    shadow1.Margin = new Thickness { Left = 107, Top = 271.667, Right = 253.333, Bottom = 338.333 };
                    s1Geometry.StartPoint = new Point(235, 208);
                    s1Geometry.EndPoint = new Point(261, 300);
                    shadow1.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow1.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow1.Data = s1Geometry;
                    //  Data="M238,324.00107 L260,387.00137"  Margin="0,0,241.333,305.333"  Width="131.667"  Height="47"  /> 7
                    s2Geometry.StartPoint = new Point(238, 324.00107);
                    s2Geometry.EndPoint = new Point(260, 387.00137);
                    shadow2.Data = s2Geometry;
                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow2.Height = 47;
                    shadow2.Width = 131.667;
                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 241.333, Bottom = 305.333 };
                    break;

                case 20:
                    //s shadow1" Data="M235,208 L261,300"  Margin="121.667,244.333,253.333,338.333"   /> 8   
                    shadow1.Margin = new Thickness { Left = 121.667, Top = 244, Right = 253.333, Bottom = 338.333 };
                    s1Geometry.StartPoint = new Point(235, 208);
                    s1Geometry.EndPoint = new Point(261, 300);
                    shadow1.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow1.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow1.Data = s1Geometry;
                    // w2" Data="M238,324.00107 L260,387.00137"  Margin="0,0,241.333,305.333"  Width="116.667"  Height="74"  /> 8
                    s2Geometry.StartPoint = new Point(238, 324.00107);
                    s2Geometry.EndPoint = new Point(260, 387.00137);
                    shadow2.Data = s2Geometry;
                    shadow2.HorizontalAlignment = HorizontalAlignment.Right;
                    shadow2.VerticalAlignment = VerticalAlignment.Bottom;
                    shadow2.Height = 74;
                    shadow2.Width = 116.667;
                    shadow2.Margin = new Thickness { Left = 0, Top = 0, Right = 241.333, Bottom = 305.333 };
                    break;

            }



        }
    }
}
