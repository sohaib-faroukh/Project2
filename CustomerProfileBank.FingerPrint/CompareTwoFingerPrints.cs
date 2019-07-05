using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PatternRecognition.FingerprintRecognition.Core;
using PatternRecognition.FingerprintRecognition.FeatureExtractors;
using PatternRecognition.FingerprintRecognition.Matchers;
namespace CustomerProfileBank.FingerPrint
{
    public class  result
    {
        public string accuracy { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
    public class CompareTwoFingerPrints
    {
        result result = new result();
         string score;
         string qry;
         string temp;

        private Bitmap Change_Resolution(string file)
        {

            using (Bitmap bitmap = (Bitmap)Image.FromFile(file))
            {
                using (Bitmap newBitmap = new Bitmap(bitmap))
                {
                    newBitmap.SetResolution(500, 500);
                    return newBitmap;
                }
            }

        }



        public result match(string query, string template)
        {
         
            Change_Resolution(query);
            Change_Resolution(template);
            // Loading fingerprints
            var fingerprintImg1 = ImageLoader.LoadImage(query);
            var fingerprintImg2 = ImageLoader.LoadImage(template);
            //// Building feature extractor and extracting features
            var featExtractor = new PNFeatureExtractor() { MtiaExtractor = new Ratha1995MinutiaeExtractor() };
            var features1 = featExtractor.ExtractFeatures(fingerprintImg1);
            var features2 = featExtractor.ExtractFeatures(fingerprintImg2);

            // Building matcher and matching
            var matcher = new PN();
            double similarity = matcher.Match(features1, features2);
            score = similarity.ToString("0.00");
            result.accuracy = score;
            if(similarity > 75.0)
            {
                result.Code = 0;
                result.Message = "Matched";
            }
            else
            {
                result.Code = 2;
                result.Message = "Not Matched";
            }

            return result;
        }

    }
}
