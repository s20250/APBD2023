using System.ComponentModel;



namespace APBD_zad3;

public class CSVfile
{
    public static string filePath = "/Users/magdalena/Documents/GitHub/APBD2023/APBD_zad3/APBD_zad3/CSVfiles/dane.csv";

    public static void ReadCSV(List<Student> list)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            var values = line.Split(',');
            list.Add(new Student(values[0],values[1],Convert.ToInt32(values[2]),Convert.ToDateTime(values[3]),values[4],values[5],values[6],values[7],values[8])
            );
            
        }
   
    }
    
    public static void SaveToCSV(List<Student> saveData, bool overwrite)
    {
        var lines = new List<string>();
        IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(Student)).OfType<PropertyDescriptor>();
        var header = string.Join(",", props.ToList().Select(x => x.Name));
        //lines.Add(header);
        var valueLines = saveData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
        lines.AddRange(valueLines);
        if (overwrite == true)
        {
            File.WriteAllLines(filePath, lines.ToArray());
        }
        else
        {
            File.AppendAllLines(filePath, lines.ToArray());
        }
    }


}