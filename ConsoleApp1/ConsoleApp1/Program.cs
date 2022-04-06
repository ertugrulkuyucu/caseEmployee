using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> allSchedules = new List<List<string>>();

            List<Personal> personalList = new List<Personal>()
            {
                new Personal("Ertugrul","Kuyucu"),
                new Personal("Serkan","Diker"),
                new Personal("Emre", "Sagir"),
                new Personal("Berke", "Gul"),
                new Personal("Umut", "Buyukyildiz"),
                new Personal("Ali", "Aksoy")
            };

            List<Job> jobList = new List<Job>()
            {
                new Job("Catlak kontrolu yap",1),
                new Job("Kamyon sur", 2),
                new Job("LHD sur", 3),
                new Job("Tahkimat yap", 4),
                new Job("Patlatma Deliklerini hazırla", 5),
                new Job("Patlayici yerlestir", 6)
            };

            Random random = new Random();
            int randomNumber;

            //doList ile her bir isciye farklı is verilecek. yani ilerin unique sahipleri olacak.
            List<string> doList()
            {
                List<string> schedule = new List<string>();
                //bu dongu ile iscilere sırayla gorev ataniyor(i personeli temsil ediyor)
                for (int i = 0; i < 6; i++)
                {
                    schedule.Add(personalList[i].Name.ToString() + " " + personalList[i].Surname.ToString());
                point1:
                    randomNumber = random.Next(0, 6);
                    //ilk kisiye is verilmis mi
                    if (i != 0)
                    {
                        //burada verilen random daha once bu listede kullanılmıs mı kontrolu yapiliyor
                        for (int a = 1; a < schedule.Count; a += 2)
                        {

                            if (schedule[a].ToString() == jobList[randomNumber].JobName.ToString())
                            {
                                goto point1;
                            }
                        }
                        schedule.Add(jobList[randomNumber].JobName.ToString());
                    }
                    else
                        schedule.Add(jobList[randomNumber].JobName.ToString());
                }
                return schedule;
            }

            //bu dongu gorevlerin esit dagılması icin her gun farklı olması icin
            for (int x = 0; x < 6; x++)
            {
                point2:
                List<string> temp = new List<string>();
                List<string> temp2 = new List<string>();
                temp = doList();

                if (x != 0)
                {
                    for (int q = 0; q < allSchedules.Count; q++)
                    {
                        temp2 = allSchedules[q];

                        for (int i = 1; i < temp.Count; i += 2)
                        {
                            if (temp2[i] == temp[i])
                            {
                                goto point2;
                            }
                        }
                    }
                    
                    allSchedules.Add(temp);                   
                }
                else
                allSchedules.Add(doList());
            }

            for (int x = 0; x < allSchedules.Count; x++)
            {
                Console.WriteLine($"--Day {x + 1}--");
                foreach (var item in allSchedules[x])
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadLine();
        }
    }
}
