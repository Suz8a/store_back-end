using System;
namespace TroquelApi.Services
{
    public class ContrasenaGen
    {
        public int GenerateRandomContrasena()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public int GenerateRandomFolio()
        {
            int _min = 100000;
            int _max = 999999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

    }
}
