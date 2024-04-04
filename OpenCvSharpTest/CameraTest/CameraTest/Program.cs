using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CameraTest
{
    internal class Program
    {
        public VideoCapture capture;
        public Mat image;
        public bool isRecording = false;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting video capture. Press 'q' to quit.");

                var capture = new VideoCapture(0);

                if (!capture.IsOpened())
                {
                    Console.WriteLine("Failed to open the video capture device.");
                    return;
                }

                var image = new Mat();

                while (true)
                {
                    capture.Read(image);
                    if (image.Empty())
                    {
                        Console.WriteLine("No frame captured.");
                        continue;
                    }

                    Console.WriteLine($"Frame captured: {image.Width}x{image.Height}");


                    if (Console.KeyAvailable)
                    {
                        var keyInfo = Console.ReadKey(true);
                        if (keyInfo.KeyChar == 'q' || keyInfo.KeyChar == 'Q')
                        {
                            break;
                        }
                    }
                }

                Console.WriteLine("Video capture ended.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
