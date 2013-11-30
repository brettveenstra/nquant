namespace nQuant
{
    public class ColorData
    {
        public ColorData(byte dataGranularity, int bitmapWidth, int bitmapHeight)
        {
            checked { dataGranularity++; }

            Weights = new long[dataGranularity, dataGranularity, dataGranularity, dataGranularity];
            MomentsAlpha = new long[dataGranularity, dataGranularity, dataGranularity, dataGranularity];
            MomentsRed = new long[dataGranularity, dataGranularity, dataGranularity, dataGranularity];
            MomentsGreen = new long[dataGranularity, dataGranularity, dataGranularity, dataGranularity];
            MomentsBlue = new long[dataGranularity, dataGranularity, dataGranularity, dataGranularity];
            Moments = new float[dataGranularity, dataGranularity, dataGranularity, dataGranularity];

            checked
            {
                int pixelCount = bitmapWidth*bitmapHeight;
                pixels = new Pixel[pixelCount];
                quantizedPixels = new Pixel[pixelCount];
            }
        }

        public long[, , ,] Weights { get; private set; }
        public long[, , ,] MomentsAlpha { get; private set; }
        public long[, , ,] MomentsRed { get; private set; }
        public long[, , ,] MomentsGreen { get; private set; }
        public long[, , ,] MomentsBlue { get; private set; }
        public float[, , ,] Moments { get; private set; }

        public Pixel[] QuantizedPixels { get { return quantizedPixels; } }
        public Pixel[] Pixels { get { return pixels; } }

        public int PixelsCount { get { return pixels.Length; } }
        public void AddPixel(Pixel pixel, Pixel quantizedPixel)
        {
            pixels[pixelFillingCounter] = pixel;
            quantizedPixels[pixelFillingCounter++] = quantizedPixel;
        }

        private readonly Pixel[] pixels;
        private readonly Pixel[] quantizedPixels;
        private int pixelFillingCounter;
    }
}