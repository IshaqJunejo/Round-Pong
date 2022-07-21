namespace RoundPong
{
    // Class for some Calculation or Conversions
    public class ChangeFrom
    {
        public static float DegToRad(float deg)
        {
            return ( deg * 3.14f ) / 180.0f;
        }

        public static float RadToDeg(float radian)
        {
            return radian * 180.0f / 3.14f;
        }
    }
}