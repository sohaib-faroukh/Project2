using SourceAFIS.Simple;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace CustomerProfileBank.FingerPrint
{
    public class MyPerson : SourceAFIS.Simple.Person
    {
        public string Name { get; set; }
        public string FingerUrl { get; set; }
        public float MatchValue { get; set; }
    }

    public class FingerprintObject : SourceAFIS.Simple.Fingerprint
    {
        public string FileName { get; set; }
    }

    public class FingerPrintBestMatch
    {
        private AfisEngine Afis;
        private string FileAddress;
        private string imageurl;
        private string progressvalue;




        ////////////////////get file to compare//////////////////

        result result = new result();
        CompareTwoFingerPrints ctF = new CompareTwoFingerPrints();
        public result match(string source,List<string> images)
        {

            // Matching features
            Afis = new AfisEngine();
            Afis.Threshold = 10;

            List<MyPerson> Database = new List<MyPerson>();

            foreach (var file in images)
            {
                Database.Add(Enroll(file, new FileInfo(file).Name));
            }

            MyPerson probe = Enroll(source, new FileInfo(source).Name);

            Dictionary<float, MyPerson> dict = new Dictionary<float, MyPerson>();

           
            int count = 1;

            foreach (var item in Database)
            {
                         
                float match = Afis.Verify(probe, item);

                item.MatchValue = match;

                dict.Add(count, item);

               

                //Thread.Sleep(100);
                count++;
            }

            float highest = 0;
            foreach (var item in dict)
            {

                if (highest == 0)
                {
                    highest = item.Value.MatchValue;
                }

                else
                {
                    if (item.Value.MatchValue > highest)
                    {
                        highest = item.Value.MatchValue;
                    }
                }
            }

            var final = dict.Where(g => g.Value.MatchValue == highest).FirstOrDefault();
            if(final.Value == null)
            {
                result.Code = 1;
                result.Message = "Fingerprint not found";
                return result;
            }
            else
            {
               var tr= ctF.match(source,final.Value.FingerUrl);
                return tr;
            }

            //Thread.Sleep(500);
          
        }

        
        private MyPerson Enroll(string filename, string name)
        {
            //Console.WriteLine("Enrolling {0}...", name);

            // Initialize empty fingerprint object and set properties
            FingerprintObject fp = new FingerprintObject();
            fp.FileName = filename;
            // Load image from the file
            //Console.WriteLine(" Loading image from {0}...", filename);
            BitmapImage image = new BitmapImage(new Uri(filename, UriKind.RelativeOrAbsolute));
            fp.AsBitmapSource = image;
            // Above update of fp.AsBitmapSource initialized also raw image in fp.Image
            // Check raw image dimensions, Y axis is first, X axis is second
            //Console.WriteLine(" Image size = {0} x {1} (width x height)", fp.Image.GetLength(1), fp.Image.GetLength(0));

            // Initialize empty person object and set its properties
            MyPerson person = new MyPerson();
            person.Name = name;
            person.FingerUrl = filename;
            // Add fingerprint to the person
            person.Fingerprints.Add(fp);

            // Execute extraction in order to initialize fp.Template
            //Console.WriteLine(" Extracting template...");
            Afis.Extract(person);
            // Check template size
            //Console.WriteLine(" Template size = {0} bytes", fp.Template.Length);

            return person;
        }
    }
}
