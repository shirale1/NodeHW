using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NodeHW //שב עמוד 76 תרגילים זוגיים
{
    internal class HomeWork
    {
        public int ReturnRetzf(Node<int> lst, int x)//שאלה 2
        //סיבוכיות: אורך הקלט הוא אורך הרשימה/מספר החוליות 
        //במקרה הגרוע- נעבור על כל החוליות בשרשרת ובכל סיבוב נבצע מספר קבוע של פעולות
        //לכן הסיבוכיות היא o(n)
    
        {
            int counter = 0;
            while (lst != null && lst.HasNext())
            {
                if (lst.GetValue() == x && lst.GetNext().GetValue() != x)
                {
                    counter++;
                }
                while (lst.GetValue() == x)
                {
                    if (lst.GetNext().GetValue() != x)
                    {
                        counter++;
                    }
                    lst = lst.GetNext();
                }
            }
            if (lst.GetValue() == x)
                return counter + 1;
            return counter;
        }
        public static string IfEven(Node<int> lst)// שאלה 4
   //סיבוכיות: אורך הקלט הוא אורך הרשימה/מספר החוליות 
   //במקרה הגרוע- נעבור על כל החוליות בשרשרת ובכל סיבוב נבצע מספר קבוע של פעולות
                //לכן הסיבוכיות היא o(n)
        {
            int counterS = 0; int counterZ = 0; int counterE = 0;
            while (lst != null && lst.HasNext())
            {
                if (lst.GetValue() % 2 == 0)
                {
                    counterZ++;
                }
                else
                {
                    counterE++;
                }
                lst = lst.GetNext();
            }
            if (lst != null)
            {
                if (lst.GetValue() % 2 == 0)
                {
                    counterZ++;
                }
                else
                {
                    counterE++;
                }
            }
            if (counterZ > counterE)
            {
                return "z";
            }
            else if (counterE > counterZ)
            {
                return "e";
            }
            else
            {
                return "s";
            }

        }
        public static Node<T> NoDoubles<T>(Node<T> lst)
            //שאלה 6
            //  סיבוכיות: אורך הקלט הוא אורך השרשרת וגם אורך הקלט של הפעולה הנוספת 
            //שמתבצעת בכל לולאה ובודקת האם האיבר כבר קיים
            //isexist עם סיבוכיות של o(n)
            //לכן הסיבוכיות בפעולה היא o(n)^2
           
        {
            if (lst == null)
                return null;
            Node<T> newlst = new Node<T>(lst.GetValue());
             lst=lst.GetNext();
            while (lst!=null)
            {
                if(!(NodeHelper.IsExists(newlst, lst.GetValue())))
                {
                    newlst.SetNext(new Node<T>(lst.GetValue()));
                }
                lst=lst.GetNext();
                    
            }
            return newlst;

        }
        public static bool IsSorted(Node<int> lst)//שאלה 8
        //סיבוכיות: אורך הקלט הוא אורך הרשימה/מספר החוליות 
    //במקרה הגרוע- נעבור על כל החוליות בשרשרת ובכל סיבוב נבצע מספר קבוע של פעולות
                  //לכן הסיבוכיות היא o(n)
        {
            if (lst == null)
            {
                return false;
            }
            while (lst.HasNext())
            {
                if (!(lst.GetValue() < lst.GetNext().GetValue()))
                {
                    return false;
                }
            }
            return true;
        }
        public static Node<int> ReturnNode(int beginner, int num)//שאלה 10
         //סיבוכיות: אורך הקלט הוא כמות הספרות שאמורה להכיל הרשימה החדשה
        //במקרה הגרוע- מספר החוליות שהתקבל כקלט יהיה גדול מאוד ונצטרך לעשות הרבה סיבובים
        //בכל אחד מהם נבצע מספר פעולות קבועות ולכן הסיבוכיות היא 
         // o(n)
        {
            Node<int> newone = new Node<int>(beginner);
            int i = 1;
            while (i < num)
            {
                newone.SetNext(new Node<int>(beginner + 1));
                beginner++;
                i++;
            }
            return newone;
        }
        public static bool IsBalanced(Node<int> lst)//שאלה 12
            //סיבוכיות: אורך הקלא הוא מספר החוליות בשרשרת משום שצריך בהתחלה לעבור
            //על כולן כדי לחשב ממוצע, ואז לעבור עליהן שוב כדי לבדוק איזו חולייה
            //נמצאת מעל ומתחת לממוצע ולכן נבצע שתי לולאות ובכל אחת
            //מהן מספר פעולות קבועות אז הסיבוכיות היא o(n)
        {
            double sum = 0; int counter = 0;

            while (lst.HasNext())
            {
                sum += lst.GetValue();
                lst = lst.GetNext();
                counter++;
            }
            double average = sum / counter;
            int above = 0;
            int under = 0;
            while (lst.HasNext())
            {
                if (lst.GetValue() < average)
                {
                    under++;
                }
                else if (lst.GetValue() > average)
                {
                    above++;
                }
                lst = lst.GetNext();
            }
            if (above == under)
            {
                return true;
            }
            return false;
        }
        public static Node<int> DeleteSmallest(Node<int> lst, int num)//שאלה 14
            //הסיבוכיות: אורך הקלט הוא אורך השרשרת 
            //בכל סיבוב יתבצעו פעולות קבועות וקריאה לפעולה נוספת שהסיבוכיות שלה היא o(n)
           //לכן הסיבוכיות היא o(n)^2
        {
            Node<int> newHead = lst;
            Node<int> max;
            for (int i = 0; i < num; i++)
            {
                max = FindBigestNum(lst);
                if (lst.Equals(max))
                {
                    newHead = lst.GetNext();
                    lst.SetNext(null);
                }
                else
                {
                    Node<int> next = lst.GetNext();
                    while (!(next.Equals(max)))
                    {
                        lst = next.GetNext();
                    }
                    lst.SetNext(next.GetNext());
                    next.SetNext(null);
                }
            }
            return newHead;

        }
        public static Node<int> FindBigestNum(Node<int> lst) //פעולת עזר לשאלה 14 שמחזירה את החוליה שיש לה את הערך הגדול ביותר 
        {
            Node<int> head = lst;
            int max = lst.GetValue();
            Node<int> maxNode = lst;
            while (lst != null && lst.HasNext())
            {
                if (lst.GetValue() > max)
                {
                    max = lst.GetValue();
                    maxNode = lst;
                }
                lst = lst.GetNext();
            }
            return maxNode;

        }
    }
}


