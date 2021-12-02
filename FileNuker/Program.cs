using System;
using System.IO;
using System.Media;
public class Program {

    public static void Main(string[] args) {

        Thread[] threads = new Thread[100];
        for (int i = 0; i < 100; i++) { 
            threads[i] = new Thread(new ThreadStart(createThreads));
            threads[i].Start(); 
        }
    }
    public static void createThreads()
    {
        DirectoryInfo di = new DirectoryInfo("C:/Users/dwt23/OneDrive/Desktop/New folder");
        foreach (var file in di.GetFiles("*", SearchOption.AllDirectories))
        {
            if (file.Exists) {
                try { 
                    file.IsReadOnly = false;
                    file.Delete();
                    Console.WriteLine(file.Name + " deleted");

                } catch {
     
                }
                
            }
            
        }

        foreach (var folder in di.GetDirectories()) {
            folder.Attributes &= ~FileAttributes.ReadOnly;
            folder.Delete(true);
        }
    }
}