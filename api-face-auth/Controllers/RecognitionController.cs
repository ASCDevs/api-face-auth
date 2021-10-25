using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using api_face_auth.Models;


namespace api_face_auth.Controllers
{

    //Referências 
    // https://github.com/mesutpiskin/face-detection-and-recognition/blob/f9dda3125e007da82dc3204cbdb5120d75a762bc/src/FaceDetectionAndRecognition/WFFaceRecognition.xaml.cs#L248
    // https://www.youtube.com/watch?v=zLgIy0o_0Ow&ab_channel=1BestCsharpblog
    // https://www.emgu.com/wiki/files/4.5.3/document/html/8dee1f02-8c8a-4e37-87f4-05e10c39f27d.htm
    // https://www.emgu.com/wiki/files/4.5.3/document/html/71e793d0-6bf2-50d3-10de-426071162dde.htm
    public class RecognitionController
    {
        private CascadeClassifier haarCascade {get;set;}
        private EigenFaceRecognizer recognizer {get;set;}
        private VectorOfMat imageList = new VectorOfMat();

        private List<FaceModel> faceList = new List<FaceModel>();
        //private List<FaceData> faceList = new List<FaceData>();
        private VectorOfInt userIdList = new VectorOfInt();
        private Image<Gray,Byte> detectedFace = null;


        public void trainFaceRecognition(){ //Receber o model do user a ter a face treinada para reconhecimento
            
            if(!File.Exists(Config.HaarCascadePath)){
                Console.WriteLine(">train face: Caminho("+Config.HaarCascadePath+") não encontrado");

            }
            
            haarCascade = new CascadeClassifier(Config.HaarCascadePath);
            faceList.Clear();

            if(!Directory.Exists(Config.FacePhotosPath)){
                Directory.CreateDirectory(Config.FacePhotosPath);
            }

            //Receber 
            FaceModel faceInstance = new FaceModel();
            //faceInstance.imagemBytes = new Image<Gray,byte[]>(Config.FacePhotosPath+faceInstance.nomeId+faceInstance.extensao);

            faceList.Add(faceInstance);

            foreach(var face in faceList){
                //imageList.Push(face.imagemBytes.Mat);
                //useridList.Add(face.idUser);
            }

            if(imageList.Size > 0){
                recognizer = new EigenFaceRecognizer(imageList.Size);
                recognizer.Train(imageList,userIdList);
            }

            //ver linha 209 e 210
            //recognizer = new EigenFaceRecognizer(imageList.Size);
            //recognizer.Train(imageList, labelList)
        }

        public void authorizeFace(){
            if(imageList.Size != 0){

                //Aplica o algoritmo de Eigen Face
                FaceRecognizer.PredictionResult result = recognizer.Predict(detectedFace.Resize(100,100, Inter.Cubic));
                //FaceName = FaceModel.idUser
            }
            
        }


        public void capturedFace(){
            detectedFace = detectedFace.Resize(100,100, Inter.Cubic);
            detectedFace.Save(Config.FacePhotosPath+"face_"+(faceList.Count+1)+Config.ImageFileExtension);
        }

    }
}