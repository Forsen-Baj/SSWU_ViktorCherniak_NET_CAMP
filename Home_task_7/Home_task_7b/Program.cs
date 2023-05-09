using Home_task_7b;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

List<ClassicTrafficLight> trafficLights = new List<ClassicTrafficLight>() {
    // при довільній ініціалізації світлофори можуть бути неправильно синхронізовані.
    new ClassicTrafficLight("Північ-південь", 0, new int[] { 3, 2, 4 }),
    new ClassicTrafficLight("Південь-північ", 0, new int[] { 3, 2, 4 }),
    new ClassicTrafficLight("Схід-захід", 2, new int[] { 3, 2, 4 }),
    new ClassicTrafficLight("Захід-схід", 2, new int[] { 3, 2, 4 })

};

TrafficLightController controller = new TrafficLightController(trafficLights);

controller.ImitateConsole(1);
