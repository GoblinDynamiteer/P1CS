using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_exercise_13_6
{
    class City
    {
        private float temperature;

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public City(string name, float temperature)
        {
            this.temperature = temperature;
            this.name = name;
        }

    }

    class CityTemperatures
    {
        private List<City> cities = new List<City>();
        private City minTempCity, maxTempCity;
        private float averegeTemp = 0f;

        public void AddCity(string name, float temperature)
        {
            cities.Add(new City(name, temperature));
            setMinTemp();
            setMaxTemp();
            setAverageTemp();
        }

        public void ListCities()
        {
            if (!cities.Any()) {
                Console.WriteLine("No cities in list!");
                return;
            }

            Console.WriteLine(" Cities: \n");
            foreach (City city in cities)
            {
                Console.WriteLine(" {0:N1}" +
                    "\n  Temp: {1:N1}", 
                        city.Name, city.Temperature);
            }

            Console.WriteLine("\n Average temp: {0}", averegeTemp);
            Console.WriteLine(" Max temp: {0}, {1} degrees", 
                maxTempCity.Name, 
                maxTempCity.Temperature);
            Console.WriteLine(" Min temp: {0}, {1} degrees",
                minTempCity.Name,
                minTempCity.Temperature);
        }

        private void setMinTemp()
        {
            minTempCity = cities[0];
            foreach (City city in cities)
            {
                minTempCity = minTempCity.Temperature > city.Temperature ? 
                    city : minTempCity;
            }
        }

        private void setMaxTemp()
        {
            maxTempCity = cities[0];
            foreach (City city in cities)
            {
                maxTempCity = maxTempCity.Temperature < city.Temperature ?
                    city : maxTempCity;
            }
        }

        private void setAverageTemp()
        {
            averegeTemp = 0f;

            foreach (City city in cities)
            {
                averegeTemp += city.Temperature;
            }

            averegeTemp /= cities.Count();
        }
    }
}
