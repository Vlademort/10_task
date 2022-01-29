using System;

namespace _10_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите градусы для первого угла: ");
            int gradus_1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите минуты для первого угла: ");
            int minute_1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите секунды для первого угла: ");
            int second_1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Angle a_1 = new Angle(gradus_1, minute_1, second_1);
            Console.WriteLine();

            if (a_1.ToRadian() * 180 / Math.PI >= 180)
            {
                Console.WriteLine();
            }

            else
            {
                Console.Write("Введите градусы для второго угла: ");
                int gradus_2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите минуты для второго угла: ");
                int minute_2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите секунды для второго угла: ");
                int second_2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Angle a_2 = new Angle(gradus_2, minute_2, second_2);
                Console.WriteLine();

                Ang3(a_1, a_2);
            }


            Console.WriteLine();
            Console.ReadKey();


            static void Ang3(Angle a_1, Angle a_2)
            {

                if (a_1.ToRadian() * 180 / Math.PI + a_2.ToRadian() * 180 / Math.PI >= 360)
                {
                    Console.WriteLine("");
                }
                else if (a_1.ToRadian() * 180 / Math.PI + a_2.ToRadian() * 180 / Math.PI >= 180)
                {
                    Console.WriteLine("Два угла превышают 180° и не могут образовать треугольник");
                }
                else
                {
                    double a_3_dgrad = (Math.PI * 180 / 180 - (a_1.ToRadian() + a_2.ToRadian())) * 180 / Math.PI;
                    double a_3_grad = Math.Floor(a_3_dgrad);
                    double a_3_dmin = 60 * (a_3_dgrad - a_3_grad);
                    double a_3_min = Math.Floor(a_3_dmin);
                    double a_3_dsec = 60 * (a_3_dmin - a_3_min);
                    double a_3_sec = Math.Round(a_3_dsec);
                    Console.WriteLine("Третий угол треугольника равен {0}°{1}'{2}'' ", a_3_grad, a_3_min, a_3_sec);
                }
            }
        }
    }
    class Angle
    {
        int grad;
        int min;
        int sec;

        public int Grad
        {
            set
            {
                if (value > 180)
                {
                    Console.WriteLine("Угол не должен быть развернутым (180 градусов) или выпуклым (более 180 градусов)");
                    grad = 180;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Градусы не должны быть меньше 0");
                    grad = 360;
                }
                else
                {
                    grad = value;
                }
            }
            get
            {
                return grad;
            }
        }
        public int Min
        {
            set
            {
                if (value > 61 || value < 0)
                {
                    Console.WriteLine("Минуты должны быть только от 0 до 60");
                    min = 10800;
                }
                else
                {
                    min = value;
                }
            }
            get
            {
                return min;
            }
        }
        public int Sec
        {
            set
            {
                if (value > 61 || value < 0)
                {
                    Console.WriteLine("Секунды должны быть только от 0 до 60");
                    sec = 648000;
                }
                else
                {
                    sec = value;
                }
            }
            get
            {
                return sec;
            }
        }

        public Angle(int grad, int min, int sec)
        {
            Grad = grad;
            Min = min;
            Sec = sec;
        }

        public double ToRadian()
        {
            double m = Convert.ToDouble(Min);
            double s = Convert.ToDouble(Sec);
            double radians = Math.PI / 180 * (Grad + m / 60 + s / 3600);
            return radians;
        }
    }
}
