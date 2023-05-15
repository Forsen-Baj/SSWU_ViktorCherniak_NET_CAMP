using Home_task_7b;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

/*List<ClassicTrafficLight> trafficLights = new List<ClassicTrafficLight>() {
    
    new ClassicTrafficLight("Північ-південь", 0, new int[] { 3, 2, 4 }),
    new ClassicTrafficLight("Південь-північ", 0, new int[] { 3, 2, 4 }),
    new ClassicTrafficLight("Схід-захід", 2, new int[] { 3, 2, 4 }),
    new ClassicTrafficLight("Захід-схід", 2, new int[] { 3, 2, 4 })
};

TrafficLightController controller = new TrafficLightController(trafficLights);

controller.ImitateConsole(1);*/

Crossroad sampleCrossroad1 = new Crossroad("вул. Шевченка / вул. Франка");
Crossroad sampleCrossroad2 = new Crossroad("вул. Лесі Українки / прос. Григоренка");

sampleCrossroad1.AddTrafficLight(new ClassicTrafficLight("Пн>Пд Шевченка 1", 0, new int[] { 3, 2, 4 }));
sampleCrossroad1.AddTrafficLight(new ClassicTrafficLight("Пн>Пд Шевченка 2", 0, new int[] { 3, 2, 4 }));
sampleCrossroad1.AddTrafficLight(new DirectedTrafficLight("Пн>Пд Шевченка 3", 0, new int[] { 3, 2, 4, 4 }));

sampleCrossroad1.AddTrafficLight(new DirectedTrafficLight("Пд>Пн Шевченка 1", 2, new int[] { 3, 2, 4, 4 }));
sampleCrossroad1.AddTrafficLight(new DirectedTrafficLight("Пд>Пн Шевченка 2", 2, new int[] { 3, 2, 4, 4 }));

sampleCrossroad1.AddTrafficLight(new ClassicTrafficLight("Сх>Зх Франка 1", 0, new int[] { 3, 2, 4 }));
sampleCrossroad1.AddTrafficLight(new ClassicTrafficLight("Зх>Сх Франка 1", 2, new int[] { 3, 2, 4 }));


sampleCrossroad2.AddTrafficLight(new ClassicTrafficLight("Пн>Пд Лесі Українки 1", 0, new int[] { 5, 1, 6 }));
sampleCrossroad2.AddTrafficLight(new ClassicTrafficLight("Пн>Пд Лесі Українки 2", 0, new int[] { 5, 1, 6 }));

sampleCrossroad2.AddTrafficLight(new DirectedTrafficLight("Пд>Пн Лесі Українки 1", 2, new int[] { 5, 1, 6, 2 }));
sampleCrossroad2.AddTrafficLight(new DirectedTrafficLight("Пд>Пн Лесі Українки 2", 2, new int[] { 5, 1, 6, 2 }));

sampleCrossroad2.AddTrafficLight(new ClassicTrafficLight("Сх>Зх Григоренка 1", 0, new int[] { 5, 1, 6 }));
sampleCrossroad2.AddTrafficLight(new ClassicTrafficLight("Зх>Сх Григоренка 1", 2, new int[] { 5, 1, 6 }));

TrafficLightController controller = new TrafficLightController();

controller.AddLightsFromIntersection(sampleCrossroad1);
controller.AddLightsFromIntersection(sampleCrossroad2);

controller.ImitateConsole(1);