using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public  class GenderDetectedProcessor
    {
        private const string SUBSCRIPTION_KEY = "a0879753785e41f09338c56ccf974b41";
        private const string ENDPOINT = "https://ganderface.cognitiveservices.azure.com/";
        private const string RECOGNITION_MODEL4 = RecognitionModel.Recognition04;
        
        
        public static async Task<string> GetGenderByImgAsync(string imgUrl)
        {
            IFaceClient client =  Authenticate();
            try
            {
                IList<DetectedFace> detectedFaces = await DetectFaceExtractAsync(client, imgUrl);
                return detectedFaces.FirstOrDefault()?.FaceAttributes.Gender?.ToString() ?? "Unkonw";
            }
            catch
            {
                return "Unknow";
            }
            
        }

        private static  IFaceClient Authenticate()
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(SUBSCRIPTION_KEY)) { Endpoint = ENDPOINT };
        }
        private static async Task<IList<DetectedFace>> DetectFaceExtractAsync(IFaceClient client, string imgUrl)
        {

            // Detect faces with all attributes from image url.
            IList<DetectedFace> detectedFaces = await client.Face.DetectWithUrlAsync(imgUrl,
                returnFaceAttributes: new List<FaceAttributeType> { FaceAttributeType.Accessories, FaceAttributeType.Age,
                FaceAttributeType.Blur, FaceAttributeType.Emotion, FaceAttributeType.Exposure, FaceAttributeType.FacialHair,
                FaceAttributeType.Gender, FaceAttributeType.Glasses, FaceAttributeType.Hair, FaceAttributeType.HeadPose,
                FaceAttributeType.Makeup, FaceAttributeType.Noise, FaceAttributeType.Occlusion, FaceAttributeType.Smile },
                        // We specify detection model 1 because we are retrieving attributes.
                        detectionModel: DetectionModel.Detection01,
                        recognitionModel: RECOGNITION_MODEL4);
            return detectedFaces;

           }
        }

    }

