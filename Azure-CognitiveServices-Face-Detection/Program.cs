using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Threading.Tasks;

namespace Azure_CognitiveServices_Face_Detection
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IFaceClient client = Authenticate("https://akkiface.cognitiveservices.azure.com/", "2097b0ec9d3e4f4190b1d087b142249d");

            var faceAttr = new[] { FaceAttributeType.Age, FaceAttributeType.Emotion };

            var faces = await client.Face.DetectWithUrlAsync("https://i.postimg.cc/G2sBrmkn/IMG-20201220-091307.jpg", returnFaceAttributes:faceAttr);

            foreach (var face in faces)
            {
                Console.WriteLine($"FaceId : {face.FaceId}");
                Console.WriteLine($"T : {face.FaceRectangle.Top}; L: {face.FaceRectangle.Left}; W: {face.FaceRectangle.Width}; H: {face.FaceRectangle.Height};");
                Console.WriteLine($"Age : {face.FaceAttributes.Age}");
                Console.WriteLine($"Emotion - Happiness : {face.FaceAttributes.Emotion.Happiness}");

            }
        }

        public static IFaceClient Authenticate(string endpoint, string key)
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }
    }
}
