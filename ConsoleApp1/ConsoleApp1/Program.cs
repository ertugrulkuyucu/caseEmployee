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
            #region MyRegion
            //Personal p1 = new Personal("Ertugrul","Kuyucu",1);
            //Personal p2 = new Personal("Serkan","Diker",2);
            //Personal p3 = new Personal("Emre","Sagir",3);
            //Personal p4 = new Personal("Berke","Gul",4);
            //Personal p5 = new Personal("Umut","Buyukyildiz",5);
            //Personal p6 = new Personal("Ali","Aksoy",6);

            //Job j1 = new Job("Catlak kontrolu yap",1);
            //Job j2 = new Job("Kamyon sür",2);
            //Job j3 = new Job("LHD sür",3);
            //Job j4 = new Job("Tahkimat yap",4);
            //Job j5 = new Job("Delik del", 5);
            //Job j6 = new Job("Patlayıcı yerlesti", 6);

            #endregion

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
                new Job("Delik del", 5),
                new Job("Patlayici yerlestir", 6)
            };
            
            Random random = new Random ();
            int randomNumber;

            for (int x = 0; x < 6; x++)
            {
                List<string> schedule = new List<string>();
                for (int i = 0; i < 6; i++)
            {
                schedule.Add(personalList[i].Name.ToString() + personalList[i].Surname.ToString());
                basadon:
                randomNumber = random.Next(0, 6);
                if (i != 0)
                {
                    for (int a = 1; a < schedule.Count; a += 2)
                    {
                        if (schedule[a].ToString() == jobList[randomNumber].JobName.ToString())
                        {
                            goto basadon;
                        }
                    }
                    schedule.Add(jobList[randomNumber].JobName.ToString());
                }
                else
                    schedule.Add(jobList[randomNumber].JobName.ToString());
            }
            allSchedules.Add(schedule);
            }

            foreach (var item in allSchedules)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}