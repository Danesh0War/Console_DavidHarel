using System.Text.Json;

namespace FinalPoj1.Servises
{
    internal class Attendance // Class responsible for Attendance management
    {
        // Set Report
        public static void SetAttendanceReport(string id) // Main func to create a new attendance report
        {

            string filePath = Path.Combine(FileManager.mainFolderPath + "\\Client\\" + @$"{id}", "Attendance.json");
            if (File.Exists(filePath)) // different action based on whether we already saved report (and created a file )
            {
                AddToExistTimeReportFile(filePath, id);
            }

            else
            {
                CreateNewTimeReportFile(filePath, id);
            }
        }

        static private void CreateNewTimeReportFile(string filePath, string id)
        {
            DateTime currentTime = DateTime.Now;
            string[] timeReports = { $"{id} visited our GYM at {currentTime}" }; // create a new report. Was previously as DateTime[] timeReports but according to requirements file must contain also ID so string.

            string serializedDate = JsonSerializer.Serialize(timeReports); // convert to json

            try
            {
                File.WriteAllText(filePath, serializedDate); // try to create a new json and put the report in it
                Console.WriteLine("Time Report file created");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the directory or writing to the file: {ex.Message}");
            }
        }

        static private void AddToExistTimeReportFile(string filepath, string id)
        {
            string serializedDate = File.ReadAllText(filepath); // Read the created json
            string[] timeReports = JsonSerializer.Deserialize<string[]>(serializedDate); // deserialize it to be abble to modify and put into string arr

            DateTime currentTime = DateTime.Now;
            Array.Resize(ref timeReports, timeReports.Length + 1); // expend arr by 1 for the new date
            timeReports[timeReports.Length - 1] = $"{id} visited our GYM at {currentTime}"; // add new report

            string updatedData = JsonSerializer.Serialize(timeReports); // serialize back to json
            File.WriteAllText(filepath, updatedData); // save again
            Console.WriteLine("Time report added to the file"); // indication message
        }


        //Get Report
        public static void GetAttendancyReport(string id) // func returns the saved reports in Attendance.json
        {
            string filePath = Path.Combine(FileManager.mainFolderPath + "\\Client\\" + @$"{id}", "Attendance.json");
            if (File.Exists(filePath)) // check whether user decided to create a report
            {
                string serialisedDate = File.ReadAllText(filePath); // if yes, read
                string[] timeReports = JsonSerializer.Deserialize<string[]>(serialisedDate); // deserialize into string arr to be able to rerpesent in console. Every new reprot creation with AddToExistTimeReportFile is separated with "," in json so compiler understands that they are different values 
                //string[] separeteAttendance = timeReport.Split(",");
                foreach (string timeReport in timeReports)
                {
                    Console.WriteLine("*" + timeReport); // print each new report in new line
                }


            }
            else Console.WriteLine("File Attendance.json doesn't exist for the specified client "); // if not provide info that file not exist
        }
     
    }
   
}

