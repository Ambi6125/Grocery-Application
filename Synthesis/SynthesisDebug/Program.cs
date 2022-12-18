using SynthesisLogic.Cart;

namespace Debugging
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, int> data = new Dictionary<string, int>();

             string cookieString = Console.ReadLine();
            if(cookieString != null)
            {
                foreach(var result in OrderFormatter.Deformat(cookieString))
                {
                    data.Add(result);
                }
            }


            foreach(var v in data)
            {
                Console.WriteLine($"{v.Value}x {v.Key}");
            }
        }
    }
}