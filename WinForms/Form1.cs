using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private const string connectionString = "Server=niel;Database=actionType;;Trusted_Connection=True;TrustServerCertificate=True";
        private DataTable dataTable;
        double resultCalc;
        string resultCalcSt;
        string text1, text2;
        string resultAllHistory;
        private readonly HttpClient _httpClient;
        public Form1()
        {
            InitializeComponent();

            // Initialize _httpClient
            _httpClient = new HttpClient();

            LoadComboBoxValues();
        }

        private async void LoadComboBoxValues()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7064/api/values/getvalues");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    // Reading data from the response
                    string data = await response.Content.ReadAsStringAsync();

                    // Processing data - adjust the format based on your API response
                    List<MyObject> objectsList = ProcessData(data);


                    // Set up the ComboBox with items
                    comboBox1.ValueMember = "TypeOperation";
                    comboBox1.DisplayMember = "NameOperation";
                    comboBox1.DataSource = objectsList.ToList();
                    comboBox1.SelectedIndex = -1;


                }

                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error loading values: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static List<MyObject> ProcessData(string data)
        {
            // יש להתאים את הפונקציה למבנה הנתונים שלך
            // זו היא פונקציה דומה למבנה נתונים שכזה:
            // [{"name": "John", "number": 123}, {"name": "Alice", "number": 456}]
            List<MyObject> objectsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyObject>>(data);

            return objectsList;
        }

        // דוגמה למבנה אובייקט MyObject
        class MyObject
        {
            public string nameOperation { get; set; }
            public int typeOperation { get; set; }
        }

        private void BTN_calc_Click(object sender, EventArgs e)
        {


            double num1, num2;

            text1 = TXT1.Text;
            text2 = TXT2.Text;
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("לא נבחר פעולה לחישוב");
                return;
            }
            string selectednAME = ((MyObject)comboBox1.SelectedItem).nameOperation;

            object selectedValue = comboBox1.SelectedValue;

            // אם מדובר במספר שלם (int) לדוגמה
            if ((int)selectedValue == 1)
            {
                if (double.TryParse(text1, out double firstNumber) == false || double.TryParse(text2, out double secondNumber) == false)
                {
                    MessageBox.Show("פעולה זו לא מתאימה לערכים שהוזנו");
                }

            }
            //if ((int)selectedValue == 2)
            //{
            if (!string.IsNullOrEmpty(text2) && string.IsNullOrEmpty(text1))
            {
                
                    if (selectednAME == "+")
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(text2);
                        stringBuilder.Append(text1);

                        string result = stringBuilder.ToString();
                        resultCalcSt = text1 + "+" + text2 + "=" + result;
                        MessageBox.Show("התוצאה היא: " + result);
                        insertToTable(selectednAME);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("פעולה זו לא מתאימה לערכים שהוזנו");
                    }
                    return;
                }
                //}

                switch (selectednAME)
                {
                   
                    // ביצוע פעולות חשבון

                    case "*":
                    num1 = double.Parse(text1);
                    num2 = double.Parse(text2);
                    resultCalc = num1 * num2;
                    resultCalcSt = text1 + "*" + text2 + "=" + resultCalc.ToString();
                    insertToTable(selectednAME);
                    resultAllHistory = returnBYPRoc(selectednAME);
                    MessageBox.Show("התוצאה היא: " + resultCalc.ToString() + "\n" + resultAllHistory);
                    break;

                case "/":
                    num1 = double.Parse(text1);
                    num2 = double.Parse(text2);
                    resultCalc = num1 / num2;
                    resultCalcSt = text1 + "/" + text2 + "=" + resultCalc.ToString();
                    insertToTable(selectednAME);
                    resultAllHistory = returnBYPRoc(selectednAME);
                    MessageBox.Show("התוצאה היא: " + resultCalc.ToString() + "\n" + resultAllHistory);
                    break;

                case "-":
                    num1 = double.Parse(text1);
                    num2 = double.Parse(text2);
                    resultCalc = num1 - num2;
                    resultCalcSt = text1 + "-" + text2 + "=" + resultCalc.ToString();
                    insertToTable(selectednAME);
                    resultAllHistory = returnBYPRoc(selectednAME);
                    MessageBox.Show("התוצאה היא: " + resultCalc.ToString() + "\n" + resultAllHistory);
                    break;

                case "+":
                    num1 = double.Parse(text1);
                    num2 = double.Parse(text2);
                    resultCalc = num1 + num2;
                    resultCalcSt = text1 + "+" + text2 + "=" + resultCalc.ToString();
                    insertToTable(selectednAME);
                    resultAllHistory = returnBYPRoc(selectednAME);
                    MessageBox.Show("התוצאה היא: " + resultCalc.ToString() + "\n" + resultAllHistory);
                    break;

                case "%":
                    num1 = double.Parse(text1);
                    num2 = double.Parse(text2);
                    resultCalc = num1 % num2;
                    resultCalcSt = text1 + "%" + text2 + "=" + resultCalc.ToString();
                    insertToTable(selectednAME);
                    resultAllHistory = returnBYPRoc(selectednAME);
                    MessageBox.Show("התוצאה היא: " + resultCalc.ToString() + "\n" + resultAllHistory);
                    break;

                default:
                    // Handle other cases if needed
                    break;
                }
                

            }

            void insertToTable(string selectItem)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // יצירת מחרוזת שאילתת SQL INSERT
                        string insertQuery = "INSERT INTO tblOperation (nameOperation, valueCalc,resultCalc) VALUES (@nameOper, @value,@resCalc)";

                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            // הוספת פרמטרים לשאילתת SQL
                            command.Parameters.AddWithValue("@nameOper", selectItem);
                            command.Parameters.AddWithValue("@value", resultCalcSt);
                            command.Parameters.AddWithValue("@resCalc", resultCalc);


                            // ביצוע שאילתת ה-INSERT
                            command.ExecuteNonQuery();
                        }
                    }

                    // MessageBox.Show("שורה התווספה לטבלה במסד הנתונים.", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"שגיאה: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //MessageBox.Show("Row added to SQL Server database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            string returnBYPRoc(string selectItem)
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("historyAction", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        command.Parameters.AddWithValue("@typeAction", selectItem);

                        // Add output parameter
                        SqlParameter outputParameter = new SqlParameter();
                        outputParameter.ParameterName = "@result";
                        outputParameter.SqlDbType = SqlDbType.NVarChar;
                        outputParameter.Size = -1; // Max size
                        outputParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParameter);

                        // Execute the stored procedure
                        command.ExecuteNonQuery();

                    string outputMessage;
                    if (outputParameter.Value != DBNull.Value)
                    {
                        // Get the output value
                        outputMessage = outputParameter.Value.ToString();
                    }
                    else
                    {
                        // Handle DBNull.Value case, for example, assign a default value
                        outputMessage = " ";
                    }
                    return outputMessage;

                        // Display the message
                        Console.WriteLine("Message from stored procedure: " + outputMessage);
                    }
                }
                //void calcByType_numbers(string typeSelected)
                //{

                //}
                //void calcByType_string(string typeSelected)
                //{

                //}
            }
        
    }
}